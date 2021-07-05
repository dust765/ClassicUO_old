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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ClassicUO.Game;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Gumps;
using ClassicUO.Utility;
using ClassicUO.Utility.Logging;
// ## BEGIN - END ## // MACROS
using ClassicUO.Dust765.External;
// ## BEGIN - END ## // MACROS
using Microsoft.Xna.Framework;
using TinyJson;

namespace ClassicUO.Configuration
{
    [MatchSnakeCase]
    internal sealed class Profile
    {
        [JsonIgnore] public string Username { get; set; }
        [JsonIgnore] public string ServerName { get; set; }
        [JsonIgnore] public string CharacterName { get; set; }

        // sounds
        public bool EnableSound { get; set; } = true;
        public int SoundVolume { get; set; } = 100;
        public bool EnableMusic { get; set; } = true;
        public int MusicVolume { get; set; } = 100;
        public bool EnableFootstepsSound { get; set; } = true;
        public bool EnableCombatMusic { get; set; } = true;
        public bool ReproduceSoundsInBackground { get; set; }

        // fonts and speech
        public byte ChatFont { get; set; } = 1;
        public int SpeechDelay { get; set; } = 100;
        public bool ScaleSpeechDelay { get; set; } = true;
        public bool SaveJournalToFile { get; set; } = true;
        public bool ForceUnicodeJournal { get; set; }

        // hues
        public ushort SpeechHue { get; set; } = 0x02B2;
        public ushort WhisperHue { get; set; } = 0x0033;
        public ushort EmoteHue { get; set; } = 0x0021;
        public ushort YellHue { get; set; } = 0x0021;
        public ushort PartyMessageHue { get; set; } = 0x0044;
        public ushort GuildMessageHue { get; set; } = 0x0044;
        public ushort AllyMessageHue { get; set; } = 0x0057;
        public ushort ChatMessageHue { get; set; } = 0x0256;
        public ushort InnocentHue { get; set; } = 0x005A;
        public ushort PartyAuraHue { get; set; } = 0x0044;
        public ushort FriendHue { get; set; } = 0x0044;
        public ushort CriminalHue { get; set; } = 0x03B2;
        public ushort CanAttackHue { get; set; } = 0x03B2;
        public ushort EnemyHue { get; set; } = 0x0031;
        public ushort MurdererHue { get; set; } = 0x0023;
        public ushort BeneficHue { get; set; } = 0x0059;
        public ushort HarmfulHue { get; set; } = 0x0020;
        public ushort NeutralHue { get; set; } = 0x03B1;
        public bool EnabledSpellHue { get; set; }
        public bool EnabledSpellFormat { get; set; }
        public string SpellDisplayFormat { get; set; } = "{power} [{spell}]";
        public ushort PoisonHue { get; set; } = 0x0044;
        public ushort ParalyzedHue { get; set; } = 0x014C;
        public ushort InvulnerableHue { get; set; } = 0x0030;

        // visual
        public bool EnabledCriminalActionQuery { get; set; } = true;
        public bool EnabledBeneficialCriminalActionQuery { get; set; } = false;
        public bool EnableStatReport { get; set; } = true;
        public bool EnableSkillReport { get; set; } = true;
        public bool UseOldStatusGump { get; set; }
        public int BackpackStyle { get; set; }
        public bool HighlightGameObjects { get; set; }
        public bool HighlightMobilesByFlags { get; set; } = true;
        public bool ShowMobilesHP { get; set; }
        public int MobileHPType { get; set; }     // 0 = %, 1 = line, 2 = both
        public int MobileHPShowWhen { get; set; } // 0 = Always, 1 - <100%
        public bool DrawRoofs { get; set; } = true;
        public bool TreeToStumps { get; set; }
        public bool EnableCaveBorder { get; set; }
        public bool HideVegetation { get; set; }
        public int FieldsType { get; set; } // 0 = normal, 1 = static, 2 = tile
        public bool NoColorObjectsOutOfRange { get; set; }
        public bool UseCircleOfTransparency { get; set; }
        public int CircleOfTransparencyRadius { get; set; } = Constants.MAX_CIRCLE_OF_TRANSPARENCY_RADIUS / 2;
        public int CircleOfTransparencyType { get; set; } // 0 = normal, 1 = like original client
        public int VendorGumpHeight { get; set; } = 60;   //original vendor gump size
        public float DefaultScale { get; set; } = 1.0f;
        public bool EnableMousewheelScaleZoom { get; set; }
        public bool SaveScaleAfterClose { get; set; }
        public bool RestoreScaleAfterUnpressCtrl { get; set; }
        public bool BandageSelfOld { get; set; } = true;
        public bool EnableDeathScreen { get; set; } = true;
        public bool EnableBlackWhiteEffect { get; set; } = true;

