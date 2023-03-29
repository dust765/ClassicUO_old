#region license

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
// ## BEGIN - END ## // NAMEOVERHEAD
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using ClassicUO.Game.Data;
using ClassicUO.Input;
using ClassicUO.Utility.Logging;
using SDL2;
// ## BEGIN - END ## // NAMEOVERHEAD
using ClassicUO.Configuration;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.UI.Gumps;
// ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
using ClassicUO.Utility;
// ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

namespace ClassicUO.Game.Managers
{
    [Flags]
    // ## BEGIN - END ## // NAMEOVERHEAD
    /*
    internal enum NameOverheadTypeAllowed
    {
        All,
        Mobiles,
        Items,
        Corpses,
        MobilesCorpses = Mobiles | Corpses
    }
    */
    // ## BEGIN - END ## // NAMEOVERHEAD
    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
    /*
    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
    internal enum NameOverheadOptions
    {
        None = 0,

        // Items
        Containers = 1 << 0,
        Gold = 1 << 1,
        Stackable = 1 << 2,
        LockedDown = 1 << 3,

        // Corpses
        MonsterCorpses = 1 << 4,
        HumanoidCorpses = 1 << 5,
        OwnCorpses = 1 << 6,

        // Mobiles (type)
        Humanoid = 1 << 7,
        Monster = 1 << 8,
        OwnFollowers = 1 << 9,

        // Mobiles (notoriety)
        Innocent = 1 << 10,
        Ally = 1 << 11,
        Gray = 1 << 12,
        Criminal = 1 << 13,
        Enemy = 1 << 14,
        Murderer = 1 << 15,
        Invulnerable = 1 << 16,

        AllItems = Containers | Gold | Stackable | LockedDown,
        AllMobiles = Humanoid | Monster,
        MobilesAndCorpses = AllMobiles | MonsterCorpses | HumanoidCorpses,
        // ## BEGIN - END ## // NAMEOVERHEAD
    }
    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
    */
    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
    internal enum NameOverheadOptions
    {
        None = 0,

        // Items
        Containers = 1 << 0,
        Gold = 1 << 1,
        Stackable = 1 << 2,
        LockedDown = 1 << 3,
        Properties = 1 << 4,
        Nameslist = 1 << 5,

        // Corpses
        MonsterCorpses = 1 << 6,
        HumanoidCorpses = 1 << 7,
        OwnCorpses = 1 << 8,

        // Mobiles (type)
        Humanoid = 1 << 9,
        Monster = 1 << 10,
        OwnFollowers = 1 << 11,

        // Mobiles (notoriety)
        Innocent = 1 << 12,
        Ally = 1 << 13,
        Gray = 1 << 14,
        Criminal = 1 << 15,
        Enemy = 1 << 16,
        Murderer = 1 << 17,
        Invulnerable = 1 << 18,

        AllItems = Containers | Gold | Stackable | LockedDown | Properties | Nameslist,
        AllMobiles = Humanoid | Monster,
        MobilesAndCorpses = AllMobiles | MonsterCorpses | HumanoidCorpses,
        NameList = Nameslist,
        PropsList = Properties,

    }
    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

    internal static class NameOverHeadManager
    {
        private static NameOverHeadHandlerGump _gump;
        // ## BEGIN - END ## // NAMEOVERHEAD
        private static SDL.SDL_Keycode _lastKeySym = SDL.SDL_Keycode.SDLK_UNKNOWN;
        private static SDL.SDL_Keymod _lastKeyMod = SDL.SDL_Keymod.KMOD_NONE;
        // ## BEGIN - END ## // NAMEOVERHEAD

        // ## BEGIN - END ## // NAMEOVERHEAD
        /*
        public static NameOverheadTypeAllowed TypeAllowed
        {
            get => ProfileManager.CurrentProfile.NameOverheadTypeAllowed;
            set => ProfileManager.CurrentProfile.NameOverheadTypeAllowed = value;
        }
        */
        // ## BEGIN - END ## // NAMEOVERHEAD
        public static string LastActiveNameOverheadOption
        {
            get => ProfileManager.CurrentProfile.LastActiveNameOverheadOption;
            set => ProfileManager.CurrentProfile.LastActiveNameOverheadOption = value;
        }
        // ## BEGIN - END ## // NAMEOVERHEAD

