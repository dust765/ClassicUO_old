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

Black Outline for statics

Ignore stamina check

Block Wall of Stone rubberband

Block Energy Field rubberband

# misc2

wireframe view

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

Tavern - Diable auto disarm.

# features macros

HighlightTileAtRange (toggle)

ToggleTransparentHouses (toggle)

ToggleInvisibleHouses (toggle)

UCCLinesToggleLT (toggle)

UCCLinesToggleHM (toggle)

AutoMeditate (toggle)

ToggleECBuffGump / ToggleECDebuffGump / ToggleECStateGump / ToggleModernCooldownBar (toggle)

# simple macros

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

-autorange (auto show range indicator when weapon is equipped) (edit autorange.txt in /Data/Client to adjust range for individual weapons)

# outlands

disabled features due to client enforcement (code updates NOT maintained)

inferno bridge solver (color specific land tiles)

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

# POC

proof of concepts

guardlines: show guardlines on land tiles (disabled due to performance)

# gridloot

The order in which items are shown in grid-loot will now depend on item type.

Motivation: some items are likely to be always looted (e.g. gold, gems) and when looting is performed automatically (e.g. by Razor macros) it makes items to move in a grid making it harder to browse their properties. Hence, items like gold should be at the end of the grid.

# multi journal

Replaces journal with multiple nameable and much better configurable journals

note: edit journals.xml in your profile folder, set hue to 0 if you wish to reset color to default

(use macro OpenJournal2 for old journal)

# status gump

adds a version of the status gump with health / mana / stamina bar when expanded

# modern cooldown bar

adds a macro to open a BuffGump for each type (blue, green, red) similar to the EC client

note: edit ecbuffs.txt / ecdebuffs.txt / ecstates.txt in /Data/Client to swap icons arround

adds a modern version of the cooldown bar

note: filter displayed buffs with modernbuffs.txt in /Data/Client, the EC txt are used to determine color

# on casting gump

shows a little gump on cursor when casting (can be hidden)

main purpose being, to prevent rubberband on servers that dont send a freeze packet during casting

(mod by Mark)

# show all layers

shows all equipment layers on mobiles (covered items should show)

(mod by Mark)

show additional equipment slots on paperdoll (for torso/arms/pants/shoes/cloak)

# thief supreme

override container open range (ie. backpacks dont close until paperdoll gets closed)

hide X macro has been update to hide items inside containers

# Added files

/src/Dust765

/src/Dust765/External

/src/halo.png

/src/arrow.png

/src/Dust765/Macros

/src/Dust765/Managers

/src/Dust765/Autos

/src/Dust765/Shared

/src/Dust765/Lobby

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

/src/Game/GameCursor.cs                         58      62      CURSOR

/src/Game/GameCursor.cs                         76      85      CURSOR

/src/Game/GameCursor.cs                         91      95      CURSOR

/src/Game/GameCursor.cs                         105     113     CURSOR

/src/Game/GameCursor.cs                         119     123     CURSOR

/src/Game/GameCursor.cs                         129     133     CURSOR

/src/Game/GameCursor.cs                         227     254     CURSOR

/src/Game/GameCursor.cs                         392     396     CURSOR

/src/Game/GameCursor.cs                         401     405     CURSOR

/src/Game/GameCursor.cs                         410     414     CURSOR

/src/Game/GameCursor.cs                         427     440     CURSOR

/src/Game/GameCursor.cs                         545     549     CURSOR

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

/src/Game/Scenes/GameSceneDrawingSorting.cs	    545     550     MISC2

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

/src/Configuration/Profile.cs                   207     211     NAMEOVERHEAD

/src/Game/UI/Gumps/OptionsGump.cs	            60      64      NAMEOVERHEAD

/src/Game/UI/Gumps/OptionsGump.cs	            419     421     NAMEOVERHEAD

/src/Game/UI/Gumps/OptionsGump.cs	            503     505     NAMEOVERHEAD

/src/Game/UI/Gumps/OptionsGump.cs	            5394    5397    NAMEOVERHEAD

/src/Game/GameObjects/Views/ItemView.cs         273     277     NAMEOVERHEAD

/src/Game/GameObjects/Item.cs                   40      42      NAMEOVERHEAD

