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

        // ## BEGIN - END ## // CURSOR FIXES
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
        // ## BEGIN - END ## // CURSOR FIXES
        // ## BEGIN - END ## // BUFFBAR

        // ## BEGIN - END ## // BUFFBAR
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

            if (mobile.ObjectHandlesOpened)
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

        // ## BEGIN - END ## // OLDHEALTLINES
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
        // ## BEGIN - END ## // OLDHEALTLINES

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
        // ## BEGIN - END ## // CURSOR

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
                    if (SelectedObject.LastObject == obj)
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
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.LastObject == obj)
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
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
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
                    if (SelectedObject.LastObject == obj)
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

                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.LastObject == obj)
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
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
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
                    if (SelectedObject.LastObject == obj)
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

                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {

                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.LastObject == obj)
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
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
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
                    if (SelectedObject.LastObject == obj)
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

                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {

                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 28 || GameActions.LastSpellIndexCursor == 39 || GameActions.LastSpellIndexCursor == 47 || GameActions.LastSpellIndexCursor == 50)
                {
                    //Calc _fieldEastToWest
                    if (SelectedObject.LastObject == obj)
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
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                    else if (GameCursor._fieldEastToWest is false)
                    {
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                        if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                        {
                            return true;
                        }
                    }
                }
                if (GameActions.LastSpellIndexCursor == 49 || GameActions.LastSpellIndexCursor == 55)
                {
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + -22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 0) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 88) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 66) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 88) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 0) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 66) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X - 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y + 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 22) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 22) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                    if (SelectedObject.LastObject != null && (SelectedObject.LastObject.RealScreenPosition.X + 44) == obj.RealScreenPosition.X && (SelectedObject.LastObject.RealScreenPosition.Y - 44) == obj.RealScreenPosition.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // ## BEGIN - END ## // VISUAL HELPERS

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
    }
}