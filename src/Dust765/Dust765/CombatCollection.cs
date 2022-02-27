#region license

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

using ClassicUO.Configuration;
using ClassicUO.Game;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Renderer;
using ClassicUO.IO.Resources;

using ClassicUO.Network;
using static ClassicUO.Network.NetClient;

using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

// ## BEGIN - END ## // POC - GUARDLINE
//using System.Collections;
// ## BEGIN - END ## // POC - GUARDLINE

namespace ClassicUO.Dust765.Dust765
{
    internal static class CombatCollection
    {
        //USED CONSTANTS
        // ## BEGIN - END ## // ART / HUE CHANGES
        public const ushort GOLD1_REPLACE_GRAPHIC = 0x0E73; //new - cannonball, old: skillball: 0x5740
        public const ushort GOLD2_REPLACE_GRAPHIC = 0x4202;
        public const ushort TREE_REPLACE_GRAPHIC = 0x0E59;
        public const ushort TREE_REPLACE_GRAPHIC_TILE = 0x07BD;
        public const ushort BLOCKER_REPLACE_GRAPHIC_TILE = 0x07BD;
        public const ushort BLOCKER_REPLACE_GRAPHIC_STUMP = 0x0E56;
        public const ushort BLOCKER_REPLACE_GRAPHIC_ROCK = 0x1775;
        public const ushort BRIGHT_WHITE_COLOR = 0x080A;
        public const ushort BRIGHT_PINK_COLOR = 0x0503;
        public const ushort BRIGHT_ICE_COLOR = 0x0480;
        public const ushort BRIGHT_FIRE_COLOR = 0x0496;
        public const ushort BRIGHT_POISON_COLOR = 0x0A0B;
        public const ushort BRIGHT_PARALYZE_COLOR = 0x0A13;
        // ## BEGIN - END ## // ART / HUE CHANGES
        // ## BEGIN - END ## // MACROS
        //USED VARS
        public static bool _HealOnHPChangeON = false;
        public static int _HealOnHPChangeHP = 0;
        public static bool _HarmOnSwingON = false;
        public static bool _HarmOnSwingTrigger = false;
        // ## BEGIN - END ## // MACROS

        // ## BEGIN - END ## // ART / HUE CHANGES
        //GAME\SCENES\GAMESCENEDRAWINGSORTING.CS
        public static Static GSDSFilters(Static st)
        {
            if (StaticFilters.IsTree(st.OriginalGraphic, out int index)) //INDEX?
            {
                if (ProfileManager.CurrentProfile.ColorTreeTile)
                    st.Hue = ProfileManager.CurrentProfile.TreeTileHue;
                else
                    st.RestoreOriginalHue();
            }
            if (IsBlockerTreeArt(st.OriginalGraphic) || IsBlockerStoneArt(st.OriginalGraphic))
            {
                if (ProfileManager.CurrentProfile.ColorBlockerTile)
                    st.Hue = ProfileManager.CurrentProfile.BlockerTileHue;
                else
                    st.RestoreOriginalHue();
            }
            return st;
        }