/src/Game/GameObjects/Item.cs                   197     199     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs           	    155     157     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs           	    356     358     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs           	    620     624     NAMEOVERHEAD

/src/Game/Scenes/GameSceneInputHandler.cs       1241    1246    NAMEOVERHEAD

/src/Game/Scenes/GameSceneInputHandler.cs       1386    1388    NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        56      127     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        157     197     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadGump.cs	        640     691     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	34      36      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	49      53      NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	77      216     NAMEOVERHEAD

/src/Game/UI/Gumps/NameOverheadHandlerGump.cs	229     293     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       34      44      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       52      96      NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       102     105     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       107     121     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       123     142     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       151     179     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       183     266     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       291     295     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       297     452     NAMEOVERHEAD

/src/Game/Managers/NameOverHeadManager.cs       454     522     NAMEOVERHEAD

/src/Game/Scenes/GameScene.cs                   38      41      UI/GUMPS

/src/Game/Scenes/GameScene.cs                   204     218     UI/GUMPS

/src/Game/Scenes/GameScene.cs                   327     329     UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           38      40      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           59      61      UI/GUMPS

/src/Game/GameObjects/PlayerMobile.cs           67      69      UI/GUMPS

/src/Network/PacketHandlers.cs	                4616    4618    UI/GUMPS

/src/Game/UI/Gumps/OptionsGump.cs               39      41      UI/GUMPS

/src/Game/Managers/MacroManager.cs              1176    1180    UI/GUMPS

/src/Game/Scenes/GameScene.cs                   94      96      TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   165     167     TEXTUREMANAGER

/src/Game/Scenes/GameScene.cs                   1232    1234    TEXTUREMANAGER

/src/ClassicUO.csproj	                        64      82      TEXTUREMANAGER

/src/Game/Managers/MacroManager.cs              1176    1180    LINES

/src/Game/Managers/MacroManager.cs              1912    1929    LINES

/src/Game/Managers/MacroManager.cs              2442    2445    LINES

/src/Game/Scenes/GameScene.cs                   97      99      LINES

/src/Game/Scenes/GameScene.cs                   171     173     LINES

/src/Game/Scenes/GameScene.cs                   231     241     LINES

/src/Game/Scenes/GameScene.cs                   1252    1254    LINES

/src/Game/Managers/MacroManager.cs              1176    1180    AUTOLOOT

/src/Game/GameObjects/Entity.cs                 75      77      AUTOLOOT

/src/Network/PacketHandlers.cs	                830     839     AUTOLOOT

/src/Network/PacketHandlers.cs	                4329    4638    AUTOLOOT

/src/Game/Scenes/GameScene.cs                   242     252     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            35      37      AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            97      115     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            178     190     AUTOLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            242     249     AUTOLOOT

/src/Game/Managers/MacroManager.cs              1176    1180    BUFFBAR/UCCSETTINGS

/src/Game/Scenes/GameScene.cs                   253     263     BUFFBAR/UCCSETTINGS

/src/Game/Scenes/GameScene.cs                   375     380     BUFFBAR/UCCSETTINGS

/src/Game/World.cs                              100     102     BUFFBAR/UCCSETTINGS

/src/Network/PacketHandlers.cs	                4639    4641    BUFFBAR/UCCSETTINGS

/src/Game/Scenes/GameScene.cs                   264     274     SELF

/src/Game/Scenes/GameScene.cs                   387     392     SELF

/src/Game/Managers/MacroManager.cs              1176    1180    SELF

/src/Game/Managers/MacroManager.cs              1517    1529    SELF

/src/Game/Managers/TargetManager.cs             59      61      ADVMACROS

/src/Game/Managers/TargetManager.cs             428     450     ADVMACROS

/src/Game/Managers/MacroManager.cs              46      49      ADVMACROS

/src/Game/Managers/MacroManager.cs              1948    2158    ADVMACROS

/src/Game/Managers/MacroManager.cs              2662    *       ADVMACROS

/src/Game/Managers/MacroManager.cs              2946    2986    ADVMACROS

/src/Game/GameObjects/PlayerMobile.cs           1390    1410    ADVMACROS

/src/Game/GameObjects/Views/LandView.cs         99      105     AUTOMATIONS

