<p align="center">
    <img src="https://i.imgur.com/CgpwyIQ.png" width="190" height="200" >
</p>

An open source implementation of the Ultima Online Classic Client.

[![GitHub Actions Status](https://github.com/dust765/ClassicUO/workflows/Build-Test/badge.svg)](https://github.com/dust765/ClassicUO/actions)
[![GitHub Actions Status](https://github.com/dust765/ClassicUO/workflows/Deploy/badge.svg)](https://github.com/dust765/ClassicUO/actions)

# Project dust765
This project is to address a problem constructed within the toxicity of this community. This is to show the community, open source projects are not meant for cliques and high school drama but rather the expansion of something greater, innovation. -A penny for your thoughts, the adder that prays beneath the rose.

![dust765_logo](https://user-images.githubusercontent.com/77043734/209156140-14558d04-eaf9-42f0-9939-ddec9cf6c1ac.png)

# BRANCHES

main is 1:1 from upstream (Karasho)

dev_dust765 stable release

dev_dust765_activedev stable work in progress releases

dev_dust765_x_tazuo Dust765 and TazUO merged

# contact and team info

Discord: dust765#2787

Dust765: 7 Link, 6 Gaechti, 5 Syrupz

Join me on TazUO discord:
<a href="https://discord.gg/SqwtB5g95H">
<img src="https://img.shields.io/discord/1087124353155608617.svg?logo=discord"
alt="chat on Discord"></a>

# feature showcase

[Video Part 1 on YouTube](https://youtu.be/aqHiiOhx8Q8)

[Video Part 2 on YouTube](https://youtu.be/P7YBrI3s6ZI)

[Video Part 3 on YouTube](https://youtu.be/074Osj1Fcrg)

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

# visual response manager (WIP)

goal is to have a visual response on your character from various triggers.

bandies, pots, clilocs,....

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

# Original readme
Individuals/hobbyists: support continued maintenance and development via the monthly Patreon:
<br>&nbsp;&nbsp;[![Patreon](https://raw.githubusercontent.com/wiki/ocornut/imgui/web/patreon_02.png)](http://www.patreon.com/classicuo)

Individuals/hobbyists: support continued maintenance and development via PayPal:
<br>&nbsp;&nbsp;[![PayPal](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9ZWJBY6MS99D8)

<a href="https://discord.gg/VdyCpjQ">
<img src="https://img.shields.io/discord/458277173208547350.svg?logo=discord"
alt="chat on Discord"></a>

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
