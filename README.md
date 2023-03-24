<p align="center">
    <img src="https://i.imgur.com/CgpwyIQ.png" width="190" height="200" >
</p>

An open source implementation of the Ultima Online Classic Client.

[![GitHub Actions Status](https://github.com/dust765/ClassicUO/workflows/Build-Test/badge.svg)](https://github.com/dust765/ClassicUO/actions)
[![GitHub Actions Status](https://github.com/dust765/ClassicUO/workflows/Deploy/badge.svg)](https://github.com/dust765/ClassicUO/actions)

# Project dust765
This project is to address a problem constructed within the toxicity of this community. This is to show the community, open source projects are not meant for cliques and high school drama but rather the expansion of something greater, innovation. -A penny for your thoughts, the adder that prays beneath the rose.

![dust765_logo](https://user-images.githubusercontent.com/77043734/209156140-14558d04-eaf9-42f0-9939-ddec9cf6c1ac.png)

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

# features macros

HighlightTileAtRange (toggle)

# Added files

/src/Dust765

# changed constants

WAIT_FOR_TARGET_DELAY 5000 -> 4000

MAX_CIRCLE_OF_TRANSPARENCY_RADIUS 200 -> 1000

DEATH_SCREEN_TIMER 1500 -> 750

MAX_JOURNAL_HISTORY_COUNT 100 -> 250

# Changed files and line number

no comment possible:

FILE        START   END     COMMIT
README.md   20      *
deploy.yml  5      *

comments:

FILE                                                                START   END     COMMIT
/src/ClassicUO.Client/Configuration/Profile.cs	                    285     *       BASICSETUP

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	                178     180     BASICSETUP

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	                373     377     BASICSETUP

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	                454     458     BASICSETUP

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	                3419    3461    BASICSETUP

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	                4288    4290    BASICSETUP

/src/ClassicUO.Client/Game/Managers/MacroManager.cs                 2335    2359    BASICSETUP

/src/ClassicUO.Client/Game/Managers/MacroManager.cs                 2364    2373    BASICSETUP

/src/ClassicUO.Client/Game/Managers/MacroManager.cs                 2377    2382    BASICSETUP

/src/ClassicUO.Client/Game/Constants.cs                             87              CONSTANTS

/src/ClassicUO.Client/Game/Constants.cs                             101             CONSTANTS

/src/ClassicUO.Client/Game/Constants.cs                             115             CONSTANTS

/src/ClassicUO.Client/Game/Constants.cs                             119             CONSTANTS

/src/ClassicUO.Client/Game/GameObjects/Views/ItemView.cs         37      39      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/ItemView.cs         91      97      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Item.cs                   36      39      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Item.cs                   126     161     ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/GameEffectView.cs   8       10      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/GameEffectView.cs   110     127     ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       35      37      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       95      108     ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       136     149     ART / HUE CHANGES

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs     38      40      ART / HUE CHANGES

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs     675     680     ART / HUE CHANGES

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs     698     702     ART / HUE CHANGES

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs     759     763     ART / HUE CHANGES

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs     854     858     ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Static.cs                 57      59      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Static.cs                 71      75      ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Static.cs                 126     131     ART / HUE CHANGES

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1780    1790    ART / HUE CHANGES

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         34      36      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         84      111     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MultiView.cs        34      36      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MultiView.cs        118     145     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       36      38      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       97      124     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       36      38      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       89      96      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       115     130     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       199     213     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       440     446     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       796     802     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameCursor.cs                         37      39      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameCursor.cs                         80      84      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameCursor.cs                         348     353     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameActions.cs                        53      55      VISUAL HELPERS

/src/ClassicUO.Client/Game/GameActions.cs                        655     658     VISUAL HELPERS

/src/ClassicUO.Client/Game/GameActions.cs                        669     672     VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             34      36      VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             163     166     VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             191     193     VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             235     238     VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1809    1814    VISUAL HELPERS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2361    2363    VISUAL HELPERS

/src/ClassicUO.Client/Network/PacketHandlers.cs                  37      39      VISUAL HELPERS

/src/ClassicUO.Client/Network/PacketHandlers.cs                  927     930     VISUAL HELPERS

# Original readme

<a href="https://discord.gg/VdyCpjQ">
<img src="https://img.shields.io/discord/458277173208547350.svg?logo=discord"
alt="chat on Discord"></a>

Individuals/hobbyists: support continued maintenance and development via the monthly Patreon:
<br>&nbsp;&nbsp;[![Patreon](https://raw.githubusercontent.com/wiki/ocornut/imgui/web/patreon_02.png)](http://www.patreon.com/classicuo)

Individuals/hobbyists: support continued maintenance and development via PayPal:
<br>&nbsp;&nbsp;[![PayPal](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9ZWJBY6MS99D8)


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