        // tooltip
        public bool UseTooltip { get; set; } = true;
        public ushort TooltipTextHue { get; set; } = 0xFFFF;
        public int TooltipDelayBeforeDisplay { get; set; } = 250;
        public int TooltipDisplayZoom { get; set; } = 100;
        public int TooltipBackgroundOpacity { get; set; } = 70;
        public byte TooltipFont { get; set; } = 1;

        // movements
        public bool EnablePathfind { get; set; }
        public bool UseShiftToPathfind { get; set; }
        public bool AlwaysRun { get; set; }
        public bool AlwaysRunUnlessHidden { get; set; }
        public bool SmoothMovements { get; set; } = true;
        public bool HoldDownKeyTab { get; set; } = true;
        public bool HoldShiftForContext { get; set; } = false;
        public bool HoldShiftToSplitStack { get; set; } = false;

        // general
        public Point WindowClientBounds { get; set; } = new Point(600, 480);
        public Point ContainerDefaultPosition { get; set; } = new Point(24, 24);
        public Point GameWindowPosition { get; set; } = new Point(10, 10);
        public bool GameWindowLock { get; set; }
        public bool GameWindowFullSize { get; set; }
        public bool WindowBorderless { get; set; } = false;
        public Point GameWindowSize { get; set; } = new Point(600, 480);
        public Point TopbarGumpPosition { get; set; } = new Point(0, 0);
        public bool TopbarGumpIsMinimized { get; set; }
        public bool TopbarGumpIsDisabled { get; set; }
        public bool UseAlternativeLights { get; set; }
        public bool UseCustomLightLevel { get; set; }
        public byte LightLevel { get; set; }
        public bool UseColoredLights { get; set; } = true;
        public bool UseDarkNights { get; set; }
        public int CloseHealthBarType { get; set; } // 0 = none, 1 == not exists, 2 == is dead
        public bool ActivateChatAfterEnter { get; set; }
        public bool ActivateChatAdditionalButtons { get; set; } = true;
        public bool ActivateChatShiftEnterSupport { get; set; } = true;
        public bool UseObjectsFading { get; set; } = true;
        public bool HoldDownKeyAltToCloseAnchored { get; set; } = true;
        public bool CloseAllAnchoredGumpsInGroupWithRightClick { get; set; } = false;
        public bool HoldAltToMoveGumps { get; set; }

        public bool HideScreenshotStoredInMessage { get; set; }

        // Experimental
        public bool CastSpellsByOneClick { get; set; }
        public bool BuffBarTime { get; set; }
        public bool AutoOpenDoors { get; set; }
        public bool SmoothDoors { get; set; }
        public bool AutoOpenCorpses { get; set; }
        public int AutoOpenCorpseRange { get; set; } = 2;
        public int CorpseOpenOptions { get; set; } = 3;
        public bool SkipEmptyCorpse { get; set; }
        public bool DisableDefaultHotkeys { get; set; }
        public bool DisableArrowBtn { get; set; }
        public bool DisableTabBtn { get; set; }
        public bool DisableCtrlQWBtn { get; set; }
        public bool DisableAutoMove { get; set; }
        public bool EnableDragSelect { get; set; }
        public int DragSelectModifierKey { get; set; } // 0 = none, 1 = control, 2 = shift
        public bool OverrideContainerLocation { get; set; }

        public int OverrideContainerLocationSetting { get; set; } // 0 = container position, 1 = top right of screen, 2 = last dragged position, 3 = remember every container

        public Point OverrideContainerLocationPosition { get; set; } = new Point(200, 200);
        public bool DragSelectHumanoidsOnly { get; set; }
        public NameOverheadTypeAllowed NameOverheadTypeAllowed { get; set; } = NameOverheadTypeAllowed.All;
        public bool NameOverheadToggled { get; set; } = false;
        public bool ShowTargetRangeIndicator { get; set; }
        public bool PartyInviteGump { get; set; }
        public bool CustomBarsToggled { get; set; }
        public bool CBBlackBGToggled { get; set; }

        public bool ShowInfoBar { get; set; }
        public int InfoBarHighlightType { get; set; } // 0 = text colour changes, 1 = underline


        public InfoBarItem[] InfoBarItems { get; set; } // [FILE_FIX] TODO: REMOVE IT
        public Macro[] Macros { get; set; }             // [FILE_FIX] TODO: REMOVE IT


        public bool CounterBarEnabled { get; set; }
        public bool CounterBarHighlightOnUse { get; set; }
        public bool CounterBarHighlightOnAmount { get; set; }
        public bool CounterBarDisplayAbbreviatedAmount { get; set; }
        public int CounterBarAbbreviatedAmount { get; set; } = 1000;
        public int CounterBarHighlightAmount { get; set; } = 5;
        public int CounterBarCellSize { get; set; } = 40;
        public int CounterBarRows { get; set; } = 1;
        public int CounterBarColumns { get; set; } = 1;

        public bool ShowSkillsChangedMessage { get; set; } = true;
        public int ShowSkillsChangedDeltaValue { get; set; } = 1;
        public bool ShowStatsChangedMessage { get; set; } = true;


