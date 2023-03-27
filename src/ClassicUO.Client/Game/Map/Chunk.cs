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

using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ## BEGIN - END ## // POC - GUARDLINE
//using System.Collections;
//using Microsoft.Xna.Framework;
// ## BEGIN - END ## // POC - GUARDLINE
// ## BEGIN - END ## // OUTLANDS
//using ClassicUO.Dust765.Dust765;
// ## BEGIN - END ## // OUTLANDS
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Assets;
using ClassicUO.Utility;

namespace ClassicUO.Game.Map
{
    internal sealed class Chunk
    {
        private static readonly QueuedPool<Chunk> _pool = new QueuedPool<Chunk>
        (
            Constants.PREDICTABLE_CHUNKS,
            c =>
            {
                c.LastAccessTime = Time.Ticks + Constants.CLEAR_TEXTURES_DELAY;
                c.IsDestroyed = false;
            }
        );

        public GameObject[,] Tiles { get; } = new GameObject[8, 8];
        public bool IsDestroyed;
        public long LastAccessTime;
        public LinkedListNode<int> Node;


        public int X;
        public int Y;

        // ## BEGIN - END ## // POC - GUARDLINE
        //private GuardRegion[] guard_Regions = GuardRegion.guardLinesRead();
        // ## BEGIN - END ## // POC - GUARDLINE

        public static Chunk Create(int x, int y)
        {
            Chunk c = _pool.GetOne();
            c.X = x;
            c.Y = y;

            return c;
        }


        public unsafe void Load(int index)
        {
            IsDestroyed = false;

            Map map = World.Map;

            ref IndexMap im = ref GetIndex(index);

            if (im.MapAddress != 0)
            {
                MapBlock* block = (MapBlock*) im.MapAddress;
                MapCells* cells = (MapCells*) &block->Cells;
                int bx = X << 3;
                int by = Y << 3;

                for (int y = 0; y < 8; ++y)
                {
                    int pos = y << 3;
                    ushort tileY = (ushort) (by + y);

                    for (int x = 0; x < 8; ++x, ++pos)
                    {
                        ushort tileID = (ushort) (cells[pos].TileID & 0x3FFF);

                        sbyte z = cells[pos].Z;

                        Land land = Land.Create(tileID);

                        ushort tileX = (ushort) (bx + x);

                        land.ApplyStretch(map, tileX, tileY, z);
                        land.X = tileX;
                        land.Y = tileY;
                        land.Z = z;
                        // ## BEGIN - END ## // POC - GUARDLINE
                        //if (PointInRect(land.X, land.Y))
                        //    land.Hue = 0x33;
                        // ## BEGIN - END ## // POC - GUARDLINE
                        land.UpdateScreenPosition();

                        AddGameObject(land, x, y);
                    }
                }

                if (im.StaticAddress != 0)
                {
                    StaticsBlock* sb = (StaticsBlock*) im.StaticAddress;

                    if (sb != null)
                    {
                        for (int i = 0, count = (int) im.StaticCount; i < count; ++i, ++sb)
                        {
                            if (sb->Color != 0 && sb->Color != 0xFFFF)
                            {
                                int pos = (sb->Y << 3) + sb->X;

                                if (pos >= 64)
                                {
                                    continue;
                                }

                                Static staticObject = Static.Create(sb->Color, sb->Hue, pos);
                                staticObject.X = (ushort) (bx + sb->X);
                                staticObject.Y = (ushort) (by + sb->Y);
                                staticObject.Z = sb->Z;
                                // ## BEGIN - END ## // OUTLANDS
                                //if (CombatCollection.InfernoBridgeSolver(staticObject.X, staticObject.Y))
                                //    staticObject.Hue = 0x44;
                                // ## BEGIN - END ## // OUTLANDS
                                staticObject.UpdateScreenPosition();

                                AddGameObject(staticObject, sb->X, sb->Y);
                            }
                        }
                    }
                }
            }
        }


