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

# healthbar

highlight lasttarget healthbar

color border by state

flashing outline (many options)

# cursor

Show spell on cursor (and runout countdown)

Color game cursor when targeting (hostile / friendly)

# overhead / underchar

Distance

# oldhealthlines

old healthbars

mana / stamina lines, for self and party, 

bigger version and transparency

# misc

Offscreen targeting

Razor lasttarget sync (Razor lasttarget string - set this to the same lasttarget overhead string as set in Razor, so the ClassicUO lasttarget will be the same as in Razor.)

Black Outline for statics (CURRENTLY BROKEN)

Ignore stamina check

Block Wall of Stone rubberband

Block Energy Field rubberband

# misc2

wireframe view (CURRENTLY BROKEN)

hue impassable tiles

transparent / invisible house and items by Z level from player and min Z from ground

draw mobiles with surface overhead

ignore list for circle of transparency (txt file created in your /Data/Client folder)

show death location on worldmap

# nameoverhead

hp line in nameoverheads

more filters for nameoverheads

# UI gumps

sticky last target healthbar (healthbar that always will be your last targets healthbar)

bandage gump (bandage timer UI)

# features macros

HighlightTileAtRange (toggle)

ToggleTransparentHouses (toggle)

ToggleInvisibleHouses (toggle)

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

/src/ClassicUO.Client/Game/GameObjects/Mobile.cs                 145     148     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             358     361     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             489     492     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             579     582     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             593     596     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             600     689     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             751     780     HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1034    1039    HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1204    1209    HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1311    1316    HEALTHBAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1358    1361    HEALTHBAR

/src/ClassicUO.Client/Game/GameCursor.cs                         38      40      CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         58      62      CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         76      85      CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         91      95      CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         105     113     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         119     123     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         129     133     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         227     254     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         392     396     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         401     405     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         410     414     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         427     440     CURSOR

/src/ClassicUO.Client/Game/GameCursor.cs                         545     549     CURSOR

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        35      37      OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        165     170     OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       60      62      OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             38      40      OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             754     756     OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             2002    2004    OVERHEAD / UNDERCHAR

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        36      39      OLDHEALTHLINES

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        58      83      OLDHEALTHLINES

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        226     246     OLDHEALTHLINES

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        278     298     OLDHEALTHLINES

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        408     482     OLDHEALTHLINES

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 38      40      MISC

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 3648    3651    MISC

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 5681    5700    MISC

/src/ClassicUO.Client/Game/GameObjects/Views/ItemView.cs         98      127     MISC

/src/ClassicUO.Assets/ArtLoader.cs                               453     467     MISC

/src/ClassicUO.Assets/TileDataLoader.cs                          357     359     MISC

/src/ClassicUO.Assets/TileDataLoader.cs                          374     378     MISC

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             74      76      MISC

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             181     185     MISC

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             191     193     MISC

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             237     239     MISC

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             241     250     MISC

/src/ClassicUO.Client/Game/UI/Controls/Control.cs                36      38      MISC

/src/ClassicUO.Client/Game/UI/Controls/Control.cs                81      83      MISC

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         35      37      MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         114     123     MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         129     134     MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         168     173     MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/ItemView.cs         218     240     MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/MultiView.cs        155     167     MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/View.cs             36      39      MISC2

/src/ClassicUO.Client/Game/GameObjects/Views/View.cs             268     276     MISC2

/src/ClassicUO.Assets/TexmapsLoader.cs                           35      39      MISC2

/src/ClassicUO.Assets/TexmapsLoader.cs                           126     131     MISC2

/src/ClassicUO.Assets/TexmapsLoader.cs                           142     146     MISC2

/src/ClassicUO.Assets/TexmapsLoader.cs                           153     158     MISC2

/src/ClassicUO.Assets/TexmapsLoader.cs                           181     210     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               103     107     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               148     165     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               178     195     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               255     260     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               268     272     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               282     286     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               308     312     MISC2

/src/ClassicUO.Assets/ArtLoader.cs                               322     326     MISC2

/src/ClassicUO.Client/Game/Data/StaticFilters.cs                 52      54      MISC2

/src/ClassicUO.Client/Game/Data/StaticFilters.cs                 63      65      MISC2

/src/ClassicUO.Client/Game/Data/StaticFilters.cs                 79      118     MISC2

/src/ClassicUO.Client/Game/Data/StaticFilters.cs                 405     411     MISC2

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1815    1824    MISC2

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2394    2397    MISC2

/src/ClassicUO.Client/Game/UI/Gumps/WorldMapGump.cs              2451    2504    MISC2

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           51      55      MISC2

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 1703    1707    MISC2

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs	 402     419     MISC2

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs	 428     436     MISC2

/src/ClassicUO.Client/Game/Scenes/GameSceneDrawingSorting.cs	 548     553     MISC2

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              41      44      MACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1829    1949    MACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2488+           MACROS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           1367    1379    MACROS

/src/ClassicUO.Client/Game/Scenes/GameSceneInputHandler.cs       37      39      MACROS

/src/ClassicUO.Client/Game/Scenes/GameSceneInputHandler.cs       1451    1462    MACROS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 2345    2348    MACROS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 5581    5584    MACROS

/src/ClassicUO.Client/Game/World.cs                              37      39      MACROS

/src/ClassicUO.Client/Game/World.cs                              98      100     MACROS

/src/ClassicUO.Client/Configuration/Profile.cs                   38      40      MACROS

/src/ClassicUO.Client/Configuration/Profile.cs                   638     643     MACROS

/src/ClassicUO.Client/Game/UI/Gumps/GumpType.cs                  60      62      MACROS

/src/ClassicUO.Client/Configuration/Profile.cs                   209     213     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             59      63      NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             420     422     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             504     506     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             5451    5454    NAMEOVERHEAD

/src/ClassicUO.Client/Game/GameObjects/Views/ItemView.cs         273     277     NAMEOVERHEAD

/src/ClassicUO.Client/Game/GameObjects/Item.cs                   40      42      NAMEOVERHEAD

/src/ClassicUO.Client/Game/GameObjects/Item.cs                   197     199     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     155     157     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     356     358     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     620     624     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     625     657     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameSceneInputHandler.cs       1317    1322    NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameSceneInputHandler.cs       1469    1471    NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         56      127     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         157     197     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         326     328     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         575     580     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         627     632     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         658     709     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadGump.cs	         800     825     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       34      44      NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       52      96      NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       102     105     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       107     121     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       123     155     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       157     161     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       170     198     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       202     285     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       310     314     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       316     498     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       500     568     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadHandlerGump.cs	 34      36      NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadHandlerGump.cs	 49      56      NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverHeadHandlerGump.cs   63      74      NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadHandlerGump.cs	 91      276     NAMEOVERHEAD

/src/ClassicUO.Client/Game/UI/Gumps/NameOverheadHandlerGump.cs	 289     356     NAMEOVERHEAD

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   38      41      UI/GUMPS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   204     218     UI/GUMPS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   327     329     UI/GUMPS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           37      39      UI/GUMPS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           59      61      UI/GUMPS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           67      69      UI/GUMPS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 4725    4727    UI/GUMPS

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs               38      40      UI/GUMPS

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