        // ## BEGIN - END ## // NAMEOVERHEAD
        /*
        public static bool IsToggled
        {
            get => ProfileManager.CurrentProfile.NameOverheadToggled;
            set => ProfileManager.CurrentProfile.NameOverheadToggled = value;
        }
        */
        // ## BEGIN - END ## // NAMEOVERHEAD
        public static bool IsHealthLinesToggled
        {
            get => ProfileManager.CurrentProfile.ShowHPLineInNOH;
            private set => ProfileManager.CurrentProfile.ShowHPLineInNOH = value;
        }
        public static bool IsBackgroundToggled
        {
            get => ProfileManager.CurrentProfile.NameOverheadBackgroundToggled;
            private set => ProfileManager.CurrentProfile.NameOverheadBackgroundToggled = value;
        }
        public static bool IsPinnedToggled
        {
            get => ProfileManager.CurrentProfile.NameOverheadPinnedToggled;
            private set => ProfileManager.CurrentProfile.NameOverheadPinnedToggled = value;
        }
        public static NameOverheadOptions ActiveOverheadOptions { get; set; }
        public static bool IsPermaToggled
        {
            get => ProfileManager.CurrentProfile.NameOverheadToggled;
            private set => ProfileManager.CurrentProfile.NameOverheadToggled = value;
        }
        public static bool IsTemporarilyShowing { get; private set; }
        public static bool IsShowing => IsPermaToggled || IsTemporarilyShowing || Keyboard.Ctrl && Keyboard.Shift;
        // ## BEGIN - END ## // NAMEOVERHEAD

        // ## BEGIN - END ## // NAMEOVERHEAD
        //private static List<NameOverheadOption> Options { get; set; } = new();
        // ## BEGIN - END ## // NAMEOVERHEAD
        private static List<NameOverheadOption> Options { get; set; } = new List<NameOverheadOption>();
        // ## BEGIN - END ## // NAMEOVERHEAD
        // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
        private static List<string> CompareNames { get; set; } = new List<string>();
        private static List<string> PropertyList { get; set; } = new List<string>();
        // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