        public int FilterType { get; set; } = 0;
        public bool ShadowsEnabled { get; set; } = true;
        public bool ShadowsStatics { get; set; } = true;
        public int TerrainShadowsLevel { get; set; } = 15;
        public int AuraUnderFeetType { get; set; } // 0 = NO, 1 = in warmode, 2 = ctrl+shift, 3 = always
        public bool AuraOnMouse { get; set; } = true;

        public bool PartyAura { get; set; }

        public bool UseXBR { get; set; } = true;

        public bool HideChatGradient { get; set; } = false;

        public bool StandardSkillsGump { get; set; } = true;

        public bool ShowNewMobileNameIncoming { get; set; } = true;
        public bool ShowNewCorpseNameIncoming { get; set; } = true;

        public uint GrabBagSerial { get; set; }

        public int GridLootType { get; set; } // 0 = none, 1 = only grid, 2 = both

        public bool ReduceFPSWhenInactive { get; set; } = true;

        public bool OverrideAllFonts { get; set; }
        public bool OverrideAllFontsIsUnicode { get; set; } = true;

        public bool SallosEasyGrab { get; set; }

        public bool JournalDarkMode { get; set; }

        public byte ContainersScale { get; set; } = 100;

        public bool ScaleItemsInsideContainers { get; set; }

        public bool DoubleClickToLootInsideContainers { get; set; }

        public bool UseLargeContainerGumps { get; set; } = false;

        public bool RelativeDragAndDropItems { get; set; }

        public bool HighlightContainerWhenSelected { get; set; }

        public bool ShowHouseContent { get; set; }
        public bool SaveHealthbars { get; set; }
        public bool TextFading { get; set; } = true;

        public bool UseSmoothBoatMovement { get; set; } = false;

        public bool IgnoreStaminaCheck { get; set; } = false;