        private ref IndexMap GetIndex(int map)
        {
            MapLoader.Instance.SanitizeMapIndex(ref map);

            return ref MapLoader.Instance.GetIndex(map, X, Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GameObject GetHeadObject(int x, int y)
        {
            GameObject obj = Tiles[x, y];

            while (obj?.TPrevious != null)
            {
                obj = obj.TPrevious;
            }

            return obj;
        }

        public void AddGameObject(GameObject obj, int x, int y)
        {
            obj.RemoveFromTile();

            short priorityZ = obj.Z;
            sbyte state = -1;

            ushort graphic = obj.Graphic;

            switch (obj)
            {
                case Land tile:

                    if (tile.IsStretched)
                    {
                        priorityZ = (short) (tile.AverageZ - 1);
                    }
                    else
                    {
                        priorityZ--;
                    }

                    priorityZ -= 1;

                    state = 0;

                    break;

                case Mobile _:
                    priorityZ++;

                    break;

                case Item item:

                    if (item.IsCorpse)
                    {
                        priorityZ++;

                        break;
                    }
                    else if (item.IsMulti)
                    {
                        graphic = item.MultiGraphic;
                    }

                    goto default;

                case GameEffect _:
                    priorityZ += 2;

                    break;

                case Multi m:

                    state = 1;

                    if ((m.State & CUSTOM_HOUSE_MULTI_OBJECT_FLAGS.CHMOF_GENERIC_INTERNAL) != 0)
                    {
                        priorityZ--;

                        break;
                    }

                    if ((m.State & CUSTOM_HOUSE_MULTI_OBJECT_FLAGS.CHMOF_PREVIEW) != 0)
                    {
                        state = 2;
                        priorityZ++;
                    }
                    //else if ((m.ItemData.Flags & TileFlag.StairRight) != 0)
                    //{
                    //    priorityZ++;
                    //}

                    //if (m.IsMovable)
                    //{
                    //    priorityZ += 1;
                    //}

                    goto default;

                default:
                    ref StaticTiles data = ref TileDataLoader.Instance.StaticData[graphic];

                    if (data.IsBackground)
                    {
                        priorityZ--;
                    }
         
                    //if (data.IsSurface)
                    //{
                    //    priorityZ--;
                    //}

                    if (data.Height != 0)
                    {
                        priorityZ++;
                    }

                    if (data.IsMultiMovable)
                    {
                        priorityZ++;
                    }

                    break;
            }

            obj.PriorityZ = priorityZ;

            if (Tiles[x, y] == null)
            {
                Tiles[x, y] = obj;
                obj.TPrevious = null;
                obj.TNext = null;

                return;
            }


            GameObject o = Tiles[x, y];

            if (o == obj)
            {
                if (o.Previous != null)
                {
                    o = (GameObject) o.Previous;
                }
                else if (o.Next != null)
                {
                    o = (GameObject) o.Next;
                }
                else
                {
                    return;
                }
            }

            while (o?.TPrevious != null)
            {
                o = o.TPrevious;
            }

            GameObject found = null;
            GameObject start = o;

            while (o != null)
            {
                int testPriorityZ = o.PriorityZ;

                if (testPriorityZ > priorityZ || testPriorityZ == priorityZ && (state == 0 || state == 1 && !(o is Land)))
                {
                    break;
                }

                found = o;
                o = o.TNext;
            }

            if (found != null)
            {
                obj.TPrevious = found;
                GameObject next = found.TNext;
                obj.TNext = next;
                found.TNext = obj;

                if (next != null)
                {
                    next.TPrevious = obj;
                }
            }
            else if (start != null)
            {
                obj.TNext = start;
                start.TPrevious = obj;
                obj.TPrevious = null;
            }
        }

        public void RemoveGameObject(GameObject obj, int x, int y)
        {
            ref GameObject firstNode = ref Tiles[x, y];

            if (firstNode == null || obj == null)
            {
                return;
            }

            if (firstNode == obj)
            {
                firstNode = obj.TNext;
            }

            if (obj.TNext != null)
            {
                obj.TNext.TPrevious = obj.TPrevious;
            }

            if (obj.TPrevious != null)
            {
                obj.TPrevious.TNext = obj.TNext;
            }

            obj.TPrevious = null;
            obj.TNext = null;
        }


        public void Destroy()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameObject obj = Tiles[i, j];

                    if (obj == null)
                    {
                        continue;
                    }

                    GameObject first = GetHeadObject(i, j);

                    while (first != null)
                    {
                        GameObject next = first.TNext;

                        if (!ReferenceEquals(first, World.Player))
                        {
                            first.Destroy();
                        }

                        first.TPrevious = null;
                        first.TNext = null;
                        first = next;
                    }

                    Tiles[i, j] = null;
                }
            }

