using System;
using System.Net;
using ClassicUO.Configuration;
using ClassicUO.Dust765.Managers;
using ClassicUO.Dust765.Lobby.Networking;
using ClassicUO.Dust765.Shared;
using ClassicUO.Game;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Data;
using ClassicUO.Game.Managers;

namespace ClassicUO.Dust765.Lobby
{
    public static class Lobby
    {
        public static int Port = Convert.ToInt32(ProfileManager.CurrentProfile.LobbyPort);
        static IPEndPoint _ipep;
        public static NetState _netState;
        
        public static void LoadCommands()
        {
            CommandManager.Register("lobby", new Action<string[]>(OnCommand_Client));
        }

        private static void OnCommand_Client(string[] s)
        {
            if (s.Length == 0)
            {
                Print("Use \"-lobby help\" for more commands.");
                return;
            }

            string strcmd = s[0];
            if(strcmd.Length == 0)
            {
                Print("Invalid command.");
                return;
            }

            var args = new CommandArgs(strcmd);
            
            if(_netState == null || !_netState.IsOpen)
            {
                switch(args.GetArgument(0))
                {
                    default:
                    Print("Failed to recognize network command.", MessageColor.Orange);
                    break;

                    case "help":
                    Print("Usage: status | connect");
                    break;

                    case "status":
                    Print("You are currently offline.", MessageColor.Red);
                    break;

                    case "connect":
                    if(args.Count == 2)
                    {
                        string ipString = args.GetArgument(1);
                        if(ipString == "help")
                        {
                            Print("Usage: connect 127.0.0.1");
                            break;
                        } else if(NetState.ValidateIPv4(ipString))
                            Connect(args.GetIPAddress(1));
                        break;
                    } else
                    {
                        Print("You provided an invalid IP address format.", MessageColor.Orange);
                    }
                    break;

                    case "cast":
                    Print("You must be connected to perform that action.", MessageColor.Orange);
                    break;

                    case "target":
                    Print("You must be connected to perform that action.", MessageColor.Orange);
                    break;

                    case "drop":
                    Print("You must be connected to perform that action.", MessageColor.Orange);
                    break;

                    case "attack":
                    Print("You must be connected to perform that action.", MessageColor.Orange);
                    break;
                }
                return;
            }

            Mobile mob;

            switch(args.GetArgument(0))
            {
                default: 
                Print("Network command not recognized.", MessageColor.Orange);
                break;

                case "help":
                Print("Usage: status | disconnect | cast | target | drop | hid");
                break;

                case "drop" when args.Count == 2 && args.GetArgument(1) == "help":
                Print("Usage: Drops any spell you are currently holding onto the last target sent to the group.");
                break;

                case "target" when args.Count == 2 && args.GetArgument(1) == "help":
                Print("Usage: Update the last target for everyone in the group.");
                break;

                case "status":
                Print($"You are connected to {_ipep.Address}.", MessageColor.Green);
                break;

                case "connect":
                Print($"You are already connected to a network.", MessageColor.Orange);
                break;

                case "disconnect":
                Disconnect();
                break;

                case "drop" when TargetManager.LastTargetInfo.Serial != 0:
                    mob = World.Mobiles.Get(TargetManager.LastTargetInfo.Serial);
                    if(mob != null)
                    _netState.Send(new PTarget(mob));
                else
                    Print("Target was out of range.", MessageColor.Red);
                break;

                case "target" when TargetManager.LastTargetInfo.Serial != 0:
                    mob = World.Mobiles.Get(TargetManager.LastTargetInfo.Serial);
                    if(mob != null)
                    _netState.Send(new PSetTarget(mob));
                else
                    Print("Target was out of range.", MessageColor.Red);
                break;

                case "cast" when args.Count == 2:
                string value = args.GetArgument(1);
                if ( value == "help" )
                {
                    Print("Usage: cast {spell}");
                    break;
                }
                try
                {
                    var spell = Enum.Parse(typeof(SpellAction), value, true);
                    _netState.Send(new PSpellCast((SpellAction)spell));
                }
                catch
                {
                    Print($"Spell = '{value}' is invalid, failed to parse.", MessageColor.Orange);
                }
                break;

                case "attack" when TargetManager.LastTargetInfo.Serial != 0:
                    mob = World.Mobiles.Get(TargetManager.LastTargetInfo.Serial);
                    if (mob != null)
                        _netState.Send(new PAttack(mob));
                    break;
            }

        }

        public static void Connect( IPAddress addr )
        {
            bool rejoin = _netState != null ? CompareIPv4(_netState.Address, addr) : false;
            if ( rejoin && _netState.IsOpen )
            {
                Disconnect();
            }
            _ipep = new IPEndPoint(addr, Lobby.Port);
            _netState = NetState.Connect(_ipep);
            if(_netState == null || !_netState.IsOpen)
            {
                Print("You failed to establish a connection.", MessageColor.Orange);
            } else
            {
                _netState.Send(new PConnected(World.Player, rejoin));
            }
        }

        public static bool CompareIPv4( IPAddress current, IPAddress other )
        {
            byte[] from = current.GetAddressBytes();
            byte[] to = other.GetAddressBytes();

            for(int i = 0; i < 4; i++)
            {
                if(from[i] != to[i])
                    return false;
            }

            return true;
        }

        public static void Disconnect()
        {
            if(_netState == null)
                return;

            _netState.Disconnect();
            _netState = null;

            Print("Disconnected from the network.", MessageColor.Orange);
        }

        public static void Update()
        {
            if(_netState == null) 
                return;

            _netState.Slice();
        }

        public static void Print(string message, MessageColor color = MessageColor.Default)
        {
            GameActions.Print(message, (ushort)color, MessageType.System, 1);
        }
    }
}