        // ## BEGIN - END ## // BASICSETUP
        // ## BEGIN - END ## // ART / HUE CHANGES
        public bool ColorStealth { get; set; }
        public ushort StealthHue { get; set; } = 0x0044;
        public int StealthNeonType { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire
        public int GoldType { get; set; } = 0; // 0 = normal, 1 = skillball, 2 = prevcoin
        public bool ColorGold { get; set; }
        public ushort GoldHue { get; set; } = 0x0044;
        public bool ColorEnergyBolt { get; set; }
        public ushort EnergyBoltHue { get; set; } = 0x0044;
        public int EnergyBoltNeonType { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire
        public int EnergyBoltArtType { get; set; } = 0; // 0 = normal, 1 = explo ball, 2 = small bag ball
        public int BlockerType { get; set; } = 0; // 0 = off, 1 = stump, 2 = tile
        public bool ColorBlockerTile { get; set; }
        public ushort BlockerTileHue { get; set; } = 0x0044;
        public int TreeType { get; set; } = 0; // 0 = off, 1 = stump, 2 = tile
        public bool ColorTreeTile { get; set; }
        public ushort TreeTileHue { get; set; } = 0x0044;
        // ## BEGIN - END ## // ART / HUE CHANGES
        // ## BEGIN - END ## // VISUAL HELPERS
        public bool HighlightTileAtRange { get; set; }
        public int HighlightTileAtRangeRange { get; set; }
        public ushort HighlightTileRangeHue { get; set; } = 0x0044;
        public bool HighlightTileAtRangeSpell { get; set; }
        public int HighlightTileAtRangeRangeSpell { get; set; }
        public ushort HighlightTileRangeHueSpell { get; set; } = 0x0044;
        public int GlowingWeaponsType { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire, 5 = custom
        public ushort HighlightGlowingWeaponsTypeHue { get; set; } = 0x0044;
        public bool PreviewFields { get; set; }
        public bool OwnAuraByHP { get; set; }
        public int HighlightLastTargetType { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire, 5 = custom
        public ushort HighlightLastTargetTypeHue { get; set; } = 0x0044;
        public int HighlightLastTargetTypePoison { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire, 5 = special, 6 = custom
        public ushort HighlightLastTargetTypePoisonHue { get; set; } = 0x0044;
        public int HighlightLastTargetTypePara { get; set; } = 0; // 0 = off, 1 = white, 2 = pink, 3 = ice, 4 = fire, 5 = special, 6 = custom
        public ushort HighlightLastTargetTypeParaHue { get; set; } = 0x0044;
        // ## BEGIN - END ## // VISUAL HELPERS
        // ## BEGIN - END ## // HEALTHBAR
        public bool HighlightHealthBarByState { get; set; } //## Highlights mobiles healthbars if they're poisoned or para
        public bool HighlightLastTargetHealthBarOutline { get; set; } //## Highlights last target healthbar if they're poisoned or invul
        public bool FlashingHealthbarOutlineSelf { get; set; } = false;
        public bool FlashingHealthbarOutlineParty { get; set; } = false;
        public bool FlashingHealthbarOutlineGreen { get; set; } = false;
        public bool FlashingHealthbarOutlineOrange { get; set; } = false;
        public bool FlashingHealthbarOutlineAll { get; set; } = false;
        public bool FlashingHealthbarNegativeOnly { get; set; } = false;
        public int FlashingHealthbarTreshold { get; set; } = 10;
        // ## BEGIN - END ## // HEALTHBAR
        // ## BEGIN - END ## // CURSOR
        public Point SpellOnCursorOffset { get; set; } = new Point(25, 30);
        public bool SpellOnCursor { get; set; }
        // ## BEGIN - END ## // CURSOR
        // ## BEGIN - END ## // OVERHEAD / UNDERCHAR
        public bool OverheadRange { get; set; }
        // ## BEGIN - END ## // OVERHEAD / UNDERCHAR
        // ## BEGIN - END ## // OLDHEALTLINES
        public bool MultipleUnderlinesSelfParty { get; set; }
        public bool MultipleUnderlinesSelfPartyBigBars { get; set; }
        public int MultipleUnderlinesSelfPartyTransparency { get; set; } = 10;
        public bool UseOldHealthBars { get; set; } = false;
        // ## BEGIN - END ## // OLDHEALTLINES
        // ## BEGIN - END ## // MISC
        public bool SpecialSetLastTargetCliloc { get; set; } = false;
        public string SpecialSetLastTargetClilocText { get; set; } = "- Target -";
        public bool BlockWoS { get; set; } = false;
        public bool BlockWoSFelOnly { get; set; } = false;
        public uint BlockWoSArt { get; set; } = 1872;
        public bool BlockWoSArtForceAoS { get; set; } = false;
        public bool BlackOutlineStatics { get; set; } = false;
        // ## BEGIN - END ## // MISC
        // ## BEGIN - END ## // MACROS
        public int LastTargetRange { get; set; }
        public bool Journal2DarkMode { get; set; }
        public bool ShowJournal2Client { get; set; } = true;
        public bool ShowJournal2Objects { get; set; } = true;
        public bool ShowJournal2System { get; set; } = true;
        public bool ShowJournal2GuildAlly { get; set; } = true;
        // ## BEGIN - END ## // MACROS
        // ## BEGIN - END ## // MISC2
        public bool WireFrameView { get; set; } = false;
        public bool HueImpassableView { get; set; } = false;
        public ushort HueImpassableViewHue { get; set; } = 0x0044;
        public bool TransparentHousesEnabled { get; set; } = false;
        public int TransparentHousesZ { get; set; }
        public int TransparentHousesTransparency { get; set; }
        public bool InvisibleHousesEnabled { get; set; } = false;
        public int InvisibleHousesZ { get; set; }
        public bool IgnoreCoTEnabled { get; set; } = false;
        public bool ShowDeathOnWorldmap { get; set; } = false;
        // ## BEGIN - END ## // MISC2
        // ## BEGIN - END ## // NAMEOVERHEAD
        public bool ShowHPLineInNOH { get; set; } = false;
        public bool NOH_cbcorpses { get; set; } = false;
        public bool NOH_cbitems { get; set; } = false;
        public bool NOH_cbmobiles { get; set; } = false;
        public bool NOH_cbhumanMobilesOnly { get; set; } = false;
        public bool NOH_cbnotoall { get; set; } = false;
        public bool NOH_cbnotoblue { get; set; } = false;
        public bool NOH_cbnotored { get; set; } = false;
        public bool NOH_cbnotoorange { get; set; } = false;
        public bool NOH_cbnotocriminal { get; set; } = false;
        public bool NOH_cbnotoally { get; set; } = false;
        // ## BEGIN - END ## // NAMEOVERHEAD
        // ## BEGIN - END ## // UI/GUMPS
        public bool UOClassicCombatLTBar { get; set; } = false;
        public Point UOClassicCombatLTBarLocation { get; set; } = new Point(25, 25);
        public bool UOClassicCombatLTBar_Locked { get; set; } = false;
        public Point BandageGumpOffset { get; set; } = new Point(0, 0);
        public bool BandageGump { get; set; }
        // ## BEGIN - END ## // UI/GUMPS
        // ## BEGIN - END ## // TEXTUREMANAGER
        public bool TextureManagerEnabled { get; set; } = false;
        public bool TextureManagerHalos { get; set; } // Halos
        public bool TextureManagerHumansOnly { get; set; } = false;
        public bool TextureManagerPurple { get; set; } = true;
        public bool TextureManagerGreen { get; set; } = true;
        public bool TextureManagerRed { get; set; } = true;
        public bool TextureManagerOrange { get; set; } = true;
        public bool TextureManagerBlue { get; set; } = true;
        public bool TextureManagerArrows { get; set; } // Arrows
        public bool TextureManagerHumansOnlyArrows { get; set; } = false;
        public bool TextureManagerPurpleArrows { get; set; } = true;
        public bool TextureManagerGreenArrows { get; set; } = true;
        public bool TextureManagerRedArrows { get; set; } = true;
        public bool TextureManagerOrangeArrows { get; set; } = true;
        public bool TextureManagerBlueArrows { get; set; } = true;
        // ## BEGIN - END ## // TEXTUREMANAGER
        // ## BEGIN - END ## // LINES
        public bool UOClassicCombatLines { get; set; } = false;
        public Point UOClassicCombatLinesLocation { get; set; } = new Point(25, 25);
        public bool UOClassicCombatLines_ToggleLastTarget { get; set; } = false;
        public bool UOClassicCombatLines_ToggleHuntingMmode { get; set; } = false;
        public bool UOClassicCombatLines_ToggleHMBlue { get; set; } = false;
        public bool UOClassicCombatLines_ToggleHMRed { get; set; } = false;
        public bool UOClassicCombatLines_ToggleHMOrange { get; set; } = false;
        public bool UOClassicCombatLines_ToggleHMCriminal { get; set; } = false;
        // ## BEGIN - END ## // LINES
        // ## BEGIN - END ## // AUTOLOOT
        public bool UOClassicCombatAL { get; set; } = false;
        public Point UOClassicCombatALLocation { get; set; } = new Point(25, 25);
        public bool UOClassicCombatAL_EnableAL { get; set; } = false;
        public bool UOClassicCombatAL_EnableSL { get; set; } = false;
        public bool UOClassicCombatAL_EnableALLow { get; set; } = false;
        public bool UOClassicCombatAL_EnableSLLow { get; set; } = false;
        public uint UOClassicCombatAL_LootDelay { get; set; } = 500;
        public uint UOClassicCombatAL_PurgeDelay { get; set; } = 10000;
        public uint UOClassicCombatAL_QueueSpeed { get; set; } = 100;
        public bool UOClassicCombatAL_EnableGridLootColoring { get; set; } = false;
        public bool UOClassicCombatAL_EnableLootAboveID { get; set; } = false;
        public uint UOClassicCombatAL_LootAboveID { get; set; } = 22400;
        public uint UOClassicCombatAL_SL_Gray { get; set; } = 946;
        public uint UOClassicCombatAL_SL_Blue { get; set; } = 86;
        public uint UOClassicCombatAL_SL_Green { get; set; } = 63;
        public uint UOClassicCombatAL_SL_Red { get; set; } = 34;
        // ## BEGIN - END ## // AUTOLOOT
        // ## BEGIN - END ## // BUFFBAR
        public bool UOClassicCombatBuffbar { get; set; } = false;
        public Point UOClassicCombatBuffbarLocation { get; set; } = new Point(25, 25);
        public bool UOClassicCombatBuffbar_SwingEnabled { get; set; } = false;
        public bool UOClassicCombatBuffbar_DoDEnabled { get; set; } = false;
        public bool UOClassicCombatBuffbar_GotDEnabled { get; set; } = false;
        public bool UOClassicCombatBuffbar_Locked { get; set; } = true;
        // ## BEGIN - END ## // BUFFBAR
        // ## BEGIN - END ## // UCCSETTINGS
        public uint UOClassicCombatSelf_DisarmedCooldown { get; set; } = 5000;
        public uint UOClassicCombatSelf_DisarmStrikeCooldown { get; set; } = 30000;
        public uint UOClassicCombatSelf_DisarmAttemptCooldown { get; set; } = 15000;
        // ## BEGIN - END ## // UCCSETTINGS
        // ## BEGIN - END ## // SELF
        public bool UOClassicCombatSelf { get; set; } = false;
        public Point UOClassicCombatSelfLocation { get; set; } = new Point(25, 25);
        public bool UOClassicCombatSelf_AutoBandage { get; set; } = true;
        public bool UOClassicCombatSelf_AutoPouche { get; set; } = true;
        public bool UOClassicCombatSelf_AutoCurepot { get; set; } = true;
        public bool UOClassicCombatSelf_AutoHealpot { get; set; } = true;
        public bool UOClassicCombatSelf_AutoRefreshpot { get; set; } = true;
        public uint UOClassicCombatSelf_ActionCooldown { get; set; } = 600;
        public uint UOClassicCombatSelf_PoucheCooldown { get; set; } = 0;
        public uint UOClassicCombatSelf_CurepotCooldown { get; set; } = 0;
        public uint UOClassicCombatSelf_HealpotCooldown { get; set; } = 10000;
        public uint UOClassicCombatSelf_RefreshpotCooldown { get; set; } = 0;
        public uint UOClassicCombatSelf_WaitForTarget { get; set; } = 1000;
        public bool UOClassicCombatSelf_RearmAfterPot { get; set; } = true;
        public bool UOClassicCombatSelf_IsDuelingOrTankMage { get; set; } = true;
        public bool UOClassicCombatSelf_AutoRearmAfterDisarmed { get; set; } = true;
        public uint UOClassicCombatSelf_AutoRearmAfterDisarmedCooldown { get; set; } = 5000;
        public uint UOClassicCombatSelf_BandiesHPTreshold { get; set; } = 1;
        public bool UOClassicCombatSelf_BandiesPoison { get; set; } = true;
        public uint UOClassicCombatSelf_CurepotHPTreshold { get; set; } = 10;
        public uint UOClassicCombatSelf_HealpotHPTreshold { get; set; } = 20;
        public uint UOClassicCombatSelf_RefreshpotStamTreshold { get; set; } = 15;
        public bool UOClassicCombatSelf_DisarmStrike { get; set; } = true;
        public bool UOClassicCombatSelf_ConsiderHidden { get; set; } = true;
        public bool UOClassicCombatSelf_ConsiderSpells { get; set; } = true;
        public uint UOClassicCombatSelf_StrengthPotCooldown { get; set; } = 120000;
        public uint UOClassicCombatSelf_DexPotCooldown { get; set; } = 120000;
        public int UOClassicCombatSelf_MinRNG { get; set; } = 50;
        public int UOClassicCombatSelf_MaxRNG { get; set; } = 150;
        public bool UOClassicCombatSelf_ClilocTriggers { get; set; } = false;
        public bool UOClassicCombatSelf_MacroTriggers { get; set; } = false;
        // ## BEGIN - END ## // SELF
        // ## BEGIN - END ## // ADVMACROS
        public Point PullEnemyBars { get; set; } = new Point(1630, 214);
        public Point PullEnemyBarsFinalLocation { get; set; } = new Point(1790, 0); // X difference needs to be 120 to get bars next to one another
        public Point PullFriendlyBars { get; set; } = new Point(1550, 214);
        public Point PullFriendlyBarsFinalLocation { get; set; } = new Point(1670, 0); // X difference needs to be 120 to get bars next to one another
        public Point PullPartyAllyBars { get; set; } = new Point(1470, 214);
        public Point PullPartyAllyBarsFinalLocation { get; set; } = new Point(1550, 0); // X difference needs to be 120 to get bars next to one another
        public uint CustomSerial { get; set; }
        public uint Mimic_PlayerSerial { get; set; }
        // ## BEGIN - END ## // ADVMACROS
        // ## BEGIN - END ## // AUTOMATIONS
        public bool AutoWorldmapMarker { get; set; }
        // ## BEGIN - END ## // AUTOMATIONS
        // ## BEGIN - END ## // OUTLANDS
        /*
        public bool InfernoBridge { get; set; } = true;
        public bool OverheadSummonTime { get; set; }
        public bool OverheadPeaceTime { get; set; }
        public bool MobileHamstrungTime { get; set; }
        public uint MobileHamstrungTimeCooldown { get; set; } = 3000;
        //UCC SELF
        public uint UOClassicCombatSelf_HamstringStrikeCooldown { get; set; } = 30000;
        public uint UOClassicCombatSelf_HamstringAttemptCooldown { get; set; } = 15000;
        public uint UOClassicCombatSelf_HamstrungCooldown { get; set; } = 5000;
        public bool UOClassicCombatSelf_NoRefreshPotAfterHamstrung { get; set; } = true;
        public uint UOClassicCombatSelf_NoRefreshPotAfterHamstrungCooldown { get; set; } = 5000;
        // BUFFBAR
        public bool UOClassicCombatBuffbar_DoHEnabled { get; set; } = false;
        public bool UOClassicCombatBuffbar_GotHEnabled { get; set; } = false;
        */
        // ## BEGIN - END ## // OUTLANDS
        // ## BEGIN - END ## // LOBBY
        public string LobbyIP { get; set; } = "127.0.0.1";
        public string LobbyPort { get; set; } = "2596";
        // ## BEGIN - END ## // LOBBY
        // ## BEGIN - END ## // BASICSETUP
        public bool ShowJournalClient { get; set; } = true;
        public bool ShowJournalObjects { get; set; } = true;
        public bool ShowJournalSystem { get; set; } = true;
        public bool ShowJournalGuildAlly { get; set; } = true;

        public int WorldMapWidth { get; set; } = 400;
        public int WorldMapHeight { get; set; } = 400;
        public int WorldMapFont { get; set; } = 3;
        public bool WorldMapFlipMap { get; set; } = true;
        public bool WorldMapTopMost { get; set; }
        public bool WorldMapFreeView { get; set; }
        public bool WorldMapShowParty { get; set; } = true;
        public int WorldMapZoomIndex { get; set; } = 4;
        public bool WorldMapShowCoordinates { get; set; } = true;
        public bool WorldMapShowMobiles { get; set; } = true;
        public bool WorldMapShowPlayerName { get; set; } = true;
        public bool WorldMapShowPlayerBar { get; set; } = true;
        public bool WorldMapShowGroupName { get; set; } = true;
        public bool WorldMapShowGroupBar { get; set; } = true;
        public bool WorldMapShowMarkers { get; set; } = true;
        public bool WorldMapShowMarkersNames { get; set; } = true;
        public bool WorldMapShowMultis { get; set; } = true;
        public string WorldMapHiddenMarkerFiles { get; set; } = string.Empty;


        public static uint GumpsVersion { get; private set; }

        public void Save(string path)
        {
            Log.Trace($"Saving path:\t\t{path}");

            // Save profile settings
            ConfigurationResolver.Save(this, Path.Combine(path, "profile.json"));

            // Save opened gumps
            SaveGumps(path);

            Log.Trace("Saving done!");
        }

        private void SaveGumps(string path)
        {
            string gumpsXmlPath = Path.Combine(path, "gumps.xml");

            using (XmlTextWriter xml = new XmlTextWriter(gumpsXmlPath, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            })
            {
                xml.WriteStartDocument(true);
                xml.WriteStartElement("gumps");

                UIManager.AnchorManager.Save(xml);

                LinkedList<Gump> gumps = new LinkedList<Gump>();

                foreach (Gump gump in UIManager.Gumps)
                {
                    if (!gump.IsDisposed && gump.CanBeSaved && !(gump is AnchorableGump anchored && UIManager.AnchorManager[anchored] != null))
                    {
                        gumps.AddLast(gump);
                    }
                }


                LinkedListNode<Gump> first = gumps.First;

                while (first != null)
                {
                    Gump gump = first.Value;

                    if (gump.LocalSerial != 0)
                    {
                        Item item = World.Items.Get(gump.LocalSerial);

                        if (item != null && !item.IsDestroyed && item.Opened)
                        {
                            while (SerialHelper.IsItem(item.Container))
                            {
                                item = World.Items.Get(item.Container);
                            }

                            SaveItemsGumpRecursive(item, xml, gumps);

                            if (first.List != null)
                            {
                                gumps.Remove(first);
                            }

                            first = gumps.First;

                            continue;
                        }
                    }

                    xml.WriteStartElement("gump");
                    gump.Save(xml);
                    xml.WriteEndElement();

                    if (first.List != null)
                    {
                        gumps.Remove(first);
                    }

                    first = gumps.First;
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }


            SkillsGroupManager.Save();
        }

        private static void SaveItemsGumpRecursive(Item parent, XmlTextWriter xml, LinkedList<Gump> list)
        {
            if (parent != null && !parent.IsDestroyed && parent.Opened)
            {
                SaveItemsGump(parent, xml, list);

                Item first = (Item) parent.Items;

                while (first != null)
                {
                    Item next = (Item) first.Next;

                    SaveItemsGumpRecursive(first, xml, list);

                    first = next;
                }
            }
        }

        private static void SaveItemsGump(Item item, XmlTextWriter xml, LinkedList<Gump> list)
        {
            if (item != null && !item.IsDestroyed && item.Opened)
            {
                LinkedListNode<Gump> first = list.First;

                while (first != null)
                {
                    LinkedListNode<Gump> next = first.Next;

                    if (first.Value.LocalSerial == item.Serial && !first.Value.IsDisposed)
                    {
                        xml.WriteStartElement("gump");
                        first.Value.Save(xml);
                        xml.WriteEndElement();

                        list.Remove(first);

                        break;
                    }

                    first = next;
                }
            }
        }


        public List<Gump> ReadGumps(string path)
        {
            List<Gump> gumps = new List<Gump>();

            // load skillsgroup
            SkillsGroupManager.Load();

            // load gumps
            string gumpsXmlPath = Path.Combine(path, "gumps.xml");

            if (File.Exists(gumpsXmlPath))
            {
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(gumpsXmlPath);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());

                    return gumps;
                }

                XmlElement root = doc["gumps"];

                if (root != null)
                {
                    foreach (XmlElement xml in root.ChildNodes /*.GetElementsByTagName("gump")*/)
                    {
                        if (xml.Name != "gump")
                        {
                            continue;
                        }

                        try
                        {
                            GumpType type = (GumpType) int.Parse(xml.GetAttribute(nameof(type)));
                            int x = int.Parse(xml.GetAttribute(nameof(x)));
                            int y = int.Parse(xml.GetAttribute(nameof(y)));
                            uint serial = uint.Parse(xml.GetAttribute(nameof(serial)));

                            Gump gump = null;

                            switch (type)
                            {
                                case GumpType.Buff:
                                    gump = new BuffGump();

                                    break;

                                case GumpType.Container:
                                    gump = new ContainerGump();

                                    break;

                                case GumpType.CounterBar:
                                    gump = new CounterBarGump();

                                    break;

                                case GumpType.HealthBar:
                                    if (CustomBarsToggled)
                                    {
                                        gump = new HealthBarGumpCustom();
                                    }
                                    else
                                    {
                                        gump = new HealthBarGump();
                                    }

                                    break;

                                case GumpType.InfoBar:
                                    gump = new InfoBarGump();

                                    break;

                                case GumpType.Journal:
                                    gump = new JournalGump();

                                    break;

                                // ## BEGIN - END ## // MACROS
                                case GumpType.Journal2:
                                    gump = new JournalGump2();

                                    break;
                                // ## BEGIN - END ## // MACROS

                                case GumpType.MacroButton:
                                    gump = new MacroButtonGump();

                                    break;

                                case GumpType.MiniMap:
                                    gump = new MiniMapGump();

                                    break;

                                case GumpType.PaperDoll:
                                    gump = new PaperDollGump();

                                    break;

                                case GumpType.SkillMenu:
                                    if (StandardSkillsGump)
                                    {
                                        gump = new StandardSkillsGump();
                                    }
                                    else
                                    {
                                        gump = new SkillGumpAdvanced();
                                    }

                                    break;

                                case GumpType.SpellBook:
                                    gump = new SpellbookGump();

                                    break;

                                case GumpType.StatusGump:
                                    gump = StatusGumpBase.AddStatusGump(0, 0);

                                    break;

                                //case GumpType.TipNotice:
                                //    gump = new TipNoticeGump();
                                //    break;
                                case GumpType.AbilityButton:
                                    gump = new UseAbilityButtonGump();

                                    break;

                                case GumpType.SpellButton:
                                    gump = new UseSpellButtonGump();

                                    break;

                                case GumpType.SkillButton:
                                    gump = new SkillButtonGump();

                                    break;

                                case GumpType.RacialButton:
                                    gump = new RacialAbilityButton();

                                    break;

                                case GumpType.WorldMap:
                                    gump = new WorldMapGump();

                                    break;

                                case GumpType.Debug:
                                    gump = new DebugGump(100, 100);

                                    break;

                                case GumpType.NetStats:
                                    gump = new NetworkStatsGump(100, 100);

                                    break;
                            }

                            if (gump == null)
                            {
                                continue;
                            }

                            gump.LocalSerial = serial;
                            gump.Restore(xml);
                            gump.X = x;
                            gump.Y = y;

                            if (gump.LocalSerial != 0)
                            {
                                UIManager.SavePosition(gump.LocalSerial, new Point(x, y));
                            }

                            if (!gump.IsDisposed)
                            {
                                gumps.Add(gump);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }
                    }

                    foreach (XmlElement group in root.GetElementsByTagName("anchored_group_gump"))
                    {
                        int matrix_width = int.Parse(group.GetAttribute("matrix_w"));
                        int matrix_height = int.Parse(group.GetAttribute("matrix_h"));

                        AnchorManager.AnchorGroup ancoGroup = new AnchorManager.AnchorGroup();
                        ancoGroup.ResizeMatrix(matrix_width, matrix_height, 0, 0);

                        foreach (XmlElement xml in group.GetElementsByTagName("gump"))
                        {
                            try
                            {
                                GumpType type = (GumpType) int.Parse(xml.GetAttribute("type"));
                                int x = int.Parse(xml.GetAttribute("x"));
                                int y = int.Parse(xml.GetAttribute("y"));
                                uint serial = uint.Parse(xml.GetAttribute("serial"));

                                int matrix_x = int.Parse(xml.GetAttribute("matrix_x"));
                                int matrix_y = int.Parse(xml.GetAttribute("matrix_y"));

                                AnchorableGump gump = null;

                                switch (type)
                                {
                                    case GumpType.SpellButton:
                                        gump = new UseSpellButtonGump();

                                        break;

                                    case GumpType.SkillButton:
                                        gump = new SkillButtonGump();

                                        break;

                                    case GumpType.HealthBar:
                                        if (CustomBarsToggled)
                                        {
                                            gump = new HealthBarGumpCustom();
                                        }
                                        else
                                        {
                                            gump = new HealthBarGump();
                                        }

                                        break;

                                    case GumpType.AbilityButton:
                                        gump = new UseAbilityButtonGump();

                                        break;

                                    case GumpType.MacroButton:
                                        gump = new MacroButtonGump();

                                        break;
                                }

                                if (gump != null)
                                {
                                    gump.LocalSerial = serial;
                                    gump.Restore(xml);
                                    gump.X = x;
                                    gump.Y = y;

                                    if (!gump.IsDisposed)
                                    {
                                        if (UIManager.AnchorManager[gump] == null && ancoGroup.IsEmptyDirection(matrix_x, matrix_y))
                                        {
                                            gumps.Add(gump);
                                            UIManager.AnchorManager[gump] = ancoGroup;
                                            ancoGroup.AddControlToMatrix(matrix_x, matrix_y, gump);
                                        }
                                        else
                                        {
                                            gump.Dispose();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex.ToString());
                            }
                        }
                    }
                }
            }

            return gumps;
        }
    }
}