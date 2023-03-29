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

imrpoved filters with txt file in profile folder (mod by pkrion)

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

proof of concept

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

show additional equipment slots on paperdoll (for torso/arms/pants/shirt/skirt)

# thief supreme

override container open range (ie. backpacks dont close until paperdoll gets closed)

hide X macro has been update to hide items inside containers

# visual response manager

offers visual responses on your character from various triggers.

bandies, pots, clilocs,....

# tabgrid

open a grid for your macros

(mod by pkrion)

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

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   94      96      TEXTUREMANAGER

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   165     167     TEXTUREMANAGER

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   1252    1254    TEXTUREMANAGER

/src/ClassicUO.Client/ClassicUO.csproj	                         23      41      TEXTUREMANAGER

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1950    1967    LINES

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2525    2528    LINES

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   97      99      LINES

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   171     173     LINES

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   231     241     LINES

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   1272    1274    LINES

/src/ClassicUO.Client/Game/GameObjects/Entity.cs                 75      77      AUTOLOOT

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 929     938     AUTOLOOT

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 4738    4747    AUTOLOOT

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   242     252     AUTOLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             35      37      AUTOLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             97      115     AUTOLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             178     190     AUTOLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             242     249     AUTOLOOT

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   253     263     BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   375     380     BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Game/World.cs                              101     103     BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 4748    4750    BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Dust765/Dust765/AnimationTriggers.cs       43      46      BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Dust765/Dust765/AnimationTriggers.cs       55      58      BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Dust765/Dust765/ClilocTriggers.cs          75      *       BUFFBAR/UCCSETTINGS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   264     274     SELF

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   387     392     SELF

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1551    1563    SELF

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             59      61      ADVMACROS

/src/ClassicUO.Client/Game/Managers/TargetManager.cs             428     450     ADVMACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              45      48      ADVMACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2043    2253    ADVMACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2620    2626    ADVMACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2801    *       ADVMACROS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              3099    3139    ADVMACROS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           1390    1410    ADVMACROS

/src/ClassicUO.Client/Game/GameObjects/Views/LandView.cs         100     106     AUTOMATIONS

/src/ClassicUO.Client/Game/GameObjects/Views/MultiView.cs        132     138     AUTOMATIONS

/src/ClassicUO.Client/Game/GameObjects/Views/StaticView.cs       111     117     AUTOMATIONS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2254    2260    AUTOMATIONS

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2837    2839    AUTOMATIONS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   275     277     AUTOMATIONS

/src/ClassicUO.Client/Game/Scenes/GameScene.cs                   435     443     AUTOMATIONS

/src/ClassicUO.Client/Game/World.cs                              370     372     AUTOMATIONS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 42      44      AUTOMATIONS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 942     945     AUTOMATIONS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 2232    2234    AUTOMATIONS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 2456    2458    AUTOMATIONS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 3138    3140    AUTOMATIONS

/src/ClassicUO.Client/Game/UI/Gumps/WorldMapGump.cs              68      79      AUTOMATIONS

/src/ClassicUO.Client/Game/UI/Gumps/WorldMapGump.cs              2518    2605    AUTOMATIONS

/src/ClassicUO.Client/Game/Map/Chunk.cs                          35      37      OUTLANDS

/src/ClassicUO.Client/Game/Map/Chunk.cs                          138     141     OUTLANDS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 2459    2462    OUTLANDS

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 3696    3707    OUTLANDS

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        200     213     OUTLANDS

/src/ClassicUO.Client/Game/Managers/HealthLinesManager.cs        262     274     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             110     112     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             127     130     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             396     398     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             435     437     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             590     627     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             740     751     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             843     845     OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1441    1456    OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1615    1617    OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             1850    1865    OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             2023    2060    OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/HealthBarGump.cs             2174    2176    OUTLANDS

/src/ClassicUO.Client/Game/GameObjects/Mobile.cs                 149     158     OUTLANDS

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       63      67      OUTLANDS

/src/ClassicUO.Client/Game/UI/Gumps/Login/LoginGump.cs	         418     428     LOGIN

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2261    2303    LOBBY

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2899    2906    LOBBY

/src/ClassicUO.Client/Game/Map/Chunk.cs                          35      38      POC - GUARDLINE

/src/ClassicUO.Client/Game/Map/Chunk.cs                          70      72      POC - GUARDLINE

/src/ClassicUO.Client/Game/Map/Chunk.cs                          118     121     POC - GUARDLINE

/src/ClassicUO.Client/Game/Map/Chunk.cs                          492     730     POC - GUARDLINE

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             270     285     GRIDLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             314     316     GRIDLOOT

/src/ClassicUO.Client/Game/UI/Gumps/GridLootGump.cs	             358     368     GRIDLOOT

/src/ClassicUO.Client/Game/GameActions.cs                        144     148     MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            37      42      MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            58      65      MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            67      71      MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            159     255     MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            267     271     MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/JournalManager.cs            271     319     MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/MessageManager.cs            115     117     MULTIJOURNAL

/src/ClassicUO.Client/Game/Managers/MessageManager.cs            121     123     MULTIJOURNAL

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     405     409     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Controls/ExpandableScroll.cs       273     278     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               38      40      MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               61      64      MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               66      70      MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               80      86      MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               89      136     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               154     275     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               280     312     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               372     379     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               450     455     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               470     474     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               493     497     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               647     651     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/JournalGump.cs               698     731     MULTIJOURNAL

