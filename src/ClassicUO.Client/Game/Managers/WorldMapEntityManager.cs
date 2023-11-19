﻿#region license

// Copyright (c) 2021, andreakarasho
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. All advertising materials mentioning features or use of this software
//    must display the following acknowledgement:
//    This product includes software developed by andreakarasho - https://github.com/andreakarasho
// 4. Neither the name of the copyright holder nor the
//    names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using ClassicUO.Configuration;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.UI.Gumps;
using ClassicUO.Network;
using ClassicUO.Network.Encryption;
using ClassicUO.Utility.Logging;

namespace ClassicUO.Game.Managers
{
    internal class WMapEntity
    {
        public bool IsGuild;
        public uint LastUpdate;
        public string Name;
        public uint Serial;
        public int X, Y, HP, Map;



        public WMapEntity(uint serial)
        {

            GetName(serial);
        }



        public string GetName(uint serial)
        {
            Mobile mob = World.Mobiles.Get(serial);
            Entity e = World.Get(serial);
            WMapEntity wmee = World.WMapManager.GetEntity(serial);

            if (mob != null)
            {
                GameActions.Print("Is Mobile in mob " + mob.Serial + " Name: " + mob.Name);
                WMapEntity wme = World.WMapManager.GetEntity(mob.Serial);
                

                if (wme != null)
                {
                    if (string.IsNullOrEmpty(wme.Name))
                    {
                        wme.Name = mob.Name;

                        // Substituído o uso do nameCache pelo MapNameMobilesManager
                        MapNameMobilesManager.Instance.AddNameMobile((int)wme.Serial, wme.Name);
                    }
                }
            }

            if (e != null)
            {
                WMapEntity wme = World.WMapManager.GetEntity(e.Serial);
                GameActions.Print("Is Entity in entity " + e.Serial + " Name: " + e.Name);

                // Substituído o uso do nameCache pelo MapNameMobilesManager
                MapNameMobilesManager.Instance.AddNameMobile((int)e.Serial, e.Name);
            }

            // Removido o trecho de código que atribui a variável 'serial' e 'Name' diretamente, pois parece desnecessário.

            if (MapNameMobilesManager.Instance.IsNameMobile((int)serial))
            {
                // Substituído o uso do nameCache pelo MapNameMobilesManager
                return MapNameMobilesManager.Instance.GetTileName((int)serial);
            }
            else
            {
                return string.IsNullOrEmpty(Name) ? "Player Out" : Name;
            }
        }

        internal class WorldMapEntityManager
        {
            private bool _ackReceived;
            private uint _lastUpdate, _lastPacketSend, _lastPacketRecv;
            private readonly List<WMapEntity> _toRemove = new List<WMapEntity>();
            // ## BEGIN - END ## // TAZUO
            public WMapEntity _corpse;
            // ## BEGIN - END ## // TAZUO

            public bool Enabled
            {
                get
                {
                    return ((World.ClientFeatures.Flags & CharacterListFlags.CLF_NEW_MOVEMENT_SYSTEM) == 0 || _ackReceived) &&
                            EncryptionHelper.Type == 0 &&
                            ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.WorldMapShowParty &&
                            UIManager.GetGump<WorldMapGump>() != null; // horrible, but works
                }
            }

            public readonly Dictionary<uint, WMapEntity> Entities = new Dictionary<uint, WMapEntity>();

            public void SetACKReceived()
            {
                _ackReceived = true;
            }

            public void SetEnable(bool v)
            {
                if ((World.ClientFeatures.Flags & CharacterListFlags.CLF_NEW_MOVEMENT_SYSTEM) != 0 && !_ackReceived)
                {
                    Log.Warn("Server support new movement system. Can't use the 0xF0 packet to query guild/party position");
                    v = false;
                }
                else if (EncryptionHelper.Type != 0 && !_ackReceived)
                {
                    Log.Warn("Server has encryption. Can't use the 0xF0 packet to query guild/party position");
                    v = false;
                }

                if (v)
                {
                    RequestServerPartyGuildInfo(true);
                }
            }