/src/Game/GameObjects/Views/MultiView.cs        132     138     AUTOMATIONS

/src/Game/GameObjects/Views/StaticView.cs       111     117     AUTOMATIONS

/src/Game/Managers/MacroManager.cs              2159    2165    AUTOMATIONS

/src/Game/Managers/MacroManager.cs              2697    2699    AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   275     277     AUTOMATIONS

/src/Game/Scenes/GameScene.cs                   435     443     AUTOMATIONS

/src/Game/World.cs                              369     371     AUTOMATIONS

/src/Network/PacketHandlers.cs	                46      48      AUTOMATIONS

/src/Network/PacketHandlers.cs	                843     846     AUTOMATIONS

/src/Network/PacketHandlers.cs	                2133    2135    AUTOMATIONS

/src/Network/PacketHandlers.cs	                2358    2360    AUTOMATIONS

/src/Network/PacketHandlers.cs	                3044    3046    AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              68      79      AUTOMATIONS

/src/Game/UI/Gumps/WorldMapGump.cs              2518    2605    AUTOMATIONS

/src/Game/Map/Chunk.cs                          35      37      OUTLANDS

/src/Game/Map/Chunk.cs                          138     141     OUTLANDS

/src/Network/PacketHandlers.cs	                2361    2364    OUTLANDS

/src/Network/PacketHandlers.cs	                3599    3610    OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        200     213     OUTLANDS

/src/Game/Managers/HealthLinesManager.cs        262     274     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             111     113     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             128     131     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             397     399     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             436     438     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             591     628     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             741     752     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             844     846     OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1442    1457    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1616    1618    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             1851    1866    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             2024    2061    OUTLANDS

/src/Game/UI/Gumps/HealthBarGump.cs             2175    2177    OUTLANDS

/src/Game/GameObjects/Mobile.cs                 150     159     OUTLANDS

/src/Game/GameObjects/Views/MobileView.cs       63      67      OUTLANDS

/src/Game/UI/Gumps/Login/LoginGump.cs	        419     429     LOGIN

/src/Game/Managers/MacroManager.cs              2166    2202    LOBBY

/src/Game/Managers/MacroManager.cs              2753    2760    LOBBY

/src/Game/Map/Chunk.cs                          35      38      POC - GUARDLINE

/src/Game/Map/Chunk.cs                          70      72      POC - GUARDLINE

/src/Game/Map/Chunk.cs                          119     122     POC - GUARDLINE

/src/Game/Map/Chunk.cs                          493     515     POC - GUARDLINE

/src/Game/UI/Gumps/GridLootGump.cs	            270     285     GRIDLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            314     316     GRIDLOOT

/src/Game/UI/Gumps/GridLootGump.cs	            358     368     GRIDLOOT

/src/Game/GameActions.cs                        144     148     MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            37      42      MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            58      65      MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            67      71      MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            159     255     MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            267     271     MULTIJOURNAL

/src/Game/Managers/JournalManager.cs            271     319     MULTIJOURNAL

/src/Game/Managers/MessageManager.cs            115     117     MULTIJOURNAL

/src/Game/Managers/MessageManager.cs            121     123     MULTIJOURNAL

/src/Game/Scenes/GameScene.cs           	    405     409     MULTIJOURNAL

/src/Game/UI/Controls/ExpandableScroll.cs       273     278     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               38      40      MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               61      64      MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               66      70      MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               80      86      MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               89      136     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               154     275     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               280     312     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               372     379     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               450     455     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               470     474     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               493     497     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               647     651     MULTIJOURNAL

/src/Game/UI/Gumps/JournalGump.cs               698     731     MULTIJOURNAL

/src/Configuration/Profile.cs	                74      77      MULTIJOURNAL

/src/Game/UI/Gumps/OptionsGump.cs	            161     167     MULTIJOURNAL

/src/Game/UI/Gumps/OptionsGump.cs	            478     480     MULTIJOURNAL

/src/Game/UI/Gumps/OptionsGump.cs	            2568    2592    MULTIJOURNAL

/src/Game/UI/Gumps/OptionsGump.cs	            5618    5621    MULTIJOURNAL

/src/Game/UI/Gumps/OptionsGump.cs	            5986    5989    MULTIJOURNAL