        //GAMEOBJECT\VIEWS\STATICVIEW.CS
        public static ushort ArtloaderFilters(ushort graphic)
        {
            if (StaticFilters.IsTree(graphic, out _))
            {
                if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.TreeType == 1)
                {
                    graphic = TREE_REPLACE_GRAPHIC;
                }
                else if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.TreeType == 2)
                {
                    graphic = TREE_REPLACE_GRAPHIC_TILE;
                }
            }
            if (IsBlockerTreeArt(graphic))
            {
                if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.BlockerType == 1)
                {
                    graphic = BLOCKER_REPLACE_GRAPHIC_STUMP;
                }
                else if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.BlockerType == 2)
                {
                    graphic = BLOCKER_REPLACE_GRAPHIC_TILE;
                }
            }
            if (IsBlockerStoneArt(graphic))
            {
                if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.BlockerType == 1)
                {
                    graphic = BLOCKER_REPLACE_GRAPHIC_ROCK;
                }
                else if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.BlockerType == 2)
                {
                    graphic = BLOCKER_REPLACE_GRAPHIC_TILE;
                }
            }
            return graphic;
        }

        //GAME\GAMEOBJECTS\VIEWS\GAMEEFFECTVIEW.CS
        public static ushort EnergyBoltArt(ushort graphic)
        {
            if (ProfileManager.CurrentProfile.EnergyBoltArtType == 1)
                graphic = 0x36FE;
            else if (ProfileManager.CurrentProfile.EnergyBoltArtType == 2)
                graphic = 0x2256;

            return graphic;
        }
        public static bool IsChangedEnergyBoltArt(ushort graphic)
        {
            if (ProfileManager.CurrentProfile.EnergyBoltArtType == 1 & graphic == 0x36FE)
                return true;
            else if (ProfileManager.CurrentProfile.EnergyBoltArtType == 2 & graphic == 0x2256)
                return true;

            return false;
        }
        public static ushort EnergyBoltHue(ushort hue)
        {
            if (ProfileManager.CurrentProfile.ColorEnergyBolt)
                hue = ProfileManager.CurrentProfile.EnergyBoltHue;

            if (ProfileManager.CurrentProfile.EnergyBoltNeonType == 1)
                hue = BRIGHT_WHITE_COLOR;
            else if (ProfileManager.CurrentProfile.EnergyBoltNeonType == 2)
                hue = BRIGHT_PINK_COLOR;
            else if (ProfileManager.CurrentProfile.EnergyBoltNeonType == 3)
                hue = BRIGHT_ICE_COLOR;
            else if (ProfileManager.CurrentProfile.EnergyBoltNeonType == 4)
                hue = BRIGHT_FIRE_COLOR;

            return hue;
        }

        //GAME\GAMEOBJECTS\ITEM.CS
        public static ushort GoldArt(ushort graphic)
        {
            if (ProfileManager.CurrentProfile.GoldType == 1) // skillball
            {
                graphic = GOLD1_REPLACE_GRAPHIC;
            }
            else if (ProfileManager.CurrentProfile.GoldType == 2) // prevcoin)
            {
                graphic = GOLD2_REPLACE_GRAPHIC;
            }

            return graphic;
        }
        public static ushort GoldHue(ushort hue)
        {
            if (ProfileManager.CurrentProfile.ColorGold)
                hue = ProfileManager.CurrentProfile.GoldHue;

            return hue;
        }

        //GAME\GAMEOBJECTS\VIEWS\ITEMVIEW.CS
        public static ushort StealthtHue(ushort hue)
        {
            if (ProfileManager.CurrentProfile.ColorStealth)
                hue = ProfileManager.CurrentProfile.StealthHue;

            if (ProfileManager.CurrentProfile.StealthNeonType == 1)
                hue = BRIGHT_WHITE_COLOR;
            else if (ProfileManager.CurrentProfile.StealthNeonType == 2)
                hue = BRIGHT_PINK_COLOR;
            else if (ProfileManager.CurrentProfile.StealthNeonType == 3)
                hue = BRIGHT_ICE_COLOR;
            else if (ProfileManager.CurrentProfile.StealthNeonType == 4)
                hue = BRIGHT_FIRE_COLOR;

            return hue;
        }

        [MethodImpl(256)]
        public static bool IsBlockerTreeArt(ushort g)
        {
            switch (g)
            {
                case 0x1772:
                case 0x177A:
                case 0xC2D:
                case 0xC99:
                case 0xC9B:
                case 0xC9C:
                case 0xC9D:
                case 0xCA6:
                case 0xCC4:

                    return true;
            }

            return false;
        }

        [MethodImpl(256)]
        public static bool IsBlockerStoneArt(ushort g)
        {
            switch (g)
            {
                case 0x1363:
                case 0x1364:
                case 0x1365:
                case 0x1366:
                case 0x1367:
                case 0x1368:
                case 0x1369:
                case 0x136A:
                case 0x136B:
                case 0x136C:
                case 0x136D:

                    return true;
            }

            return false;
        }

        [MethodImpl(256)]
        public static bool IsStealthArt(ushort g)
        {
            switch (g)
            {
                case 0x1E03:
                case 0x1E04:
                case 0x1E05:
                case 0x1E06:

                    return true;
            }

            return false;
        }
        // ## BEGIN - END ## // ART / HUE CHANGES

        // ## BEGIN - END ## // VISUAL HELPERS
        //GAME\GAMEOBJECTS\VIEWS\MOBILEVIEW.CS
        public static ushort OwnAuraColorByHP()
        {
            ushort color = 0x0044;

            int ww = World.Player.HitsMax;

            if (ww > 0)
            {
                ww = World.Player.Hits * 100 / ww;

                if (ww > 100)
                    ww = 100;
                else if (ww < 1)
                    ww = 0;

                World.Player.UpdateHits((byte) ww);
            }

            if (World.Player.HitsPercentage < 20)
                color = 0x0021; //red
            else if (World.Player.HitsPercentage < 40)
                color = 0x002B; //red orange
            else if (World.Player.HitsPercentage < 60)
                color = 0x0030; //orange
            else if (World.Player.HitsPercentage < 80)
                color = 0x0035; //yellow (but shows green?)
            else if (World.Player.HitsPercentage == 100)
                color = (ushort) Notoriety.GetHue(World.Player.NotorietyFlag);
            // "original colors from overhead %, < 30 0x0021, < 50 0x0030, < 80 0x0058"

            return color;
        }
        public static ushort WeaponsHue(ushort hue)
        {
            if (ProfileManager.CurrentProfile.GlowingWeaponsType == 1)
                hue = BRIGHT_WHITE_COLOR;
            else if (ProfileManager.CurrentProfile.GlowingWeaponsType == 2)
                hue = BRIGHT_PINK_COLOR;
            else if (ProfileManager.CurrentProfile.GlowingWeaponsType == 3)
                hue = BRIGHT_ICE_COLOR;
            else if (ProfileManager.CurrentProfile.GlowingWeaponsType == 4)
                hue = BRIGHT_FIRE_COLOR;
            else if (ProfileManager.CurrentProfile.GlowingWeaponsType == 5)
                hue = ProfileManager.CurrentProfile.HighlightGlowingWeaponsTypeHue;

            return hue;
        }
        public static ushort LastTargetHue(Mobile mobile, ushort hue)
        {
            if (ProfileManager.CurrentProfile.HighlightLastTargetType == 1)
                hue = BRIGHT_WHITE_COLOR;
            else if (ProfileManager.CurrentProfile.HighlightLastTargetType == 2)
                hue = BRIGHT_PINK_COLOR;
            else if (ProfileManager.CurrentProfile.HighlightLastTargetType == 3)
                hue = BRIGHT_ICE_COLOR;
            else if (ProfileManager.CurrentProfile.HighlightLastTargetType == 4)
                hue = BRIGHT_FIRE_COLOR;
            else if (ProfileManager.CurrentProfile.HighlightLastTargetType == 5)
                hue = ProfileManager.CurrentProfile.HighlightLastTargetTypeHue;

            if (mobile.IsPoisoned)
            {
                if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 1)
                    hue = BRIGHT_WHITE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 2)
                    hue = BRIGHT_PINK_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 3)
                    hue = BRIGHT_ICE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 4)
                    hue = BRIGHT_FIRE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 5)
                    hue = BRIGHT_POISON_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePoison == 6)
                    hue = ProfileManager.CurrentProfile.HighlightLastTargetTypePoisonHue;
            }

            if (mobile.IsParalyzed)
            {
                if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 1)
                    hue = BRIGHT_WHITE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 2)
                    hue = BRIGHT_PINK_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 3)
                    hue = BRIGHT_ICE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 4)
                    hue = BRIGHT_FIRE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 5)
                    hue = BRIGHT_PARALYZE_COLOR;
                else if (ProfileManager.CurrentProfile.HighlightLastTargetTypePara == 6)
                    hue = ProfileManager.CurrentProfile.HighlightLastTargetTypeParaHue;
            }

            return hue;
        }

        //GAME\GAMECURSOR.CS
        public static void UpdateSpelltime()
        {
            GameCursor._spellTime = 30 - ((Time.Ticks - GameCursor._startSpellTime) / 1000); // count down

            // ## BEGIN - END ## // CURSOR
            GameCursor._spellTimeText?.Destroy();
            GameCursor._spellTimeText = RenderedText.Create(GameCursor._spellTime.ToString(), 0x0481, style: FontStyle.BlackBorder);
            // ## BEGIN - END ## // CURSOR
        }
        public static void StartSpelltime()
        {
            GameCursor._startSpellTime = Time.Ticks;
        }

        //GAME\GAMEOBJECTS\VIEWS\ - MULTIVIEW.CS - STATICVIEW.CS - TILEVIEW.CS
        //24 - Wall of Stone
        //28 - Fire Field
        //39 - Poison Field
        //47 - Paralyze Field
        //50 - Energy Field
        //49 - Chain Lightning
        //55 - Meteor Swarm
        public static bool MultiFieldPreview(Multi obj)
        {
            if (GameCursor._spellTime >= 1)
            {
                if (GameActions.LastSpellIndexCursor == 24)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool StaticFieldPreview(Static obj)
        {
            if (GameCursor._spellTime >= 1)
            {
                if (GameActions.LastSpellIndexCursor == 24)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {

                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool LandFieldPreview(Land obj)
        {
            if (GameCursor._spellTime >= 1)
            {
                if (GameActions.LastSpellIndexCursor == 24)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {

                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {

                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool MobileFieldPreview(Mobile obj)
        {
            if (GameCursor._spellTime >= 1)
            {
                if (GameActions.LastSpellIndexCursor == 24)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {

                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {

                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.Object == obj)
                    {
                        int PlayerX = World.Player.X;
                        int PlayerY = World.Player.Y;

                        int dx = PlayerX - obj.X;
                        int dy = PlayerY - obj.Y;

                        int rx = (dx - dy) * 44;
                        int ry = (dx + dy) * 44;

                        if (rx >= 0 && ry >= 0)
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                        else if (rx >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else if (ry >= 0)
                        {
                            GameCursor._fieldEastToWest = true;
                        }
                        else
                        {
                            GameCursor._fieldEastToWest = false;
                        }
                    }

                    if (GameCursor._fieldEastToWest is true)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.Object != null && (SelectedObject.Object.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.Object.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // ## BEGIN - END ## // VISUAL HELPERS
        // ## BEGIN - END ## // CURSOR
        //GAME\GAMECURSOR.CS
        public static ushort SpellIconHue(ushort hue)
        {
            switch (TargetManager.TargetingType)
            {
                case TargetType.Neutral:
                    hue = 0x0000;  //BETTER HUE? 0x03B2
                    return hue;

                case TargetType.Harmful:
                    hue = 0x0023;
                    return hue;

                case TargetType.Beneficial:
                    hue = 0x005A;
                    return hue;
            }
            return hue;
        }

        //NETWORK\PACKETHANDLERS.CS
        public static void SpellCastFromCliloc(string text)
        {
            if (SpellDefinition.WordToTargettype.TryGetValue(text, out SpellDefinition spell))
            {
                GameActions.LastSpellIndexCursor = spell.ID;
            }
            else
            {
                //THIS IS INCASE RAZOR OR ANOTHER ASSISTANT REWRITES THE STRING

                foreach (var key in SpellDefinition.WordToTargettype.Keys)
                {
                    if (text.Contains(key)) //SPELL FOUND
                    {
                        GameActions.LastSpellIndexCursor = SpellDefinition.WordToTargettype[key].ID;

                        //break; //DONT BREAK LOOP BECAUSE OF IN NOX / IN NOX GRAV
                    }
                }
            }
        }
        // ## BEGIN - END ## // CURSOR
        // ## BEGIN - END ## // OVERHEAD / UNDERCHAR
        //GAME\GAMEOBJECTS\VIEWS\MOBILEVIEW.CS
        public static void UpdateRange(Mobile mobile)
        {
            mobile.RangeTexture?.Destroy();
            mobile.RangeTexture = RenderedText.Create($"[{mobile.Distance}]", 0x0044, 3, false);
        }
        //GAME\MANAGERS\HEALTHLINESMANAGER.CS
        public static void UpdateOverheads(Mobile mobile)
        {
            if (ProfileManager.CurrentProfile.OverheadRange)
            {
                if (mobile.Distance >= 0)
                {
                    UpdateRange(mobile);
                }
            }
        }
        // ## BEGIN - END ## // OVERHEAD / UNDERCHAR
        // ## BEGIN - END ## // OLDHEALTHLINES
        //GAME\MANAGERS\HEALTHLINESMANAGER.CS
        public static (Color hpcolor, int hpwidth, int manawidth, int staminawidth) CalcUnderlines(Mobile mobile)
        {
            Color hpcolor;

            //COLOR FOR HP BAR
            if (mobile.IsParalyzed)
                hpcolor = Color.AliceBlue;
            else if (mobile.IsYellowHits)
                hpcolor = Color.Orange;
            else if (mobile.IsPoisoned)
                hpcolor = Color.LimeGreen;
            else
                hpcolor = Color.CornflowerBlue;

            hpcolor *= HealthLinesManager._alphamodifier;

            //CALCING STATS
            int currenthp = mobile.Hits;
            int maxhp = mobile.HitsMax;
            int currentmana = mobile.Mana;
            int maxmana = mobile.ManaMax;
            int currentstam = mobile.Stamina;
            int maxstam = mobile.StaminaMax;

            if (maxhp > 0)
            {
                maxhp = currenthp * 100 / maxhp;

                if (maxhp > 100)
                    maxhp = 100;

                if (maxhp > 1)
                    maxhp = HealthLinesManager.BIGBAR_WIDTH * maxhp / 100;
            }
            if (maxmana > 0)
            {
                maxmana = currentmana * 100 / maxmana;

                if (maxmana > 100)
                    maxmana = 100;

                if (maxmana > 1)
                    maxmana = HealthLinesManager.BIGBAR_WIDTH * maxmana / 100;
            }
            if (maxstam > 0)
            {
                maxstam = currentstam * 100 / maxstam;

                if (maxstam > 100)
                    maxstam = 100;

                if (maxstam > 1)
                    maxstam = HealthLinesManager.BIGBAR_WIDTH * maxstam / 100;
            }
            return (hpcolor, maxhp, maxmana, maxstam);
        }
        // ## BEGIN - END ## // OLDHEALTHLINES
        // ## BEGIN - END ## // MISC
        //NETWORK\PACKETHANDLERS.CS
        public static void SpecialSetLastTargetCliloc(uint target)
        {
            if (ProfileManager.CurrentProfile.SpecialSetLastTargetCliloc)
            {
                TargetManager.LastTargetInfo.Serial = target;
                TargetManager.LastTargetInfo.SetEntity(target);
            }
        }
        // ## BEGIN - END ## // MISC
        // ## BEGIN - END ## // MACROS
        //GAME\SCENES\GAMESCENEINPUTHANDLER.CS
        //GAME\MANAGERS\MACROMANAGER.CS
        public static void HealOnHPChange()
        {
            if (_HealOnHPChangeON)
            {
                if (_HealOnHPChangeHP != World.Player.Hits)
                {
                    GameActions.CastSpell(29); //greater heal
                    _HealOnHPChangeON = false;
                }
            }
        }
        public static void HarmOnSwing()
        {
            if (_HarmOnSwingON)
            {
                if (_HarmOnSwingTrigger)
                {
                    GameActions.CastSpell(12); //harm
                    _HarmOnSwingTrigger = false;
                    _HarmOnSwingON = false;
                }
            }
        }
        // ## BEGIN - END ## // MACROS
        // ## BEGIN - END ## // TEXTUREMANAGER
        public static Point CalcUnderChar5(Mobile mobile)
        {
            Point p = mobile.RealScreenPosition;
            p.X += (int) mobile.Offset.X + 22 + 5;
            p.Y += (int) (mobile.Offset.Y - mobile.Offset.Z) + 22 + 5;

            p = Client.Game.Scene.Camera.WorldToScreen(p);

            return p;
        }

        public static Point CalcUnderChar(Mobile mobile)
        {
            Point p = mobile.RealScreenPosition;
            p.X += (int) mobile.Offset.X + 22;
            p.Y += (int) (mobile.Offset.Y - mobile.Offset.Z) + 22;

            p = Client.Game.Scene.Camera.WorldToScreen(p);

            return p;
        }
        public static Point CalcOverChar(Mobile mobile)
        {
            Point p = mobile.RealScreenPosition;
            p.X += (int) mobile.Offset.X + 22;
            p.Y += (int) (mobile.Offset.Y - mobile.Offset.Z) + 22;

            AnimationsLoader.Instance.GetAnimationDimensions
                            (
                                mobile.AnimIndex,
                                mobile.GetGraphicForAnimation(),
                                /*(byte) m.GetDirectionForAnimation()*/
                                0,
                                /*Mobile.GetGroupForAnimation(m, isParent:true)*/
                                0,
                                mobile.IsMounted,
                                /*(byte) m.AnimIndex*/
                                0,
                                out int centerX,
                                out int centerY,
                                out int width,
                                out int height
                            );

            Point p1 = p;

            p1.X = (int) (mobile.RealScreenPosition.X + mobile.Offset.X + 22);
            p1.Y = (int) (mobile.RealScreenPosition.Y + (mobile.Offset.Y - mobile.Offset.Z) - (height + centerY + 8 + 22) + (mobile.IsGargoyle && mobile.IsFlying ? -22 : !mobile.IsMounted ? 22 : 0));

            if (mobile.ObjectHandlesStatus == ObjectHandlesStatus.DISPLAYING)
            {
                p1.Y -= Constants.OBJECT_HANDLES_GUMP_HEIGHT + 5;
            }

            /*
            if (!(p1.X < 0 || p1.X > screenW - mobile.HitsTexture.Width || p1.Y < 0 || p1.Y > screenH))
            {
                return p1;
            }
            */

            p1 = Client.Game.Scene.Camera.WorldToScreen(p1);

            return p1;
        }
        // ## BEGIN - END ## // TEXTUREMANAGER
        // ## BEGIN - END ## // AUTOLOOT
        //NETWORK\PACKETHANDLERS.CS
        public static void SetLootFlag(uint source, ushort hue)
        {
            Item item = World.Items.Get(source);
            if (item != null)
            {
                item.LootFlag = hue;
            }
        }
        // ## BEGIN - END ## // AUTOLOOT
        // ## BEGIN - END ## // UNUSED
        //GAME\DATA\STATICFILTERS.CS
        [MethodImpl(256)]
        public static bool IsClassicBoatSailArt(ushort g)
        {
            switch (g)
            {
                case 0x3E58:
                case 0x3E59:
                case 0x3E5B:
                case 0x3E5C:
                case 0x3E6A:
                case 0x3E6B:
                case 0x3E6D:
                case 0x3E6E:
                case 0x3E70:
                case 0x3E71:
                case 0x3E73:
                case 0x3E74:
                case 0x3EC9:
                case 0x3ECA:
                case 0x3ECC:
                case 0x3ECD:
                case 0x3ECE:
                case 0x3ECF:
                case 0x3ED1:
                case 0x3ED2:
                case 0x3EDC:
                case 0x3EDE:
                case 0x3EDF:
                case 0x3EE0:
                case 0x3EE1:
                case 0x3EE3:

                    return true;
            }

            return false;
        }
        [MethodImpl(256)]
        public static bool IsClassicBoatMastArt(ushort g)
        {
            switch (g)
            {
                case 0x3E57:
                case 0x3E5A:
                case 0x3E6C:
                case 0x3E72:
                case 0x3Ec8:
                case 0x3ECB:
                case 0x3ED0:
                case 0x3EDD:
                case 0x3EE2:

                    return true;
            }

            return false;
        }
        [MethodImpl(256)]
        public static bool IsDungeonTrapArt(ushort g)
        {
            switch (g)
            {
                case 0x10F5:
                case 0x10FC:
                case 0x1103:
                case 0x1108:
                case 0x110F:
                case 0x1116:
                case 0x111B:
                case 0x1125:
                case 0x112B:
                case 0x112F:
                case 0x1133:
                case 0x113A:
                case 0x1140:
                case 0x1145:
                case 0x114B:
                case 0x1193:
                case 0x119A:
                case 0x11A0:
                case 0x11A6:
                case 0x11AC:
                case 0x11B1:
                case 0x11C0:

                    return true;
            }

            return false;
        }
        // ## BEGIN - END ## // UNUSED
        // ## BEGIN - END ## // OUTLANDS
        /*
        //GAME/MAP/CHUNK.CS
        public static bool InfernoBridgeSolver(ushort x, ushort y)
        {
            if (ProfileManager.CurrentProfile.InfernoBridge)
            {
                //INFERNO BRIDGE 1
                if (x == 5957 && y == 2016)
                    return true;
                if (x == 5956 && y == 2016)
                    return true;
                if (x == 5955 && y == 2017)
                    return true;
                if (x == 5954 && y == 2017)
                    return true;
                if (x == 5953 && y == 2016)
                    return true;
                if (x == 5952 && y == 2015)
                    return true;
                if (x == 5951 && y == 2016)
                    return true;
                if (x == 5950 && y == 2017)
                    return true;
                if (x == 5949 && y == 2017)
                    return true;
                if (x == 5948 && y == 2016)
                    return true;
                if (x == 5947 && y == 2016)
                    return true;
                //INFERNO BRIDGE 2
                if (x == 5929 && y == 2016)
                    return true;
                if (x == 5928 && y == 2016)
                    return true;
                if (x == 5927 && y == 2015)
                    return true;
                if (x == 5926 && y == 2015)
                    return true;
                if (x == 5925 && y == 2016)
                    return true;
                if (x == 5924 && y == 2017)
                    return true;
                if (x == 5923 && y == 2016)
                    return true;
                if (x == 5922 && y == 2015)
                    return true;
                if (x == 5921 && y == 2015)
                    return true;
                if (x == 5920 && y == 2016)
                    return true;
            }
            return false;
        }

        //
        public static void SetSummonTime(string text, uint serial)
        {
            String minutes = null;
            String seconds = null;
            String[] arraystring = null;
            String str = text.Replace("(summoned ", "").Replace(")", "");

            if (str.Contains(" "))
            {
                arraystring = str.Split(' ');

                minutes = arraystring[0].Replace("m", "");
                seconds = arraystring[1].Replace("s", "");
            }
            else
            {
                if (str.Contains("m"))
                {
                    minutes = str.Replace("m", "");
                }
                else
                {
                    seconds = str.Replace("s", "");
                }
            }

            int intm = 0;
            Int32.TryParse(minutes, out intm);
            int ints = 0;
            Int32.TryParse(seconds, out ints);
            int time = (intm * 60) + ints;

            Mobile targetmobile = World.Mobiles.Get(serial);

            targetmobile.SummonTimeTick = Time.Ticks;
            targetmobile.SummonTime = time;

        }
        public static void GetPeaceTime(uint serial)
        {
            Mobile targetmobile = World.Mobiles.Get(serial);

            if (targetmobile.PeaceTimeTick == 0)
                Socket.Send(new PClickRequest(targetmobile));

            targetmobile.PeaceTimeTick = Time.Ticks;
        }
        public static void SetPeaceTime(string text, uint serial)
        {
            if (text.Equals("*pacified*"))
                return;

            String minutes = null;
            String seconds = null;
            String[] arraystring = null;
            String str = text.Replace("*pacified ", "").Replace("*", "");

            if (str.Contains(" "))
            {
                arraystring = str.Split(' ');

                minutes = arraystring[0].Replace("m", "");
                seconds = arraystring[1].Replace("s", "");
            }
            else
            {
                if (str.Contains("m"))
                {
                    minutes = str.Replace("m", "");
                }
                else
                {
                    seconds = str.Replace("s", "");
                }
            }

            int intm = 0;
            Int32.TryParse(minutes, out intm);
            int ints = 0;
            Int32.TryParse(seconds, out ints);
            int time = (intm * 60) + ints;

            Mobile targetmobile = World.Mobiles.Get(serial);

            targetmobile.PeaceTimeTick = Time.Ticks;
            targetmobile.PeaceTime = time;

        }
        public static void SetHamstrungTime(uint source)
        {
            Mobile targetmobile = World.Mobiles.Get(source);
            if (targetmobile != null && targetmobile != World.Player)
            {
                targetmobile.HamstrungTimeTick = Time.Ticks;
                targetmobile.HamstrungTime = ProfileManager.CurrentProfile.MobileHamstrungTimeCooldown;
            }
        }
        public static void UpdateSummonTime(Mobile mobile)
        {
            if (Time.Ticks >= (mobile.SummonTimeTick + 1000))
            {
                mobile.SummonTime = mobile.SummonTime - 1;
                mobile.SummonTimeTick = Time.Ticks;
            }

            ushort color = 0x0044;

            if (mobile.SummonTime < 20)
                color = 0x0021;
            else if (mobile.SummonTime < 40)
                color = 0x0030;
            else if (mobile.SummonTime < 60)
                color = 0x0035;

            mobile.SummonTexture?.Destroy();
            mobile.SummonTexture = RenderedText.Create($"[{mobile.SummonTime}s]", color, 3, false);
        }
        public static void UpdatePeaceTime(Mobile mobile)
        {
            if (Time.Ticks >= (mobile.PeaceTimeTick + 1000))
            {
                if (mobile.PeaceTime > 0)
                    mobile.PeaceTime = mobile.PeaceTime - 1;

                mobile.PeaceTimeTick = Time.Ticks;
            }

            ushort color = 0x0044;

            if (mobile.PeaceTime < 10)
                color = 0x0021;
            else if (mobile.PeaceTime < 20)
                color = 0x0030;
            else if (mobile.PeaceTime < 30)
                color = 0x0035;

            mobile.PeaceTexture?.Destroy();
            mobile.PeaceTexture = RenderedText.Create($"[{mobile.PeaceTime}s]", color, 3, false);
        }
        public static void UpdateHamstrung(Mobile mobile)
        {
            if (mobile == null)
                return;

            if (Time.Ticks >= (mobile.HamstrungTimeTick + 100))
            {
                if (mobile.HamstrungTime >= 100)
                    mobile.HamstrungTime = mobile.HamstrungTime - 100;
                else if (mobile.HamstrungTime > 0 && mobile.HamstrungTime < 100)
                    mobile.HamstrungTime = 0;

                mobile.HamstrungTimeTick = Time.Ticks;
            }

            mobile.HamstrungTexture?.Destroy();
            mobile.HamstrungTexture = RenderedText.Create($"[{mobile.HamstrungTime / 100}]", 0x0021, 3, false);
        }
        */
        // ## BEGIN - END ## // OUTLANDS
        // ## BEGIN - END ## // POC - GUARDLINE
        /*
        class GuardRegion
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