/src/ClassicUO.Client/Configuration/Profile.cs	                 74      77      MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             161     167     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             479     481     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             566     568     MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             2598    2620    MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             3776    3835    MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             5668    5671    MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             6039    6042    MULTIJOURNAL

/src/ClassicUO.Client/Game/UI/Gumps/OptionsGump.cs	             6725    6745    MULTIJOURNAL

/src/ClassicUO.Client/Game/GameActions.cs	                     143     147     MULTIJOURNAL

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 2207    2209    MULTIJOURNAL

/src/ClassicUO.Client/Resources/ResGumps.Designer.cs             1468    1477    MULTIJOURNAL

/src/ClassicUO.Client/Resources/ResGumps.Designer.cs             2641    2765    MULTIJOURNAL

/src/ClassicUO.Client/Resources/ResGumps.Designer.cs             2974    2982    MULTIJOURNAL

/src/ClassicUO.Client/Resources/ResGumps.resx                    1585    1634    MULTIJOURNAL

/src/ClassicUO.Client/Dust765/External/JournalGump2.cs           316     320     MULTIJOURNAL

/src/ClassicUO.Client/Dust765/Dust765/CombatCollection.cs        1774    1866    UNUSED

/src/ClassicUO.Client/Game/UI/Gumps/StatusGump.cs	             139     166     STATUSGUMP

/src/ClassicUO.Client/Game/UI/Gumps/StatusGump.cs	             185     212     STATUSGUMP

/src/ClassicUO.Client/Game/UI/Gumps/StatusGump.cs	             2134    3217    STATUSGUMP

/src/ClassicUO.Client/Configuration/Profile.cs	                 41      43      MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Configuration/Profile.cs	                 548     550     MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Configuration/Profile.cs	                 770     790     MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1214    1228    UI/GUMPS / LINES / AUTOLOOT / BUFFBAR/UCCSETTINGS / SELF / MODERNCOOLDOWNBAR 

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2318    2374    MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2983    2988    MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Game/UI/Gumps/GumpType.cs                  63      68      UI/GUMPS / LINES / AUTOLOOT / BUFFBAR/UCCSETTINGS / SELF / MODERNCOOLDOWNBAR 

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 5556    5561    MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 5568    5573    MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Network/PacketHandlers.cs	                 5632    5637    MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Client.cs	                                 36      38      MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Client.cs	                                 193     195     MODERNCOOLDOWNBAR

/src/ClassicUO.Client/Network/PacketHandlers.cs                  376     379     ONCASTINGGUMP

/src/ClassicUO.Client/Network/PacketHandlers.cs                  487     490     ONCASTINGGUMP

/src/ClassicUO.Client/Network/PacketHandlers.cs                  4782    4787    ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameActions.cs                        56      58      ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameActions.cs                        666     672     ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameActions.cs                        687     693     ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           62      64      ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           73      75      ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           1626    1628    ONCASTINGGUMP

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     278     286     ONCASTINGGUMP

/src/ClassicUO.Client/Game/GameObjects/Views/MobileView.cs       1166    1171    MISC3 SHOWALLLAYERS

/src/ClassicUO.Client/Game/UI/Gumps/PaperdollGump.cs             71      73      MISC3 SHOWALLLAYERS

/src/ClassicUO.Client/Game/UI/Gumps/PaperdollGump.cs             377     454     MISC3 SHOWALLLAYERS

/src/ClassicUO.Client/Game/UI/Gumps/PaperdollGump.cs             724     734     MISC3 SHOWALLLAYERS

/src/ClassicUO.Client/Game/GameObjects/PlayerMobile.cs           1550    1557    MISC3 THIEFSUPREME

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2000    2012    MISC3 THIEFSUPREME

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              2019    2022    MISC3 THIEFSUPREME

/src/ClassicUO.Client/Game/UI/Gumps/ContainerGump.cs             465     473     MISC3 THIEFSUPREME

/src/ClassicUO.Client/Game/UI/Gumps/ContainerGump.cs             536     541     MISC3 THIEFSUPREME

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1590    1592    VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Game/Managers/MacroManager.cs              1610 ~  1716    VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Game/Scenes/GameScene.cs           	     1341    1343    VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Game/World.cs                              104     106     VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Network/PacketHandlers.cs                  4782    4787    VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Network/Plugin.cs                          672     675     VISUALRESPONSEMANAGER

/src/ClassicUO.Client/Configuration/Profile.cs	                 812     816     TABGRID

/src/ClassicUO.Client/Game/UI/Gumps/GumpType.cs                  60      62      TABGRID

/src/ClassicUO.Client/Resources/ResGumps.Designer.cs             1378    1387    TABGRID

/src/ClassicUO.Client/Resources/ResGumps.resx                    1635    1639    TABGRID

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       48      50      NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       67      69      NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       104     174     NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       212     215     NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       306     312     NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       331     420     NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       554     620     NAMEOVERHEAD IMPROVEMENTS

/src/ClassicUO.Client/Game/Managers/NameOverHeadManager.cs       659     663     NAMEOVERHEAD IMPROVEMENTS

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
