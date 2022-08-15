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

[![GitHub Actions Status](https://github.com/ClassicUO/ClassicUO/workflows/Build-Test/badge.svg)](https://github.com/ClassicUO/ClassicUO/actions)
[![GitHub Actions Status](https://github.com/ClassicUO/ClassicUO/workflows/Deploy/badge.svg)](https://github.com/ClassicUO/ClassicUO/actions)

# Project dust765
This project is to address a problem constructed within the toxicity of this community. This is to show the community, open source projects are not meant for cliques and high school drama but rather the expansion of something greater, innovation. -A penny for your thoughts, the adder that prays beneath the rose.

# contact and team info

Discord: dust765#2787

Dust765: 7 Link, 6 G..., 5 S...

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

Preview field spells, wall of stone and area of effect spells

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

Block Wall of Stone rubberband

Block Energy Field rubberband

# misc2

wireframe view

hue impassable tiles

transparent / invisible house and items by Z level from player and min Z from ground

ignore list for circle of transparency (txt file created in your /Data/Client folder)

show death location on worldmap

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

# Added files

/src/Dust765

/src/Dust765/External

# changed constants

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
/src/Configuration/Profile.cs	                282     *       BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            177     179     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            372     376     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            453     457     BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            3380    3426    BASICSETUP

/src/Game/UI/Gumps/OptionsGump.cs	            4246    4248    BASICSETUP

/src/Game/Managers/MacroManager.cs              2252    2276    BASICSETUP

/src/Game/Managers/MacroManager.cs              2281    2284    BASICSETUP

/src/Game/Constants.cs                          87              CONSTANTS

/src/Game/Constants.cs                          108             CONSTANTS

/src/Game/Constants.cs                          122             CONSTANTS

/src/Game/Constants.cs                          127             CONSTANTS

/src/Game/GameObjects/Views/ItemView.cs         37      39      ART / HUE CHANGES

/src/Game/GameObjects/Views/ItemView.cs         91      97      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   36      39      ART / HUE CHANGES

/src/Game/GameObjects/Item.cs                   126     161     ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   8       10      ART / HUE CHANGES

/src/Game/GameObjects/Views/GameEffectView.cs   110     124     ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       35      37      ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       95      108     ART / HUE CHANGES

/src/Game/GameObjects/Views/StaticView.cs       135     148     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     38      40      ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     675     680     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     698     702     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     759     763     ART / HUE CHANGES

/src/Game/Scenes/GameSceneDrawingSorting.cs     854     858     ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 57      59      ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 71      75      ART / HUE CHANGES

/src/Game/GameObjects/Static.cs                 126     131     ART / HUE CHANGES

/src/Game/Managers/MacroManager.cs              1746    1756    ART / HUE CHANGES

/src/Game/GameObjects/Views/LandView.cs         34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/LandView.cs         83      110     VISUAL HELPERS

/src/Game/GameObjects/Views/MultiView.cs        34      36      VISUAL HELPERS

/src/Game/GameObjects/Views/MultiView.cs        118     145     VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       36      38      VISUAL HELPERS

/src/Game/GameObjects/Views/StaticView.cs       97      124     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       37      39      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       89      96      VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       115     130     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       199     213     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       440     446     VISUAL HELPERS

/src/Game/GameObjects/Views/MobileView.cs       796     802     VISUAL HELPERS

/src/Game/GameCursor.cs                         37      39      VISUAL HELPERS

/src/Game/GameCursor.cs                         80      84      VISUAL HELPERS

/src/Game/GameCursor.cs                         348     353     VISUAL HELPERS

/src/Game/GameActions.cs                        54      56      VISUAL HELPERS

/src/Game/GameActions.cs                        656     659     VISUAL HELPERS

/src/Game/GameActions.cs                        670     673     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             35      37      VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             163     166     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             191     193     VISUAL HELPERS

/src/Game/Managers/TargetManager.cs             235     238     VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              1771    1776    VISUAL HELPERS

/src/Game/Managers/MacroManager.cs              2278    2280    VISUAL HELPERS

/src/Network/PacketHandlers.cs	                41      43      VISUAL HELPERS

/src/Network/PacketHandlers.cs	                828     831     VISUAL HELPERS

/src/Game/GameObjects/Mobile.cs                 146     149     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             359     362     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             490     493     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             580     583     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             594     597     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             601     690     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             752     781     HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1035    1040    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1205    1210    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1312    1317    HEALTHBAR

/src/Game/UI/Gumps/HealthBarGump.cs             1359    1362    HEALTHBAR

/src/Game/GameCursor.cs                         38      40      CURSOR

/src/Game/GameCursor.cs                         87      91      CURSOR

/src/Game/GameCursor.cs                         360     373     CURSOR

/src/Game/Managers/HealthLinesManager.cs        35      37      OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        165     170     OVERHEAD / UNDERCHAR

/src/Game/GameObjects/Views/MobileView.cs       60      62      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             39      41      OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             755     757     OVERHEAD / UNDERCHAR

/src/Game/UI/Gumps/HealthBarGump.cs             2003    2005    OVERHEAD / UNDERCHAR

/src/Game/Managers/HealthLinesManager.cs        36      39      OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        58      83      OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        226     246     OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        278     298     OLDHEALTHLINES

/src/Game/Managers/HealthLinesManager.cs        408     482     OLDHEALTHLINES

/src/Network/PacketHandlers.cs	                42      44      MISC

/src/Network/PacketHandlers.cs	                3551    3554    MISC

/src/Network/PacketHandlers.cs	                5572    5591    MISC

/src/Game/GameObjects/Views/ItemView.cs         89      127     MISC

/src/IO/Resources/ArtLoader.cs                  454     458     MISC

/src/IO/Resources/TileDataLoader.cs             358     360     MISC

/src/IO/Resources/TileDataLoader.cs             375     379     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             75      77      MISC

/src/Game/UI/Gumps/HealthBarGump.cs             182     186     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             192     194     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             238     240     MISC

/src/Game/UI/Gumps/HealthBarGump.cs             242     251     MISC

/src/Game/UI/Controls/Control.cs                36      38      MISC

/src/Game/UI/Controls/Control.cs                81      83      MISC

/src/Game/GameObjects/Views/LandView.cs         35      37      MISC2

/src/Game/GameObjects/Views/LandView.cs         113     122     MISC2

/src/Game/GameObjects/Views/LandView.cs         128     133     MISC2

/src/Game/GameObjects/Views/LandView.cs         166     171     MISC2

/src/Game/GameObjects/Views/ItemView.cs         218     240     MISC2

/src/Game/GameObjects/Views/MultiView.cs        155     167     MISC2

/src/Game/GameObjects/Views/View.cs             36      39      MISC2

/src/Game/GameObjects/Views/View.cs             245     253     MISC2

/src/IO/Resources/TexmapsLoader.cs              36      38      MISC2

/src/IO/Resources/TexmapsLoader.cs              123     128     MISC2

/src/IO/Resources/TexmapsLoader.cs              139     143     MISC2

/src/IO/Resources/TexmapsLoader.cs              150     155     MISC2

/src/IO/Resources/TexmapsLoader.cs              178     205     MISC2

/src/IO/Resources/ArtLoader.cs                  104     108     MISC2

/src/IO/Resources/ArtLoader.cs                  149     164     MISC2

/src/IO/Resources/ArtLoader.cs                  177     192     MISC2

/src/IO/Resources/ArtLoader.cs                  252     257     MISC2

/src/IO/Resources/ArtLoader.cs                  265     269     MISC2

/src/IO/Resources/ArtLoader.cs                  279     283     MISC2

/src/IO/Resources/ArtLoader.cs                  305     309     MISC2

/src/IO/Resources/ArtLoader.cs                  319     323     MISC2

/src/Game/Data/StaticFilters.cs                 52      54      MISC2

/src/Game/Data/StaticFilters.cs                 63      65      MISC2

/src/Game/Data/StaticFilters.cs                 79      118     MISC2

/src/Game/Data/StaticFilters.cs                 405     411     MISC2

/src/Game/Managers/MacroManager.cs              1777    1786    MISC2

/src/Game/Managers/MacroManager.cs              2311    2314    MISC2

/src/Game/UI/Gumps/WorldMapGump.cs              2451    2504    MISC2

/src/Game/GameObjects/PlayerMobile.cs           51      55      MISC2

/src/Network/PacketHandlers.cs	                1604    1608    MISC2

/src/Game/Scenes/GameSceneDrawingSorting.cs	    402     416     MISC2

/src/Game/Managers/MacroManager.cs              42      45      MACROS

/src/Game/Managers/MacroManager.cs              1791    1911    MACROS

/src/Game/Managers/MacroManager.cs              2405+           MACROS

/src/Game/GameObjects/PlayerMobile.cs           1367    1379    MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       37      39      MACROS

/src/Game/Scenes/GameSceneInputHandler.cs       1368    1379    MACROS

/src/Network/PacketHandlers.cs	                2246    2249    MACROS

/src/Network/PacketHandlers.cs	                5472    5475    MACROS

/src/Game/World.cs                              37      39      MACROS

/src/Game/World.cs                              97      99      MACROS

/src/Configuration/Profile.cs                   38      40      MACROS

/src/Configuration/Profile.cs                   633     638     MACROS

/src/Game/UI/Gumps/GumpType.cs                  60      62      MACROS

# Introduction
ClassicUO is an open source implementation of the Ultima Online Classic Client. This client is intended to emulate all standard client versions and is primarily tested against Ultima Online free shards.

The client is currently under heavy development but is functional. The code is based on the [FNA-XNA](https://fna-xna.github.io/) framework. C# is chosen because there is a large community of developers working on Ultima Online server emulators in C#, because FNA-XNA exists and seems reasonably suitable for creating this type of game.

![screenshot_2020-07-06_12-29-02](https://user-images.githubusercontent.com/20810422/208747312-04f6782f-3dc8-4951-b0a0-73d2305bbfca.png)


ClassicUO is natively cross platform and supports:
* Browser [Chrome]
* Windows [DirectX 11, OpenGL, Vulkan]
* Linux   [OpenGL, Vulkan]
* macOS   [Metal, OpenGL, MoltenVK]

# Download & Play!
| Platform | Link |
| --- | --- |
| Browser | [Play!](https://play.classicuo.org) |
| Windows x64 | [Download](https://www.classicuo.eu/launcher/win-x64/ClassicUOLauncher-win-x64-release.zip) |
| Linux x64 | [Download](https://www.classicuo.eu/launcher/linux-x64/ClassicUOLauncher-linux-x64-release.zip) |
| macOS | [Download](https://www.classicuo.eu/launcher/osx/ClassicUOLauncher-osx-x64-release.zip) |

Or visit the [ClassicUO Website](https://www.classicuo.eu/)

# How to build the project

Clone repository with:
```
git config --global url."https://".insteadOf git://
git clone --recursive https://github.com/ClassicUO/ClassicUO.git
```

Build the project:
```
dotnet build -c Release
```

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

Ultima Online(R) © 2022 Electronic Arts Inc. All Rights Reserved.