        public static bool IsAllowed(Entity serial)
        {
            if (serial == null)
            {
                return false;
            }

            // ## BEGIN - END ## // NAMEOVERHEAD
            /*
            if (TypeAllowed == NameOverheadTypeAllowed.All)
            {
                return true;
            }

            if (SerialHelper.IsItem(serial.Serial) && TypeAllowed == NameOverheadTypeAllowed.Items)
            {
                return true;
            }

            if (SerialHelper.IsMobile(serial.Serial) && TypeAllowed.HasFlag(NameOverheadTypeAllowed.Mobiles))
            {
                return true;
            }

            if (TypeAllowed.HasFlag(NameOverheadTypeAllowed.Corpses) && SerialHelper.IsItem(serial.Serial) && World.Items.Get(serial)?.IsCorpse == true)
            {
                return true;
            }
            */
            // ## BEGIN - END ## // NAMEOVERHEAD
            if (SerialHelper.IsItem(serial))
                return HandleItemOverhead(serial);

            if (SerialHelper.IsMobile(serial))
                return HandleMobileOverhead(serial);
            // ## BEGIN - END ## // NAMEOVERHEAD

            return false;
        }
        // ## BEGIN - END ## // NAMEOVERHEAD
        private static bool HandleMobileOverhead(Entity serial)
        {
            var mobile = serial as Mobile;

            if (mobile == null)
                return false;

            // Mobile types
            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Humanoid) && mobile.IsHuman)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Monster) && !mobile.IsHuman)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.OwnFollowers) && mobile.IsRenamable && mobile.NotorietyFlag != NotorietyFlag.Invulnerable && mobile.NotorietyFlag != NotorietyFlag.Enemy)
                return true;

            // Mobile notorieties
            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Innocent) && mobile.NotorietyFlag == NotorietyFlag.Innocent)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Ally) && mobile.NotorietyFlag == NotorietyFlag.Ally)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Gray) && mobile.NotorietyFlag == NotorietyFlag.Gray)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Criminal) && mobile.NotorietyFlag == NotorietyFlag.Criminal)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Enemy) && mobile.NotorietyFlag == NotorietyFlag.Enemy)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Murderer) && mobile.NotorietyFlag == NotorietyFlag.Murderer)
                return true;

            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Invulnerable) && mobile.NotorietyFlag == NotorietyFlag.Invulnerable)
                return true;

            return false;
        }

        private static bool HandleItemOverhead(Entity serial)
        {
            var item = serial as Item;

            if (item == null)
                return false;

            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
            if (SerialHelper.IsItem(serial) && ActiveOverheadOptions.HasFlag(NameOverheadOptions.AllItems))
            {
                return true;

            }
            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

            if (item.IsCorpse)
            {
                return HandleCorpseOverhead(item);
            }
            
            if (item.ItemData.IsContainer && ActiveOverheadOptions.HasFlag(NameOverheadOptions.Containers))
                return true;

            if (item.IsCoin && ActiveOverheadOptions.HasFlag(NameOverheadOptions.Gold))
                return true;

            if (item.ItemData.IsStackable && ActiveOverheadOptions.HasFlag(NameOverheadOptions.Stackable))
                return true;

            if (item.IsLocked && ActiveOverheadOptions.HasFlag(NameOverheadOptions.LockedDown))
                return true;

            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Properties))
            {
                bool hasStartColor = false;

                string result = null;
                string texto = string.Empty;

                if (SerialHelper.IsValid(serial) && World.OPL.TryGetNameAndData(serial, out string name, out string data))
                {
                    ValueStringBuilder sbHTML = new ValueStringBuilder();
                    {
                        ValueStringBuilder sb = new ValueStringBuilder();
                        {
                            if (!string.IsNullOrEmpty(name))
                            {
                                if (SerialHelper.IsItem(serial))
                                {
                                    sbHTML.Append("<basefont color=\"yellow\">");
                                    hasStartColor = true;
                                }
                                else
                                {
                                    Mobile mob = World.Mobiles.Get(serial);

                                    if (mob != null)
                                    {
                                        sbHTML.Append(Notoriety.GetHTMLHue(mob.NotorietyFlag));
                                        hasStartColor = true;
                                    }
                                }

                                sb.Append(name);
                                sbHTML.Append(name);

                                if (hasStartColor)
                                {
                                    sbHTML.Append("<basefont color=\"#FFFFFFFF\">");
                                }
                            }

                            if (!string.IsNullOrEmpty(data))
                            {
                                sb.Append('\n');
                                sb.Append(data);
                                sbHTML.Append('\n');
                                sbHTML.Append(data);
                            }

                            texto = sbHTML.ToString();
                            result = sb.ToString();

                            sb.Dispose();
                            sbHTML.Dispose();
                        }
                    }
                }
                //string _textHTML;
                //string texto = TargetManager.LastTargetInfo.ReadProperties(serial, out _textHTML);
                if (texto != null)
                {
                    for (int x = 0; x < PropertyList.Count; x++)
                    {

                        if (texto.Contains(PropertyList[x]))
                        {
                            return true;
                        }

                    }


                }
            }
            if (ActiveOverheadOptions.HasFlag(NameOverheadOptions.Nameslist))
            {
                for (int x = 0; x < CompareNames.Count; x++)
                {
                    if (item.Name != null)
                    {
                        if (item.Name.Contains(CompareNames[x]))
                        {
                            return true;
                        }
                    }

                }

            }
            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

            return false;
        }

        private static bool HandleCorpseOverhead(Item item)
        {
            var isHumanCorpse = item.IsHumanCorpse;

            if (isHumanCorpse && ActiveOverheadOptions.HasFlag(NameOverheadOptions.HumanoidCorpses))
                return true;

            if (!isHumanCorpse && ActiveOverheadOptions.HasFlag(NameOverheadOptions.MonsterCorpses))
                return true;

            // TODO: Add support for IsOwnCorpse, which was coded by Dyru
            return false;
        }
        // ## BEGIN - END ## // NAMEOVERHEAD

        public static void Open()
        {
            if (_gump == null || _gump.IsDisposed)
            {
                _gump = new NameOverHeadHandlerGump();
                UIManager.Add(_gump);
            }

            _gump.IsEnabled = true;
            _gump.IsVisible = true;
        }

        public static void Close()
        {
            if (_gump == null)
                return;

            _gump.IsEnabled = false;
            _gump.IsVisible = false;
        }

        public static void ToggleOverheads()
        {
            // ## BEGIN - END ## // NAMEOVERHEAD
            //IsToggled = !IsToggled;
            // ## BEGIN - END ## // NAMEOVERHEAD
            SetOverheadToggled(!IsPermaToggled);
            // ## BEGIN - END ## // NAMEOVERHEAD
        }
        // ## BEGIN - END ## // NAMEOVERHEAD
        public static void SetHealthLinesToggled(bool toggled)
        {
            if (IsHealthLinesToggled == toggled)
                return;

            IsHealthLinesToggled = toggled;
            _gump?.UpdateCheckboxes();
        }
        public static void SetBackgroundToggled(bool toggled)
        {
            if (IsBackgroundToggled == toggled)
                return;

            IsBackgroundToggled = toggled;
            _gump?.UpdateCheckboxes();

            //TODO
            //close and reopan all handles
        }
        public static void SetPinnedToggled(bool toggled)
        {
            if (IsPinnedToggled == toggled)
                return;

            IsPinnedToggled = toggled;
            _gump?.UpdateCheckboxes();
            _gump.CanCloseWithRightClick = !toggled;
        }
        public static void SetOverheadToggled(bool toggled)
        {
            if (IsPermaToggled == toggled)
                return;

            IsPermaToggled = toggled;
            _gump?.UpdateCheckboxes();
        }
        public static void Load()
        {
            string path = Path.Combine(ProfileManager.ProfilePath, "nameoverhead.xml");

            if (!File.Exists(path))
            {
                Log.Trace("No nameoverhead.xml file. Creating a default file.");


                Options.Clear();
                CreateDefaultEntries();
                Save();

                return;
            }

            Options.Clear();
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());

                return;
            }


            XmlElement root = doc["nameoverhead"];

            if (root != null)
            {
                foreach (XmlElement xml in root.GetElementsByTagName("nameoverheadoption"))
                {
                    var option = new NameOverheadOption(xml.GetAttribute("name"));
                    option.Load(xml);
                    Options.Add(option);

                    if (option.Name == LastActiveNameOverheadOption)
                    {
                        SetActiveOption(option);
                    }
                }
            }

            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
            //overhead name list added
            path = Path.Combine(ProfileManager.ProfilePath, "OverheadNamesList.txt");

            if (!File.Exists(path))
            {

                Log.Trace("No OverheadNamesList.txt. Creating a default file.");

                CompareNames.Clear();
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Bag");
                    sw.WriteLine("bag");
                }

            }
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        CompareNames.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());

                return;
            }

            //overhead properties list added
            path = Path.Combine(ProfileManager.ProfilePath, "OverheadPropertiesList.txt");

            if (!File.Exists(path))
            {
                Log.Trace("No OverheadPropertiesList.txt. Creating a default file.");
                PropertyList.Clear();
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Artifact");
                    sw.WriteLine("artifact");
                }
            }
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        PropertyList.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());

                return;
            }

            // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION

        }

        public static void Save()
        {
            var list = Options;

            string path = Path.Combine(ProfileManager.ProfilePath, "nameoverhead.xml");

            using XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            };

            xml.WriteStartDocument(true);
            xml.WriteStartElement("nameoverhead");

            foreach (var option in list)
            {
                option.Save(xml);
            }

            xml.WriteEndElement();
            xml.WriteEndDocument();
        }

        private static void CreateDefaultEntries()
        {
            Options.AddRange
            (
                new[]
                {
                    new NameOverheadOption("All", int.MaxValue),
                    new NameOverheadOption("Mobiles only", (int)NameOverheadOptions.AllMobiles),
                    new NameOverheadOption("Items only", (int)NameOverheadOptions.AllItems),
                    new NameOverheadOption("Mobiles & Corpses only", (int)NameOverheadOptions.MobilesAndCorpses),
                    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
                    new NameOverheadOption("Names list", (int)NameOverheadOptions.NameList),
                    new NameOverheadOption("Properties List", (int)NameOverheadOptions.PropsList),
                    // ## BEGIN - END ## // NAMEOVERHEAD IMPROVEMENTS // PKRION
                }
            );
        }

        public static NameOverheadOption FindOption(string name)
        {
            return Options.Find(o => o.Name == name);
        }

        public static void AddOption(NameOverheadOption option)
        {
            Options.Add(option);
            _gump?.RedrawOverheadOptions();
        }

        public static void RemoveOption(NameOverheadOption option)
        {
            Options.Remove(option);
            _gump?.RedrawOverheadOptions();
        }

        public static NameOverheadOption FindOptionByHotkey(SDL.SDL_Keycode key, bool alt, bool ctrl, bool shift)
        {
            return Options.FirstOrDefault(o => o.Key == key && o.Alt == alt && o.Ctrl == ctrl && o.Shift == shift);
        }

        public static List<NameOverheadOption> GetAllOptions() => Options;

        public static void RegisterKeyDown(SDL.SDL_Keysym key)
        {
            if (_lastKeySym == key.sym && _lastKeyMod == key.mod)
                return;

            _lastKeySym = key.sym;
            _lastKeyMod = key.mod;

            bool shift = (key.mod & SDL.SDL_Keymod.KMOD_SHIFT) != SDL.SDL_Keymod.KMOD_NONE;
            bool alt = (key.mod & SDL.SDL_Keymod.KMOD_ALT) != SDL.SDL_Keymod.KMOD_NONE;
            bool ctrl = (key.mod & SDL.SDL_Keymod.KMOD_CTRL) != SDL.SDL_Keymod.KMOD_NONE;

            var option = FindOptionByHotkey(key.sym, alt, ctrl, shift);

            if (option == null)
                return;

            SetActiveOption(option);

            IsTemporarilyShowing = true;
        }

        public static void RegisterKeyUp(SDL.SDL_Keysym key)
        {
            if (key.sym != _lastKeySym)
                return;

            _lastKeySym = SDL.SDL_Keycode.SDLK_UNKNOWN;

            IsTemporarilyShowing = false;
        }

        public static void SetActiveOption(NameOverheadOption option)
        {
            ActiveOverheadOptions = (NameOverheadOptions) option.NameOverheadOptionFlags;
            LastActiveNameOverheadOption = option.Name;
            _gump?.UpdateCheckboxes();
        }
        // ## BEGIN - END ## // NAMEOVERHEAD
    }
    // ## BEGIN - END ## // NAMEOVERHEAD
    internal class NameOverheadOption
    {
        public NameOverheadOption(string name, SDL.SDL_Keycode key, bool alt, bool ctrl, bool shift, int optionflagscode) : this(name)
        {
            Key = key;
            Alt = alt;
            Ctrl = ctrl;
            Shift = shift;
            NameOverheadOptionFlags = optionflagscode;
        }

        public NameOverheadOption(string name)
        {
            Name = name;
        }

        public NameOverheadOption(string name, int optionflagcode)
        {
            Name = name;
            NameOverheadOptionFlags = optionflagcode;
        }

        public string Name { get; }

        public SDL.SDL_Keycode Key { get; set; }
        public bool Alt { get; set; }
        public bool Ctrl { get; set; }
        public bool Shift { get; set; }
        public int NameOverheadOptionFlags { get; set; }

        public bool Equals(NameOverheadOption other)
        {
            if (other == null)
            {
                return false;
            }

            return Key == other.Key && Alt == other.Alt && Ctrl == other.Ctrl && Shift == other.Shift && Name == other.Name;
        }

        public void Save(XmlTextWriter writer)
        {
            writer.WriteStartElement("nameoverheadoption");
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("key", ((int) Key).ToString());
            writer.WriteAttributeString("alt", Alt.ToString());
            writer.WriteAttributeString("ctrl", Ctrl.ToString());
            writer.WriteAttributeString("shift", Shift.ToString());
            writer.WriteAttributeString("optionflagscode", NameOverheadOptionFlags.ToString());

            writer.WriteEndElement();
        }

        public void Load(XmlElement xml)
        {
            if (xml == null)
            {
                return;
            }

            Key = (SDL.SDL_Keycode) int.Parse(xml.GetAttribute("key"));
            Alt = bool.Parse(xml.GetAttribute("alt"));
            Ctrl = bool.Parse(xml.GetAttribute("ctrl"));
            Shift = bool.Parse(xml.GetAttribute("shift"));
            NameOverheadOptionFlags = int.Parse(xml.GetAttribute("optionflagscode"));
        }
    }
    // ## BEGIN - END ## // NAMEOVERHEAD
}