            public void AddOrUpdate
            (
                uint serial,
                int x,
                int y,
                int hp,
                int map,
                bool isguild,
                string name = null,
                bool from_packet = false
            )
            {
                if (from_packet)
                {
                    _lastPacketRecv = Time.Ticks + 10000;
                }
                else if (_lastPacketRecv < Time.Ticks)
                {
                    return;
                }

                if (!Enabled)
                {
                    return;
                }

                if (string.IsNullOrEmpty(name))
                {
                    Entity ent = World.Get(serial);

                    if (ent != null && !string.IsNullOrEmpty(ent.Name))
                    {
                        name = ent.Name;
                    }
                }

                if (!Entities.TryGetValue(serial, out WMapEntity entity) || entity == null)
                {
                    var nameFilter = name != "" ? name : entity.GetName(serial);
                    entity = new WMapEntity(serial)
                    {

                        X = x,
                        Y = y,
                        HP = hp,
                        Map = map,
                        LastUpdate = Time.Ticks + 1000,
                        IsGuild = isguild,
                        Name = nameFilter
                    };

                    Entities[serial] = entity;
                }
                else
                {
                    entity.X = x;
                    entity.Y = y;
                    entity.HP = hp;
                    entity.Map = map;
                    entity.IsGuild = isguild;
                    entity.LastUpdate = Time.Ticks + 1000;

                    if (string.IsNullOrEmpty(entity.Name) && !string.IsNullOrEmpty(name))
                    {

                        entity.Name = entity.IsGuild ? name : entity.GetName(serial);

                    }
                }
            }

            public void Remove(uint serial)
            {
                if (Entities.ContainsKey(serial))
                {
                    Entities.Remove(serial);
                }
            }

            public void RemoveUnupdatedWEntity()
            {
                // ## BEGIN - END ## // TAZUO
                if (_corpse != null && _corpse.LastUpdate < Time.Ticks - 1000)
                {
                    _corpse = null;
                }
                // ## BEGIN - END ## // TAZUO
                if (_lastUpdate > Time.Ticks)
                {
                    return;
                }

                _lastUpdate = Time.Ticks + 1000;

                long ticks = Time.Ticks - 1000;

                foreach (WMapEntity entity in Entities.Values)
                {
                    if (entity.LastUpdate < ticks)
                    {
                        _toRemove.Add(entity);
                    }
                }

                if (_toRemove.Count != 0)
                {
                    foreach (WMapEntity entity in _toRemove)
                    {
                        Entities.Remove(entity.Serial);
                    }

                    _toRemove.Clear();
                }
            }

            public WMapEntity GetEntity(uint serial)
            {
                Entities.TryGetValue(serial, out WMapEntity entity);

                return entity;
            }

            public void RequestServerPartyGuildInfo(bool force = false)
            {
                if (!force && !Enabled)
                {
                    return;
                }

                if (World.InGame && _lastPacketSend < Time.Ticks)
                {
                    //GameActions.Print($"SENDING PACKET! {Time.Ticks}");

                    _lastPacketSend = Time.Ticks + 250;

                    //if (!force && !_can_send)
                    //{
                    //    return;
                    //}

                    NetClient.Socket.Send_QueryGuildPosition();

                    if (World.Party != null && World.Party.Leader != 0)
                    {
                        foreach (PartyMember e in World.Party.Members)
                        {
                            if (e != null && SerialHelper.IsValid(e.Serial))
                            {
                                Mobile mob = World.Mobiles.Get(e.Serial);

                                if (mob == null || mob.Distance > World.ClientViewRange)
                                {
                                    NetClient.Socket.Send_QueryPartyPosition();

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Mobile mob in World.Mobiles.Values)
                        {
                            if (mob == World.Player)
                            {
                                continue;
                            }

                            Mobile mobs = World.Mobiles.Get(mob.Serial);
                            if (mobs.NotorietyFlag == NotorietyFlag.Ally)
                            {
                                if (mobs == null || mobs.Distance > 2000000)
                                {
                                    NetClient.Socket.Send_QueryGuildPosition();

                                    break;
                                }
                            }

                        }

                    }
                }
            }

            public void Clear()
            {
                Entities.Clear();
                _ackReceived = false;
                SetEnable(false);
            }
        }
    }
}