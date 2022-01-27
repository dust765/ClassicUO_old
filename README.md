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
[![GitHub Actions Status](https://github.com/ClassicUO/ClassicUO/workflows/Build/badge.svg)](https://github.com/ClassicUO/ClassicUO/actions)

# Project dust765
This project is to address a problem constructed within the toxicity of this community. This is to show the community, open source projects are not meant for cliques and high school drama but rather the expansion of something greater, innovation. -A penny for your thoughts, the adder that prays beneath the rose.

# feature showcase

[Video Part 1 on YouTube](https://youtu.be/074Osj1Fcrg)

[Video Part 2 on YouTube](https://youtu.be/P7YBrI3s6ZI)

[Video Part 3 on YouTube](https://youtu.be/aqHiiOhx8Q8)

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

Block Energy Field

# misc2

wireframe view

hue impassable tiles

transparent / invisible house and items by Z level from player and min Z from ground

ignore list for circle of transparency (txt file created in your /Data/Client folder)

show death location on worldmap

# nameoverhead

hp line in nameoverheads

more filters for nameoverheads

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

UI UCC SELF - Is an Automation feature to bandaid yourself, use pouches, pots and enhanced apple (auto rearms a weapon after being disarmed).

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

-autorange (auto show range indicator when weapon is equipped)

# outlands

disabled features due to client enforcement (code updates NOT maintained)

inferno bridge solver (color specific land tiles)

overhead: Summon timer (also on healthbar)

overhead: Peace timer (also on healthbar)

underchar: Hamstrung timer (also on healthbar)

buffbar: hamstrung

# Added files

/src/Dust765

/src/Dust765/External

/src/Dust765/Macros

/src/Dust765/Managers

/src/Dust765/Autos

/src/Dust765/Shared

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
/src/Configuration/Profile.cs	                281     *       BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            177     179     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            372     376     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            453     457     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            3403    3449    BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            4275    4277    BASICSETUP

/src/Game/Constants.cs                          87              CONSTANTS

/src/Game/Constants.cs                          108             CONSTANTS

/src/Game/Constants.cs                          122             CONSTANTS

/src/Game/Constants.cs                          127             CONSTANTS

/src/Game/GameObjects/Views/ItemView.cs         37      39      ART / HUE CHANGES

/src/Game/GameObjects/Views/ItemView.cs         81      87      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   35      38      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   125     160     ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   8       10      ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   110     124     ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       35      37      ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       95      108     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     38      40      ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     683     688     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     706     710     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     779     783     ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 57      59      ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 70      74      ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 125     130     ART / HUE CHANGES

/src/Game/GameObjects/Views/MultiView.cs        34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/MultiView.cs        118     150     VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       36      38      VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       97      129     VISUAL HELPERS

/src/Game/GameObjects/Views/TileView.cs         34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/TileView.cs         81      113     VISUAL HELPERS

/src/Game/GameCursor.cs                         37      39      VISUAL HELPERS

/src/Game/GameCursor.cs                         80      84      VISUAL HELPERS

/src/Game/GameCursor.cs                         358     363     VISUAL HELPERS

/src/Game/GameActions.cs                        54      56      VISUAL HELPERS

/src/Game/GameActions.cs                        655     658     VISUAL HELPERS

/src/Game/GameActions.cs                        669     672     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             35      37      VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             163     166     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             191     193     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             235     238     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       37      39      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       89      96      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       115     130     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       199     213     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       442     448     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       848     854     VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              1559    1564    VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2050    2076    BASICSETUP IN VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2081    2084    BASICSETUP IN VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2059    2061    VISUAL HELPERS

/src/Game/GameObjects/Mobile.cs                 144     147     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             358     361     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             489     492     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             579     582     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             593     596     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             600     689     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             751     780     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1034    1039    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1204    1209    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1311    1316    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1358    1361    HEALTHBAR

/src/Game/GameCursor.cs                         38      40      CURSOR

/src/Game/GameCursor.cs                         87      91      CURSOR

/src/Game/GameCursor.cs                         370     383     CURSOR

/src/Network/PacketHandlers.cs	                41      43      CURSOR

/src/Network/PacketHandlers.cs	                846     849     CURSOR

/src/Game/Managers/HealthLinesManager.cs        35      37      OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        167     172     OVERHEAD / UNDERCHAR

/src/Game/GameObjects/Views/MobileView.cs       60      62      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             39      41      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             754     756     OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             2002    2004    OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        36      39      OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        58      83      OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        228     248     OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        281     301     OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        411     489     OLDHEALTHLINES

/src/Network/PacketHandlers.cs	                42      44      MISC

/src/Network/PacketHandlers.cs	                3560    3563    MISC

/src/Network/PacketHandlers.cs	                5567    5586    MISC

/src/Game/GameObjects/Views/ItemView.cs         89      117     MISC

/src/IO/Resources/ArtLoader.cs                  416     420     MISC

/src/IO/Resources/TileDataLoader.cs             358     360     MISC

/src/IO/Resources/TileDataLoader.cs             375     379     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             75      77      MISC

/src/Game/UI/Gumps/HealthBarGump.cs             181     185     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             190     192     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             236     238     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             240     249     MISC

/src/Game/UI/Controls/Control.cs                36      38      MISC

/src/Game/UI/Controls/Control.cs                81      83      MISC

/src/Game/GameObjects/Views/TileView.cs         35      37      MISC2

/src/Game/GameObjects/Views/TileView.cs         111     120     MISC2

/src/Game/GameObjects/Views/TileView.cs         126     170     MISC2

/src/Game/GameObjects/Views/TileView.cs         174     204     MISC2

/src/Game/GameObjects/Views/View.cs             36      39      MISC2

/src/Game/GameObjects/Views/View.cs             202     272     MISC2

/src/Game/GameObjects/Views/View.cs             383     391     MISC2

/src/IO/Resources/TexmapsLoader.cs              36      38      MISC2

/src/IO/Resources/TexmapsLoader.cs              144     222     MISC2

/src/IO/Resources/ArtLoader.cs                  222     368     MISC2

/src/Game/Data/StaticFilters.cs                 52      54      MISC2

/src/Game/Data/StaticFilters.cs                 63      65      MISC2

/src/Game/Data/StaticFilters.cs                 79      118     MISC2

/src/Game/Data/StaticFilters.cs                 405     411     MISC2

/src/Game/GameObjects/Views/ItemView.cs         213     235     MISC2

/src/Game/GameObjects/Views/MultiView.cs        155     177     MISC2

/src/Game/Managers/MacroManager.cs              1565    1574    MISC2

/src/Game/Managers/MacroManager.cs              2092    2095    MISC2

/src/Game/UI/Gumps/WorldMapGump.cs              1960    2013    MISC2

/src/Game/GameObjects/PlayerMobile.cs           51      55      MISC2

/src/Network/PacketHandlers.cs	                1622    1626    MISC2

/src/Game/Scenes/GameSceneDrawingSorting.cs	    414     422     MISC2

/src/Game/Managers/MacroManager.cs              41      44      MACROS

/src/Game/Managers/MacroManager.cs              1579    1699    MACROS

/src/Game/Managers/MacroManager.cs              2186+           MACROS

/src/Game/GameObjects/PlayerMobile.cs           1370    1382    MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       37      39      MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       1361    1372    MACROS

/src/Network/PacketHandlers.cs	                2255    2258    MACROS

/src/Network/PacketHandlers.cs	                5467    5470    MACROS

/src/Game/World.cs                              37      39      MACROS

/src/Game/World.cs                              95      97      MACROS

/src/Configuration/Profile.cs                   38      40      MACROS

/src/Configuration/Profile.cs                   629     634     MACROS

/src/Game/UI/Gumps/GumpType.cs                  60      62      MACROS

/src/Game/UI/Gumps/NameOverheadGump.cs	        56      123     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        157     197     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        615     666     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	37      39      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	72      78      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	154     312     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	315     322     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	358     408     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       37      39      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       50      55      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       101     250     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs                   38      41      UI/GUMPS

/src/Game/Scenes/GameScene.cs                   203     217     UI/GUMPS

/src/Game/Scenes/GameScene.cs                   339     341     UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           38      40      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           59      61      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           67      69      UI/GUMPS

/src/Network/PacketHandlers.cs	                4622    4624    UI/GUMPS

/src/Game/UI/Gumps/OptionsGump.cs               39      41      UI/GUMPS

/src/Game/Scenes/GameScene.cs                   94      96      TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   167     169     TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   1253    1255    TEXTUREMANAGER

/src/ClassicUO.csproj	                        64      82      TEXTUREMANAGER

/src/Game/Managers/MacroManager.cs              1700    1717    LINES

/src/Game/Managers/MacroManager.cs              2223    2226    LINES

/src/Game/Scenes/GameScene.cs                   97      99      LINES

/src/Game/Scenes/GameScene.cs                   173     175     LINES

/src/Game/Scenes/GameScene.cs                   230     240     LINES

/src/Game/Scenes/GameScene.cs                   1273    1275    LINES

/src/Game/GameObjects/Entity.cs                 99      101     AUTOLOOT

/src/Network/PacketHandlers.cs	                848     857     AUTOLOOT

/src/Network/PacketHandlers.cs	                4635    4644    AUTOLOOT

/src/Game/Scenes/GameScene.cs                   241     251     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            35      37      AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            97      115     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            228     235     AUTOLOOT

/src/Game/Scenes/GameScene.cs                   252     262     BUFFBAR

/src/Game/Scenes/GameScene.cs                   387     392     BUFFBAR

/src/Game/World.cs                              98      100     BUFFBAR

/src/Network/PacketHandlers.cs	                4645    4647    BUFFBAR

/src/Game/Scenes/GameScene.cs                   263     273     SELF

/src/Game/Scenes/GameScene.cs                   399     404     SELF

/src/Game/Managers/MacroManager.cs              1517    1529    SELF

/src/Game/Managers/TargetManager.cs             59      61      ADVMACROS

/src/Game/Managers/TargetManager.cs             428     450     ADVMACROS

/src/Game/Managers/MacroManager.cs              45      48      ADVMACROS

/src/Game/Managers/MacroManager.cs              1736    1946    ADVMACROS

/src/Game/Managers/MacroManager.cs              2275    2281    ADVMACROS

/src/Game/Managers/MacroManager.cs              2442    2447    ADVMACROS

/src/Game/Managers/MacroManager.cs              2449    2452    ADVMACROS

/src/Game/Managers/MacroManager.cs              2462    2464    ADVMACROS

/src/Game/Managers/MacroManager.cs              2472    2476    ADVMACROS

/src/Game/Managers/MacroManager.cs              2725    2765    ADVMACROS

/src/Game/GameObjects/PlayerMobile.cs           1393    1413    ADVMACROS

/src/Game/Managers/MacroManager.cs              1947    1953    AUTOMATIONS

/src/Game/Managers/MacroManager.cs              2478    2480    AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   274     276     AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   436     444     AUTOMATIONS

/src/Game/World.cs                              352     354     AUTOMATIONS

/src/Network/PacketHandlers.cs	                46      48      AUTOMATIONS

/src/Network/PacketHandlers.cs	                861     864     AUTOMATIONS

/src/Network/PacketHandlers.cs	                2142    2144    AUTOMATIONS

/src/Network/PacketHandlers.cs	                2367    2369    AUTOMATIONS

/src/Network/PacketHandlers.cs	                3053    3055    AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              65      76      AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              1823    1893    AUTOMATIONS

/src/Game/Map/Chunk.cs                          35      37      OUTLANDS

/src/Game/Map/Chunk.cs                          138     141     OUTLANDS

/src/Network/PacketHandlers.cs	                2370    2373    OUTLANDS

/src/Network/PacketHandlers.cs	                3608    3619    OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        202     215     OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        265     277     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             110     112     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             126     130     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             395     397     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             434     436     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             589     626     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             739     750     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             842     844     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1440    1455    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1614    1616    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1849    1864    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             2022    2059    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             2173    2175    OUTLANDS

/src/Game/GameObjects/Mobile.cs                 148     157     OUTLANDS

/src/Game/GameObjects/Views/MobileView.cs       63      67      OUTLANDS

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
git clone --recursive https://github.com/ClassicUO/ClassicUO.git
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
