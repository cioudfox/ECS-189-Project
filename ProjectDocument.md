# Game Basic Information #

## Summary ##

In a village located in the middle of nowhere, a survivor fights an impending horde of enemies unique in description and style. The survivor must be resourceful and gather exponentially or multiplicative equipment upgrades to battle their way to the next stage and continue to liberate the various themed locations of enemies. 

## Gameplay Explanation ##

The player survives from the enemy waves as long as possible. The player moves through the 4 arrow keys of up, down, left, right and with consumable buttons of 1,2,3 numpad keys. These consumables vary from increased attack speed, damage, movement speed and health regen and are acquired by vanquishing enemies. On level up players can choose to upgrade health, damage, attack speed or movement speed. As time progresses, waves get more difficult, so survive as long as you can!



# Main Roles #

## Game Logic

### - Enemy AI, Stage Event, Player Level System

**WRITE STUFF HERE YOUNG**


### - Player, item, inventory

**WRITE STUFF HERE YE**


## Animation and VISUALS

**WRITE STUFF HERE MEGAN**

## Map Design

**To ensure variation in the map, maps are split into procedurally loaded tiles. To avoid a barren looking map, all tiles have random spawn points with a select list of random items to spawn. Additionally, to add variety and exploration, there are a several different types of tiles with different dynamics and environmental features tacked on. When the player inside a tile moves closer to an edge, an adjacent tile will spawn and randomly generate objects to make it different. There are a total of 8 different tilemaps for the MapSpawner to pick from and 12 different buildings and trees to spawn in the random location.** 
![Tile backend functionality in Paint](https://github.com/cioudfox/ECS-189-Project/assets/68248379/5418b4cb-f58f-4a0a-849a-eeec2976eead)

**The most important part of this game is to ensure the player gets the feeling of euphoria from the endless vanquishing of mobs. To ensure this, the environment has minimal collisions to enemies for easier access to the player and there are less objects to collide with players to ensure mobility and dodging. Similarly, to ensure ease of visibilty, the map is a colored in a brighter shade of green to be distinctive from the darker hues of the enemies. Objects that can obscure players such as trees and large buildings also become opaque if a player moves behind it and enemies take priority of being visible on top of objects.**
![Opaque buildings, darker goblins, and bright fields!](https://github.com/cioudfox/ECS-189-Project/assets/68248379/bcc45aa5-eb7d-446c-b592-cb54aac7e8b3)

**Since the game has a more open world to explore, in order to optimize gameplay, our MapOptimizer can disable objects and tilemaps once the player is far enough away. Since the tiles are disabled and not destroyed, they still remember the object items and the correct tile that was spawned. **

## Input

**WRITE STUFF HERE STEVEN**

**Add an entry for each platform or input style your project supports.**

# Sub-Roles

## UI

**WRITE STUFF HERE MEGAN**
**WRITE STUFF HERE JASON**
**WRITE STUFF HERE YE**
**WRITE STUFF HERE YOUNG**
**WRITE STUFF HERE STEVEN**

## STEVEN

**UP TO YOU IF YOU WANT TO MAKE YOUR OWN CATEGORY**

## Audio

**1) [Crystal Caves Music](https://www.gamedevmarket.net/asset/crystal-cavern-game-assets-music)**

**The audio we received was from a free pack. The caves audio theme had a nice jazzy tune to it so we figured it be a fine addition to our 2D pixel style game.**

**Document the sound style.** 




## Press Kit and Trailer

**GENERIC GAME TRAILER HERE**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