            if (Node.Next != null || Node.Previous != null)
            {
                Node.List?.Remove(Node);
            }

            IsDestroyed = true;
            _pool.ReturnOne(this);
        }

        public void Clear()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameObject obj = Tiles[i, j];

                    if (obj == null)
                    {
                        continue;
                    }

                    GameObject first = GetHeadObject(i, j);

                    while (first != null)
                    {
                        GameObject next = first.TNext;

                        if (!ReferenceEquals(first, World.Player))
                        {
                            first.Destroy();
                        }

                        first.TPrevious = null;
                        first.TNext = null;
                        first = next;
                    }

                    Tiles[i, j] = null;
                }
            }

            if (Node.Next != null || Node.Previous != null)
            {
                Node.List?.Remove(Node);
            }

            IsDestroyed = true;
        }

        public bool HasNoExternalData()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (GameObject obj = GetHeadObject(i, j); obj != null; obj = obj.TNext)
                    {
                        if (!(obj is Land) && !(obj is Static) /*&& !(obj is Multi)*/)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        // ## BEGIN - END ## // POC - GUARDLINE
        /*
        public bool PointInRect(ushort x, ushort y)
        {
            int count = guard_Regions.Length;
            for (int i = 0; i < count; i++)
            {
                GuardRegion gr = this.guard_Regions[i];

                Rectangle rect = new Rectangle(gr.X, gr.Y, gr.Width, gr.Length);

                Point tile = new Point(x, y);

                if (rect.Contains(tile))
                {
                    return true;
                }
            }
            
            return false;
        }

        public class GuardRegion
        {
            private int m_Height;
            private int m_Width;
            private int m_X;
            private int m_Y;

            public GuardRegion(string line)
            {
                string[] textArray1 = line.Split(new char[] { ' ' });
                this.m_X = int.Parse(textArray1[0]);
                this.m_Y = int.Parse(textArray1[1]);
                this.m_Width = int.Parse(textArray1[2]);
                this.m_Height = int.Parse(textArray1[3]);
            }

            public static ArrayList guardLines = new ArrayList();

            /*

            Taken from razorce guardline.def

            # Papua
            5639 3095 192 223 -128 127
            5831 3237 20 30 -128 127

            # Delucia
            5123 3942 192 122 -128 127
            5147 4064 125 20 -128 127
            5235 3930 80 12 -128 127

            # Yew
            92 656 349 225 -30 39
            441 746 216 135 0 39
            258 881 399 380 0 39
            657 922 42 307 0 39
            657 806 17 28 0 39
            718 874 38 22 0 39
            761 741 19 21 0 39

            # Wind
            5132 3 70 55 -128 127
            5132 58 81 68 -128 127
            5213 98 39 28 -128 127
            5197 126 55 78 -128 127
            5252 112 42 58 -128 127
            5252 170 32 8 -128 127
            5252 178 20 5 -128 127
            5252 183 10 10 -128 127
            5294 19 72 120 -128 127
            5279 57 15 55 -128 127
            5286 25 8 32 -128 127

            # Jhelom
            1303 3670 189 225 -20 127
            1338 3895 74 28 -20 127
            1383 3951 109 94 -20 127
            1494 3767 12 11 -20 127

            # Vesper
            2893 598 121 50 -10 127
            2816 648 249 365 -10 127
            2734 944 82 4 -10 127
            2728 948 88 53 -10 127

            # Minoc
            2411 366 135 241 -10 127
            2548 495 72 55 -10 127
            2564 585 3 42 -10 127
            2567 585 61 61 -10 127
            2499 627 68 63 -10 127
            2694 685 15 16 -10 127

            # Serpent's Hold. Get
            2868 3324 205 195 0 127

            # Magincia
            3653 2046 27 48 0 127
            3752 2046 52 48 0 127
            3680 2045 72 49 0 127
            3652 2094 160 180 -128 127
            3649 2256 54 47 -128 127
            3554 2132 18 18 -128 127

            # Nujel'm
            3475 1000 360 435 0 127

            # Cove
            2200 1110 50 50 -10 127
            2200 1160 86 86 -10 127

            # Ocllo
            3587 2456 119 99 -128 127 F
            3706 2460 2 95 -128 127 F
            3587 2555 106 73 -128 127 F
            3590 2628 103 58 -128 127 F
            3693 2555 61 144 -128 127 F
            3754 2558 7 141 -128 127 F
            3761 2555 7 144 -128 50 F
            3695 2699 66 13 -128 127 F

            # Haven
            3590 2460 118 226 -10 127 T
            3568 2552 22 79 -10 127 T
            3708 2558 53 154 -10 127 T
            3695 2686 13 26 -10 127 T
            3759 2767 10 10 -10 127 T

            # Britain
            1416 1498 324 279 -10 127
            1500 1408 46 90 0 127
            1385 1538 31 239 -10 127
            1416 1777 324 60 0 127
            1385 1777 31 130 0 127
            1093 1538 292 369 0 127
            1330 1991 13 13 -10 127

            # Skara Brae
            638 2062 12 11 0 127
            538 2107 150 190 -10 127

            # Trinsic
            1856 2636 75 28 -10 127
            1816 2664 283 231 -10 127
            2099 2782 18 25 -10 127
            1970 2895 47 32 -10 127
            1796 2696 20 67 0 127
            1800 2796 16 52 0 127
            1823 2943 11 11 -128 127

            # Moonglow
            4535 844 20 3 0 127
            4530 847 31 61 0 127
            4521 914 56 49 0 127
            4278 915 54 19 0 127
            4283 944 53 73 0 127
            4377 1015 59 37 -10 127
            4367 1050 142 145 0 127
            4539 1036 27 18 0 127
            4517 1053 23 22 0 127
            4389 1198 47 39 0 127
            4466 1211 32 25 0 127
            4700 1108 17 18 0 127
            4656 1127 26 13 0 127
            4678 1162 25 25 0 127
            4613 1196 23 22 0 127
            4646 1212 14 17 0 127
            4677 1214 26 22 0 127
            4459 1276 16 16 0 127
            4622 1316 22 24 0 127
            4487 1353 59 21 0 127
            4477 1374 69 35 0 127
            4659 1387 40 40 0 127
            4549 1482 29 27 0 127
            4405 1451 23 23 0 127
            4483 1468 21 13 0 127

            #duel
            5307 3681 33 26 -127 127 
            5158 3436 33 28 -127 127 
            5848 3500 27 30 -127 127 
            6055 2324 39 24 -127 127 
            5757 3658 27 26 -127 127
            */

            //ONLY POPULATING TRINSIC ATM FOR TESTING
            /*
            1856 2636 75 28 -10 127
            1816 2664 283 231 -10 127
            2099 2782 18 25 -10 127
            1970 2895 47 32 -10 127
            1796 2696 20 67 0 127
            1800 2796 16 52 0 127
            1823 2943 11 11 -128 127
            */
            /*
            public static GuardRegion[] guardLinesRead()
            {
                guardLines.Add(new GuardRegion("1856 2636 75 28 -10 127"));
                guardLines.Add(new GuardRegion("1816 2664 283 231 -10 127"));
                guardLines.Add(new GuardRegion("2099 2782 18 25 -10 127"));
                guardLines.Add(new GuardRegion("1970 2895 47 32 -10 127"));
                guardLines.Add(new GuardRegion("1796 2696 20 67 0 127"));
                guardLines.Add(new GuardRegion("1800 2796 16 52 0 127"));
                guardLines.Add(new GuardRegion("1823 2943 11 11 -128 127"));

                return (GuardRegion[]) guardLines.ToArray(typeof(GuardRegion));
            }

            public int X
            {
                get { return m_X; }
                set { m_X = value; }
            }

            public int Y
            {
                get { return m_Y; }
                set { m_Y = value; }
            }

            public int Length
            {
                get { return m_Height; }
                set { m_Height = value; }
            }

            public int Width
            {
                get { return m_Width; }
                set { m_Width = value; }
            }


        }
        */
        // ## BEGIN - END ## // POC - GUARDLINE
    }
}