/src/Game/GameActions.cs	                    144     148     MULTIJOURNAL

/src/Network/PacketHandlers.cs	                2108    2110    MULTIJOURNAL

/src/Resources/ResGumps.Designer.cs             1468    1477    MULTIJOURNAL

/src/Resources/ResGumps.Designer.cs             2607    2733    MULTIJOURNAL

/src/Resources/ResGumps.Designer.cs             2942    2951    MULTIJOURNAL

/src/Resources/ResGumps.resx                    1570    1619    MULTIJOURNAL

CombatCollection.cs                             1996    2088    UNUSED

/src/Game/Managers/NameOverHeadManager.cs       141     145     NAMEOVERHEAD_FIXES

/src/Game/Managers/NameOverHeadManager.cs       328     332     NAMEOVERHEAD_FIXES

/src/Game/Managers/NameOverHeadManager.cs       365     369     NAMEOVERHEAD_FIXES

/src/Game/UI/Gumps/NameOverHeadHandlerGump.cs   50      54      NAMEOVERHEAD_FIXES

/src/Configuration/Profile.cs	                533     535     CONSIDERBALANCED

/src/Configuration/Profile.cs	                41      43      MODERNCOOLDOWNBAR

/src/Configuration/Profile.cs	                763     783     MODERNCOOLDOWNBAR

/src/Game/Managers/MacroManager.cs              1176    1180    MODERNCOOLDOWNBAR

/src/Game/Managers/MacroManager.cs              2207    2263    MODERNCOOLDOWNBAR

/src/Game/Managers/MacroManager.cs              2826    2831    MODERNCOOLDOWNBAR

/src/Game/UI/Gumps/GumpType.cs                  63      68      MODERNCOOLDOWNBAR

/src/Network/PacketHandlers.cs	                5447    5452    MODERNCOOLDOWNBAR

/src/Network/PacketHandlers.cs	                5459    5464    MODERNCOOLDOWNBAR

/src/Network/PacketHandlers.cs	                5523    5528    MODERNCOOLDOWNBAR

/src/Client.cs	                                38      40      MODERNCOOLDOWNBAR

/src/Client.cs	                                196     198     MODERNCOOLDOWNBAR

/src/Network/PacketHandlers.cs                  276     278     ONCASTINGGUMP

/src/Network/PacketHandlers.cs                  387     389     ONCASTINGGUMP

/src/Network/PacketHandlers.cs                  4673    4678    ONCASTINGGUMP

/src/Game/GameActions.cs                        57      59      ONCASTINGGUMP

/src/Game/GameActions.cs                        666     672     ONCASTINGGUMP

/src/Game/GameActions.cs                        687     693     ONCASTINGGUMP

/src/Game/GameObjects/PlayerMobile.cs           62      64      ONCASTINGGUMP

/src/Game/GameObjects/PlayerMobile.cs           73      75      ONCASTINGGUMP

/src/Game/GameObjects/PlayerMobile.cs           1626    1628    ONCASTINGGUMP

/src/Game/Scenes/GameScene.cs           	    278     286     ONCASTINGGUMP

/src/Configuration/Profile.cs	                550     553     ONCASTINGGUMP

/src/Configuration/Profile.cs	                554     558     SHOWALLLAYERS

/src/Game/GameObjects/Views/MobileView.cs       1166    1171    SHOWALLLAYERS

/src/Game/UI/Gumps/PaperdollGump.cs             71      73      SHOWALLLAYERS

/src/Game/UI/Gumps/PaperdollGump.cs             377     454     SHOWALLLAYERS

/src/Game/UI/Gumps/PaperdollGump.cs             724     734     SHOWALLLAYERS

/src/Configuration/Profile.cs	                559     561     THIEFSUPREME

/src/Game/GameObjects/PlayerMobile.cs           1550    1557    THIEFSUPREME

/src/Game/Managers/MacroManager.cs              1944    1956    THIEFSUPREME

/src/Game/Managers/MacroManager.cs              1963    1966    THIEFSUPREME

/src/Game/UI/Gumps/ContainerGump.cs             465     473     THIEFSUPREME

/src/Game/UI/Gumps/ContainerGump.cs             536     541     THIEFSUPREME


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
