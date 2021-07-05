<p align="center">
    <img src="https://i.imgur.com/CgpwyIQ.png" width="190" height="200" >
</p>

An open source implementation of the Ultima Online Classic Client.

Individuals/hobbyists: support continued maintenance and development via the monthly Patreon:
<br>&nbsp;&nbsp;[![Patreon](https://raw.githubusercontent.com/wiki/ocornut/imgui/web/patreon_02.png)](http://www.patreon.com/classicuo)

Individuals/hobbyists: support continued maintenance and development via PayPal:
<br>&nbsp;&nbsp;[![PayPal](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9ZWJBY6MS99D8)

<a href="https://discord.gg/VdyCpjQ">
<img src="https://img.shields.io/discord/458277173208547350.svg?logo=discord"
alt="chat on Discord"></a>

[![Build status](https://ci.appveyor.com/api/projects/status/qvqctcf8oss5bqh8?svg=true)](https://ci.appveyor.com/project/andreakarasho/classicuo)
[![GitHub Actions Status](https://github.com/andreakarasho/ClassicUO/workflows/Build/badge.svg)](https://github.com/andreakarasho/ClassicUO/actions)

# Project dust765
This project is to address a problem constructed within the toxicity of this community. This is to show the community, open source projects are not meant for cliques and high school drama but rather the expansion of something greater, innovation. -A penny for your thoughts, the adder that prays beneath the rose.

# feature showcase

[Video Part 1 on MetaCafe]( https://www.metacafe.com/watch/12177837/project-dust765/)

[Video Part 2 on MetaCafe](https://www.metacafe.com/watch/12177839/project-dust765-2/)

[Video Part 3 on MetaCafe](https://www.metacafe.com/watch/12177847/project-dust765-3/)

# art / hue changes

Stealth footsteps color

Energy Bolt - art and color

Gold - art and color

Tree to stumps / tiles and color

Blockers to stumps / tiles and color

# visual helpers

Highlight tiles at range

Highlight tiles at range if spell is up

Preview fields and wall of stone

Glowing weapons

Color own aura by HP

Highlight lasttarget (more colors and options)

# healthbar

highlight lasttarget healthbar

color border by state

flashing outline (many options)

# cursor

Show spell on cursor (and runout countdown)

# overhead / underchar

Distance

# oldhealthlines

old healthbars

mana / stamina lines, for self and party, 

bigger version and transparency

# misc

Offscreen targeting

Razor lasttarget sync (Razor lasttarget string - set this to the same lasttarget overhead string as set in Razor, so the ClassicUO lasttarget will be the same as in Razor.)

Black Outline for statics

Ignore stamina check

Block Wall of Stone

# misc 2

wireframe view

hue impassable tiles

transparent / invisible house and items by Z level from player

ignore list for circle of transparency (txt file created in your /Data/Client folder)

show death location on worldmap

# nameoverhead

hp line in nameoverheads

more filters in nameoverheads

# UI gumps

sticky last target healthbar (healthbar that always will be your last targets healthbar)

bandage gump (bandage timer UI)

# texturemanager

texture manager (arrow or halo on mobiles)

# UCC UI

UI UCC LINES - Draws a line to HUMANS on your screen.

Please specify the correct settings to make theese properly work!

UI UCC AL - Is an autoloot feature / UI. Only works with GridLoot enabled. You can add items to the txt file created in your /Data/Client folder. Recommendation is to set high value items to the autolootlist.txt (items you potentialy would go gray for) and low value items to autolootlistlow. If you check SL (SafeLoot (available for both lists)), items will ONLY be auto looted if you have looting rights. Loot Above ID adds all items to the loot list higher than X, so you dont have to add hundreds of items to the list.

UI UCC BUFFBAR - Provides a visible timer for next swing and disarm. You can enable lines individually enable them and also lock the UI to prevent moving it. There is a txt in /Data/Client to modify the timers for weapons. It does NOT change calculation with SSI or the like.

UI UCC SELF - Is an Automation feature to bandaid yourself, use pouches and pots and auto rearms a weapon after being disarmed. 

Checkboxes on the UI

Rearm Pot - Auto rearm after pot. 

Armorer Guild -  Auto rearm after being disarmed.

Thiefes Guild - Disables any actions when hidden.

Mages Guild - Disables any actions when a spellcursor is up.

# macros

HighlightTileAtRange (toggle)

ToggleTransparentHouses (toggle)

ToggleInvisibleHouses (toggle)

UCCLinesToggleLT (toggle)

UCCLinesToggleHM (toggle)

AutoMeditate (toggle)

# macros

ObjectInfo (-info command)

OpenCorpses (open corpses in 2 tiles)

OpenJournal2 (open second journal)

SetTargetClientSide (set target client side only)

LastTargetRC (LastTarget with RangeCheck)

HideX (removes a game object)

HealOnHPChange (keep pressed, casts greater heal as soon as HP change)

HarmOnSwing (keep pressed, casts harm as soon as a swinganimation is issued from server)

CureGH (cure or gheal)

# advanced macros

OpenCorpsesSafe (open corpses in 2 tiles safe to loot)

GrabFriendlyBars, GrabEnemyBars, GrabPartyAllyBars (grab all bars with hotkey)

AutoPot (one pot button)

DefendSelfKey, DefendPartyKey (clever defend self or party)

CustomInterrupt (interrupt current spellcast)

EquipManager (fast equip)

SetMimic_PlayerSerial (set master or custom serial for EquipManager)

# commands

type command in chat

-mimic (mimic casting of master)

-marker X Y (add world marker)

auto add marker for T-Maps

-df (defender)

-automed (auto meditate)

-engage (auto pathfind and attack lasttarget)

# outlands

disabled features due to client enforcement

inferno bridge solver

overhead: Summon timer (also on healthbar)

overhead: Peace timer (also on healthbar)

underchar: Hamstrung timer (also on healthbar)

buffbar: hamstrung

# lobby

connect multiple Dust765 clients to a lobby server to issue commands

[Dust765's LobbyServer] (https://github.com/dust765/LobbyServer)

features: send your lasttarget to be everyones, drop everyones spell on lasttarget, make everyone cast a spell, everyone attack lasttarget

autostealthposition: command: -autohid ((needs connected lobby) broadcast your position when hidden, everyone will see your position

commands: see options for a full list

macros: see options for a full list

# Added files

/src/Dust765

/src/Dust765/External

/src/Dust765/Macros

/src/Dust765/Managers

/src/Dust765/Autos

/src/Dust765/Shared

/src/Dust765/Lobby

/src/halo.png

/src/arrow.png

# changed constant

WAIT_FOR_TARGET_DELAY 5000 -> 4000

MAX_CIRCLE_OF_TRANSPARENCY_RADIUS 200 -> 1000

DEATH_SCREEN_TIMER 1500 -> 750

MAX_JOURNAL_HISTORY_COUNT 100 -> 250

# Changed files and line number

no comment possible:

FILE        START   END     COMMIT
README.md   20      *

comments:

FILE                                            START   END     COMMIT
/src/Configuration/Profile.cs                   276     *       BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs               171     172     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs               349     353     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs               430     434     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs               3307    3353    BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs               4156    4157    BASICSETUP

/src/Game/Constants.cs                          87              CONSTANTS

/src/Game/Constants.cs                          108             CONSTANTS

/src/Game/Constants.cs                          122             CONSTANTS

/src/Game/Constants.cs                          127             CONSTANTS

/src/Game/GameObjects/Views/ItemView.cs         36      38      ART / HUE CHANGES

/src/Game/GameObjects/Views/ItemView.cs         98      95      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   35      38      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   127     162     ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   7       10      ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   112     126     ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       35      37      ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       97      110     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     37      39      ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     385     400     ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 57      59      ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 121     126     ART / HUE CHANGES

/src/Game/GameObjects/Views/MultiView.cs        34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/MultiView.cs        129     156     VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       36      38      VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       99      126     VISUAL HELPERS

/src/Game/GameObjects/Views/TileView.cs         34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/TileView.cs         81      108     VISUAL HELPERS

/src/Game/GameCursor.cs                         37      39      VISUAL HELPERS

/src/Game/GameCursor.cs                         83      87      VISUAL HELPERS

/src/Game/GameCursor.cs                         472     477     VISUAL HELPERS

/src/Game/GameActions.cs                        54      56      VISUAL HELPERS

/src/Game/GameActions.cs                        631     634     VISUAL HELPERS

/src/Game/GameActions.cs                        645     648     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             35      37      VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             162     165     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             189     191     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             230     233     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       37      39      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       84      91      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       106     121     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       183     197     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       393     399     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       685     691     VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              1550    1555    VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2022    2048    BASICSETUP IN VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2053    2056    BASICSETUP IN VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2031    2033    VISUAL HELPERS

/src/Game/GameObjects/Static.cs                 70      74      ART / HUE CHANGES FIX1

/src/Game/GameObjects/Mobile.cs                 139     142     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             358     361     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             489     492     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             577     580     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             591     594     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             598     687     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             749     778     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1032    1037    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1202    1207    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1309    1314    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1356    1359    HEALTHBAR

/src/Game/GameCursor.cs                         38      40      CURSOR

/src/Game/GameCursor.cs                         90      94      CURSOR

/src/Game/GameCursor.cs                         484     496     CURSOR

/src/Game/Managers/HealthLinesManager.cs        35      37      OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        35      37      OVERHEAD / UNDERCHAR

/src/Game/GameObjects/Views/MobileView.cs       61      63      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             39      41      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             752     754     OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             1994    1996    OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        38      40      OLDHEALTLINES

/src/Game/Managers/HealthLinesManager.cs        59      84      OLDHEALTLINES

/src/Game/Managers/HealthLinesManager.cs        243     264     OLDHEALTLINES

/src/Game/Managers/HealthLinesManager.cs        296     317     OLDHEALTLINES

/src/Game/Managers/HealthLinesManager.cs        411     489     OLDHEALTLINES

/src/Network/PacketHandlers.cs	                41      43      MISC

/src/Network/PacketHandlers.cs	                3635    3638    MISC

/src/Network/PacketHandlers.cs	                5624    5630    MISC

/src/Game/GameObjects/Views/ItemView.cs         96      111     MISC

/src/IO/Resources/ArtLoader.cs                  353     357     MISC

/src/IO/Resources/TileDataLoader.cs             358     360     MISC

/src/IO/Resources/TileDataLoader.cs             375     379     MISC

/src/Game/Managers/MacroManager.cs              41      44      MACROS

/src/Game/Managers/MacroManager.cs              1554    1674    MACROS

/src/Game/GameObjects/PlayerMobile.cs           1358    1370    MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       37      39      MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       1337    1348    MACROS

/src/Network/PacketHandlers.cs	                5513    5516    MACROS

/src/Game/World.cs                              37      39      MACROS

/src/Game/World.cs                              93      95      MACROS

/src/Configuration/Profile.cs                   44      46      MACROS

/src/Configuration/Profile.cs                   600     605     MACROS

/src/Game/UI/Gumps/GumpType.cs                  62      62      MACROS

/src/Game/GameObjects/Views/TileView.cs         35      37      MISC2

/src/Game/GameObjects/Views/TileView.cs         111     120     MISC2

/src/Game/GameObjects/Views/TileView.cs         126     167     MISC2

/src/Game/GameObjects/Views/TileView.cs         176     203     MISC2

/src/Game/GameObjects/Views/View.cs             36      39      MISC2

/src/Game/GameObjects/Views/View.cs             163     203     MISC2

/src/Game/GameObjects/Views/View.cs             342     350     MISC2

/src/IO/Resources/TexmapsLoader.cs              36      38      MISC2

/src/IO/Resources/TexmapsLoader.cs              207     220     MISC2

/src/IO/Resources/TexmapsLoader.cs              229     314     MISC2

/src/IO/Resources/ArtLoader.cs                  145     171     MISC2

/src/IO/Resources/ArtLoader.cs                  545     616     MISC2

/src/Game/Data/StaticFilters.cs                 52      54      MISC2

/src/Game/Data/StaticFilters.cs                 63      65      MISC2

/src/Game/Data/StaticFilters.cs                 79      118     MISC2

/src/Game/Data/StaticFilters.cs                 405     411     MISC2

/src/Game/GameObjects/Views/ItemView.cs         207     218     MISC2

/src/Game/GameObjects/Views/MultiView.cs        129     156     MISC2

/src/Game/Managers/MacroManager.cs              3747    3750    MISC2

/src/Game/Managers/MacroManager.cs              2189    2192    MISC2

/src/Game/UI/Gumps/WorldMapGump.cs              1757    1809    MISC2

/src/Game/GameObjects/PlayerMobile.cs           51      55      MISC2

/src/Network/PacketHandlers.cs	                1614    1618    MISC2

/src/Game/UI/Gumps/NameOverheadGump.cs	        56      123     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        153     193     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        615     670     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	37      39      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	58      64      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	140     298     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	301     308     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	345     395     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       37      39      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       50      55      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       101     250     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs                   38      41      UI/GUMPS

/src/Game/Scenes/GameScene.cs                   202     216     UI/GUMPS

/src/Game/Scenes/GameScene.cs                   325     327     UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           38      40      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           59      61      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           67      69      UI/GUMPS

/src/Network/PacketHandlers.cs	                4695    4697    UI/GUMPS

/src/Game/UI/Gumps/OptionsGump.cs               39      41      UI/GUMPS

/src/Game/Scenes/GameScene.cs                   94      96      TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   165     167     TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   1168    1170    TEXTUREMANAGER

/src/ClassicUO.csproj	                        60      78      TEXTUREMANAGER

/src/Game/Managers/MacroManager.cs              3747    3750    LINES

/src/Game/Scenes/GameScene.cs                   97      99      LINES

/src/Game/Scenes/GameScene.cs                   171     173     LINES

/src/Game/Scenes/GameScene.cs                   1177    1179    LINES

/src/Game/GameObjects/Entity.cs                 96      98      AUTOLOOT

/src/Network/PacketHandlers.cs	                845     854     AUTOLOOT

/src/Network/PacketHandlers.cs	                4709    4718    AUTOLOOT

/src/Game/Scenes/GameScene.cs                   228     238     AUTOLOOT + LINES FIX

/src/Game/Scenes/GameScene.cs                   239     249     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            35      37      AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            96      114     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            218     225     AUTOLOOT

/src/Game/Scenes/GameScene.cs                   250     260     BUFFBAR

/src/Game/World.cs                              93      95      BUFFBAR

/src/Network/PacketHandlers.cs	                4719    4721    BUFFBAR

/src/Game/Scenes/GameScene.cs                   261     271     SELF

/src/Game/Scenes/GameScene.cs                   384     389     SELF

/src/Game/Managers/MacroManager.cs              1508    1520    SELF

/src/Game/Managers/TargetManager.cs             58      60      ADVMACROS

/src/Game/Managers/TargetManager.cs             416     438     ADVMACROS

/src/Game/Managers/MacroManager.cs              45      48      ADVMACROS

/src/Game/Managers/MacroManager.cs              1727    1937    ADVMACROS

/src/Game/Managers/MacroManager.cs              2247    2253    ADVMACROS

/src/Game/Managers/MacroManager.cs              2246    2259    ADVMACROS

/src/Game/Managers/MacroManager.cs              2413    2444    ADVMACROS

/src/Game/Managers/MacroManager.cs              2693    2733    ADVMACROS

/src/Game/GameObjects/PlayerMobile.cs           1387    1407    ADVMACROS

/src/Game/Managers/MacroManager.cs              1938    1944    AUTOMATIONS

/src/Game/Managers/MacroManager.cs              2446    2448    AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   272     274     AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   421     429     AUTOMATIONS

/src/Game/World.cs                              350     352     AUTOMATIONS

/src/Network/PacketHandlers.cs	                44      46      AUTOMATIONS

/src/Network/PacketHandlers.cs	                2442    2444    AUTOMATIONS

/src/Network/PacketHandlers.cs	                858     861     AUTOMATIONS

/src/Network/PacketHandlers.cs	                2135    2137    AUTOMATIONS

/src/Network/PacketHandlers.cs	                3129    3131    AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              63      74      AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              1823    1893    AUTOMATIONS

/src/Network/PacketHandlers.cs	                862     865     CURSOR FIXES

/src/Game/Map/Chunk.cs                          35      37      OUTLANDS

/src/Game/Map/Chunk.cs                          139     142     OUTLANDS

/src/Network/PacketHandlers.cs	                2457    2460    OUTLANDS

/src/Network/PacketHandlers.cs	                3688    3697    OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        217     228     OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        278     288     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             106     108     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             123     126     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             374     376     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             413     415     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             566     601     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             714     723     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             815     817     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1413    1426    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1581    1583    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1816    1829    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1985    2020    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             2134    2136    OUTLANDS

/src/Game/GameObjects/Mobile.cs                 143     150     OUTLANDS

/src/Game/GameObjects/Views/MobileView.cs       64      68      OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             75      77      OFFSCREENTARGETING

/src/Game/UI/Gumps/HealthBarGump.cs             190     194     OFFSCREENTARGETING

/src/Game/UI/Gumps/HealthBarGump.cs             199     201     OFFSCREENTARGETING

/src/Game/UI/Gumps/HealthBarGump.cs             245     247     OFFSCREENTARGETING

/src/Game/UI/Gumps/HealthBarGump.cs             249     258     OFFSCREENTARGETING

/src/Game/UI/Gumps/HealthBarGump.cs             249     258     OFFSCREENTARGETING

/src/Game/UI/Controls/Control.cs                36      38      OFFSCREENTARGETING

/src/Game/UI/Controls/Control.cs                83      85      OFFSCREENTARGETING

/src/Game/UI/Gumps/Login/LoginGump.cs	        439     449     LOGIN

/src/Game/Managers/MacroManager.cs              1945    1981    LOBBY

/src/Game/Managers/MacroManager.cs              2502    2509    LOBBY

# Introduction
ClassicUO is an open source implementation of the Ultima Online Classic Client. This client is intended to emulate all standard client versions and is primarily tested against Ultima Online free shards.

The client is currently under heavy development but is functional. The code is based on the [FNA-XNA](https://fna-xna.github.io/) framework. C# is chosen because there is a large community of developers working on Ultima Online server emulators in C#, because FNA-XNA exists and seems reasonably suitable for creating this type of game.

ClassicUO is natively cross platform and supports:
* Windows [DirectX 11, OpenGL, Vulkan]
* Linux   [OpenGL, Vulkan]
* macOS   [Metal, OpenGL, MoltenVK]

# Download & Play!
| Platform | Link |
| --- | --- |
| Windows x64 | [Download](https://www.classicuo.eu/launcher/win-x64/ClassicUOLauncher-win-x64-release.zip) |
| Linux x64 | [Download](https://www.classicuo.eu/launcher/linux-x64/ClassicUOLauncher-linux-x64-release.zip) |
| macOS | [Download](https://www.classicuo.eu/launcher/osx/ClassicUOLauncher-osx-x64-release.zip) |

Or visit the [ClassicUO Website](https://www.classicuo.eu/)

# How to build the project

Clone repository with:
```
git clone --recursive https://github.com/andreakarasho/ClassicUO.git
```

### Windows
The binary produced will work on all supported platforms.

You'll need [Visual Studio 2019](https://www.visualstudio.com/downloads/). The free community edition should be fine. Once that
is installed:

- Open ClassicUO.sln from the root of the repository.

- Select "Debug" or "Release" at the top.

- Hit F5 to build. The output will be in the "bin/Release" or "bin/Debug" directory.

# Linux

- Open a terminal and enter the following commands.

## Ubuntu
![Ubuntu](https://assets.ubuntu.com/v1/ad9a02ac-ubuntu-orange.gif)
```bash
sudo apt update
sudo apt install dirmngr gnupg apt-transport-https ca-certificates software-properties-common lsb-release
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
```

```
sudo apt-add-repository "deb https://download.mono-project.com/repo/ubuntu stable-`lsb_release -sc` main"
```

Check signature
```
gpg: key A6A19B38D3D831EF: public key "Xamarin Public Jenkins (auto-signing) <releng@xamarin.com>" imported
gpg: Total number processed: 1
gpg:               imported: 1
```
```bash
sudo apt install mono-complete
```

## Fedora
![Fedora](https://fedoraproject.org/w/uploads/thumb/3/3c/Fedora_logo.png/150px-Fedora_logo.png)

### Fedora 29
```bash
rpm --import "https://keyserver.ubuntu.com/pks/lookup?op=get&search=0x3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF"
su -c 'curl https://download.mono-project.com/repo/centos8-stable.repo | tee /etc/yum.repos.d/mono-centos8-stable.repo'
dnf update
```

### Fedora 28
```bash
rpm --import "https://keyserver.ubuntu.com/pks/lookup?op=get&search=0x3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF"
su -c 'curl https://download.mono-project.com/repo/centos7-stable.repo | tee /etc/yum.repos.d/mono-centos7-stable.repo'
dnf update
```

```bash
sudo dnf install mono-devel
```

## ArchLinux
![ArchLinux](https://www.archlinux.org/static/logos/archlinux-logo-dark-scalable.518881f04ca9.svg)

```bash
sudo pacman -S mono mono-tools
```

Verify
```bash
mono --version
```
```
Mono JIT compiler version 6.6.0.161 (tarball Tue Dec 10 10:36:32 UTC 2019)
Copyright (C) 2002-2014 Novell, Inc, Xamarin Inc and Contributors. www.mono-project.com
    TLS:           __thread
    SIGSEGV:       altstack
    Notifications: epoll
    Architecture:  amd64
    Disabled:      none
    Misc:          softdebug
    Interpreter:   yes
    LLVM:          yes(610)
    Suspend:       hybrid
    GC:            sgen (concurrent by default)
```

- Navigate to ClassicUO scripts folder:
  `cd /your/path/to/ClassicUO/scripts`

- Execute `build.sh` script. If you want build a debug version of ClassicUO just pass "debug" as argument like: `./build.sh debug`.
  Probably you have to set the `build.sh` file executable with with the command `chmod -x build.sh`

- Navigate to `/your/path/to/ClassicUO/bin/[Debug or Release]`


### macOS
All the commands should be executed in terminal. All global package installs should be done only if not yet installed.

- Install Homebrew, a package manager for macOS (if not yet installed):
  Follow instructions on https://brew.sh/

- Install Mono (https://www.mono-project.com/):
  `brew install mono`

- Install NuGet, a package manager for .NET (https://docs.microsoft.com/en-us/nuget/):
  `brew install nuget`

- Navigate to ClassicUO root folder:
  `cd /your/path/to/ClassicUO`

- Restore packages (https://docs.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-restore):
  `nuget restore`

- Build:
  - Debug version: `msbuild /t:Rebuild /p:Configuration=Debug`
  - Release version: `msbuild /t:Rebuild /p:Configuration=Release`

- Run ClassicUO via Mono:
  - Debug version: `DYLD_LIBRARY_PATH=./bin/Debug/osx/ mono ./bin/Debug/ClassicUO.exe`
  - Release version: `DYLD_LIBRARY_PATH=./bin/Release/osx/ mono ./bin/Release/ClassicUO.exe`

After the first run, ignore the error message and a new file called `settings.json` will be automatically created in the directory that contains ClassicUO.exe.

Other useful commands:
- `msbuild /t:Clean /p:Configuration=Debug`
- `msbuild /t:Clean /p:Configuration=Release`

# Contribute
Everyone is welcome to contribute! The GitHub issues and project tracker are kept up to date with tasks that need work.

# Legal
The code itself has been written using the following projects as a reference:

* [OrionUO](https://github.com/hotride/orionuo)
* [Razor](https://github.com/msturgill/razor)
* [UltimaXNA](https://github.com/ZaneDubya/UltimaXNA)
* [ServUO](https://github.com/servuo/servuo)

Backend:
* [FNA](https://github.com/FNA-XNA/FNA)

This work is released under the BSD 4 license. This project does not distribute any copyrighted game assets. In order to run this client you'll need to legally obtain a copy of the Ultima Online Classic Client.
Using a custom client to connect to official UO servers is strictly forbidden. We do not assume any responsibility of the usage of this client.

Ultima Online(R) © 2020 Electronic Arts Inc. All Rights Reserved.
