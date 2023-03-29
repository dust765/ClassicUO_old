﻿#region license

// Copyright (C) 2020 project dust765
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System.IO;

using System;
using System.Collections.Generic;
using ClassicUO.Configuration;
using ClassicUO.Game;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Renderer;
using ClassicUO.Assets;
using ClassicUO.IO;
using ClassicUO.Utility;
using ClassicUO.Utility.Collections;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicUO.Dust765.Dust765
{
    internal class VisualResponseManager
    {
        public bool IsEnabled => ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.VisualResponseManager;
        private readonly List<VREntry> _actions = new List<VREntry>();

        public class VREntry
        {
            public uint Graphic { get; set; }
            public uint Time { get; set; }
            public uint SecondTime { get; set; }
            public int OffsetY { get; set; }
        }

        public void Draw(UltimaBatcher2D batcher)
        {
            if (!IsEnabled)
            {
                return;
            }

            if (World.Player == null)
            {
                return;
            }

            if (_actions.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _actions.Count; i++)
            {
                VREntry entry = _actions[i];
                uint delta = Time.Ticks - entry.Time;

                if (entry.SecondTime < Time.Ticks)
                {
                    entry.OffsetY += 3;
                    entry.SecondTime = Time.Ticks + 25;
                }

                if (delta > 1000)
                {
                    _actions.RemoveAt(i--);
                    continue;
                }

                var texture = ArtLoader.Instance.GetStaticTexture(entry.Graphic, out var bounds);

                Point pm = CombatCollection.CalcUnderChar(World.Player);
                pm.X -= bounds.Width;

                Vector3 _hueVector = ShaderHueTranslator.GetHueVector(0, false, 1);

                //vanish effect
                if (delta > 600)
                {
                    float _delta = delta;
                    float _alpha = 1 - (_delta / 1000);
                    
                    _hueVector.Z = _alpha;
                }

                batcher.Draw(texture, new Rectangle(pm.X, pm.Y - entry.OffsetY, bounds.Width, bounds.Height), bounds, _hueVector);
            }
        }

        public void Add(VREntry vrentry)
        {
            if (!IsEnabled)
            {
                return;
            }

            foreach (VREntry vre in _actions)
            {
                if (vrentry == vre)
                {
                    return;
                }
            }

            _actions.Add(vrentry);
        }

        public void Clear()
        {
            _actions.Clear();
        }
        //EVENTS
        //ANIMATION EVENT
        public void DrawAnimation(ushort graphic, ushort hue, byte speed, int duration)
        {
            if (!IsEnabled)
            {
                return;
            }

            if (World.Player == null)
            {
                return;
            }

            //Usage:
            //DrawAnimation(14089, 0, 10, 30);

            //Some Animations:
            //14089 = Flamestrike - 10 - 30

            //0x22C6 = Reflect Physical
            //0x36B0 = Explosion

            //0x36F4 = Explosion ball
            //0x3728 / 0x372A = Smoke
            //0x3735 = Fizzle
            //0x373A / 0x3740 = Sparkle 1
            //0x3749 / 0x374A = Sparkle 2
            //0x375A = Sparkle 3
            //0x376A = Sparkle 4
            //0x3779 = Sparkle 5
            //0x3789 = Death vortex
            //0x37B9 / 0x37BE = Glow
            //0x37C4 = Glow 2
            //0x42CF = Sparkle 6

            World.SpawnEffect(GraphicEffectType.FixedFrom, World.Player.Serial, 0, graphic, hue, 0, 0, 0, 0, 0, 0, speed, duration, false, true, false, GraphicEffectBlendMode.Normal);
        }
        //ART EVENT
        public void DrawArt(ushort graphic)
        {
            //curepot = 0x0F07
            //healpot = 0x0F0C
            //refreshpot = 0xF0B
            //str = 0xF09
            //agi = 0xF08

            VREntry newEntry = new VREntry
            {
                Graphic = graphic,
                Time = Time.Ticks
            };
            Add(newEntry);
        }
        //HANDLE CLILOCS
        public void OnCliloc(uint cliloc)
        {
            //START BANDIES TIMER
            for (int i = 0; i < _startBandiesAtClilocs.Length; i++)
            {
                if (_startBandiesAtClilocs[i] == cliloc)
                {
                    DrawArt(0x0E21);
                    return;
                }
            }

            //RESIST MAGIC
            for (int i = 0; i < _resistingMagicAtClilocs.Length; i++)
            {
                if (_resistingMagicAtClilocs[i] == cliloc)
                {
                    DrawAnimation(0x37BE, 11, 10, 10);
                    return;
                }
            }
        }
        //CLILOCS
        private static int[] _startBandiesAtClilocs = new int[]
        {
            500956,
            500957,
            500958,
            500959,
            500960
        };
        private static int[] _resistingMagicAtClilocs = new int[]
        {
            501783, //You feel yourself resisting magical energy.
            501784, //You feel yourself resisting magical energy.
            502635, //You feel yourself resisting magical energy.
            502637, //You feel yourself resisting magical energy.
            502638  //You feel yourself resisting magical energy.
        };
        //HANDLE PLUGIN EVENTS
        //ON PLUGIN SEND LOG
        public void OnPluginSendLog(Span<byte> buffer, int length)
        {
            if (!IsEnabled)
            {
                return;
            }

            //NETCLIENT LOGPACKET
            Span<char> span = stackalloc char[256];
            ValueStringBuilder output = new ValueStringBuilder(span);
            {
                int off = sizeof(ulong) + 2;

                output.Append(' ', off);
                output.Append(string.Format("Ticks: {0} | {1} |  ID: {2:X2}   Length: {3}\n", Time.Ticks, ("Assistant -> Server"), buffer[0], length));

                output.Append(' ', off);
                output.Append("0  1  2  3  4  5  6  7   8  9  A  B  C  D  E  F\n");

                output.Append(' ', off);
                output.Append("-- -- -- -- -- -- -- --  -- -- -- -- -- -- -- --\n");

                ulong address = 0;

                for (int i = 0; i < length; i += 16, address += 16)
                {
                    output.Append($"{address:X8}");

                    for (int j = 0; j < 16; ++j)
                    {
                        if ((j % 8) == 0)
                        {
                            output.Append(" ");
                        }

                        if (i + j < length)
                        {
                            output.Append($" {buffer[i + j]:X2}");
                        }
                        else
                        {
                            output.Append("   ");
                        }
                    }

                    output.Append("  ");

                    for (int j = 0; j < 16 && i + j < length; ++j)
                    {
                        byte c = buffer[i + j];

                        if (c >= 0x20 && c < 0x80)
                        {
                            output.Append((char) c);
                        }
                        else
                        {
                            output.Append('.');
                        }
                    }

                    output.Append('\n');
                }
                output.Append('\n');
                output.Append('\n');

                Console.WriteLine(output.ToString());

                output.Dispose();
            }
        }
        //ON PLUGIN SEND
        public void OnPluginSend(byte[] data, int length)
        {
            if (!IsEnabled)
            {
                return;
            }

            switch (data[0])
            {
                case 0x06:

                    StackDataReader buffer = new StackDataReader(data.AsSpan(0, length));

                    //skip first
                    //byte type = buffer.ReadUInt8();
                    int offset = 1;
                    buffer.Seek(offset);

                    //read serial
                    uint serial = buffer.ReadUInt32BE();
                    //Console.WriteLine("serial: " + serial.ToHex());

                    if (SerialHelper.IsItem(serial))
                    {
                        Item item = World.Items.Get(serial);

                        //failsafe
                        if (item == null)
                        {
                            break;
                        }

                        //Console.WriteLine("item.Graphic" + item.Graphic);
                        //Console.WriteLine("item.Name" + item.Name);

                        //curepot = 0x0F07
                        //healpot = 0x0F0C
                        //refreshpot = 0xF0B
                        //str = 0xF09
                        //agi = 0xF08

                        if (item.Graphic == 0x0F07 || item.Graphic == 0x0F0C || item.Graphic == 0xF0B || item.Graphic == 0xF09 || item.Graphic == 0xF08)
                        {
                            DrawArt(item.Graphic);
                        }
                    }

                    break;
            }
        }
    }
}