# Game Basic Information #

## Summary ##

In a village located in the middle of nowhere, a survivor fights an impending horde of enemies unique in description and style. The survivor must be resourceful and gather exponentially or multiplicative equipment upgrades to battle their way to the next stage and continue to liberate the various themed locations of enemies. 

## Gameplay Explanation ##

The player survives from the enemy waves as long as possible. The player moves through the 4 arrow keys of up, down, left, right and with consumable buttons of 1,2,3 numpad keys. These consumables vary from increased attack speed, damage, movement speed and health regen and are acquired by vanquishing enemies. On level up players can choose to upgrade health, damage, attack speed or movement speed. As time progresses, waves get more difficult, so survive as long as you can!



# Main Roles #

## Game Logic

### - Enemy AI, Stage Event, Player Level System - Young Cheol Ko

As the main contributor to the game logic, I took responsibility for several crucial components of the game:

#### Enemy AI:
Implemented an enemy controller responsible for enemy movement toward the player. This included defining enemy behavior to actively pursue the player using predefined patterns. Integrated a mechanism to halt enemy movement when shooting actions were initiated. Developed the enemy animator logic to ensure smooth transitions between two different animations, allowing seamless movement and shooting sequences in 4 ways. Programmed the enemy shooting mechanism, determining bullet trajectories and accurate hit detection. Managed enemy stats, including damage-taking, returning to the player when too far away, and dealing collision damage to the player upon contact.

##### - Boss Enemy Behavior:
Designed the behavior for the boss enemy, considering its unique characteristics and role within the game. Defined attack and movement radius for the boss to engage the player within specific ranges. Developed the boss's animation system, incorporating changeable collision hitboxes for accurate attack detection and response.

#### Stage Event Controller:
Created a stage controller system to manage the game's stage progression. Implemented logic to spawn monsters based on predetermined criteria, such as time, count, and spawn intervals. Integrated a dynamic spawning system that randomly spawned enemies from outside the camera's view, adding unpredictability and maintaining gameplay engagement.

##### - Wave System:
As part of the stage events, I integrated a wave system to introduce dynamic challenges for the players. The stages were divided into three distinct sections, each featuring different types of enemies:


1. Goblin Stage:
For the first stage, goblins were the primary enemies. I designed the wave system to gradually increase the number and difficulty of the goblin spawns as the stage progressed. This progressive difficulty kept the gameplay engaging and required players to adapt their strategies accordingly.
![a4](https://github.com/cioudfox/ECS-189-Project/assets/44619284/bfdbc303-3412-455d-b554-5c0a93de63e2)


2. Ogre and Cyclops Stage:
The second stage introduced ogres and cyclops as the main enemies. Similar to the goblin stage, I implemented a wave system that introduced more challenging variations of ogres and cyclops over time. This escalation in difficulty encouraged players to utilize different tactics and abilities to overcome the increased challenge.
![a5](https://github.com/cioudfox/ECS-189-Project/assets/44619284/0642a19e-b4d7-4114-9643-5dc580e7098a)


3. Imp and Efreet Stage:
The third stage showcased imps and efreets as the primary enemies. I designed the wave system in this stage to provide a significant challenge, pushing players' skills to their limits. The waves were carefully crafted to offer intense and demanding encounters, requiring players to make strategic use of their acquired abilities and upgrades. Finally, the dragon, the boss of all these monsters, appears to defeat the player.
![a6](https://github.com/cioudfox/ECS-189-Project/assets/44619284/fc3cad02-332b-4db1-b919-0053e29028b4)

Mess Spawning Event:
For the Goblin and Ogre stages, I created special "mess spawning" events. During these events, enemies would spawn in chaotic and unpredictable patterns, adding intense moments to the gameplay. I carefully crafted the spawning logic to strike a balance between challenge and fairness, allowing players to devise strategies to navigate through the chaotic encounters successfully.

#### Data Structure:
Established a data system to manage various in-game characters and entities. Created structured data for player, enemy, weapon, and stage information, facilitating efficient access and utilization throughout the game.

#### Player Stat Framework:
Developed a player stat framework to handle functionalities such as damage-taking and player level logic. Allowed the player character to receive damage from enemies and hazards, triggering appropriate reactions and consequences. Implemented logic for collecting items affecting the player's level progression, such as experience points and power-ups. Accurately tracked player progression, providing a sense of achievement and growth. 

##### - Level System
I designed a structured level system that allowed players to advance and enhance their character's abilities. The level system was designed to provide a sense of accomplishment and growth throughout the game.

- Experience Points and Gems:
To facilitate character progression, players gained experience points by collecting gems throughout the game. These gems were obtained as drops from defeated enemies or discovered within the game world. Accumulating experience points was essential for leveling up. When players leveled up, an upgrade panel would appear, presenting them with various options to increase the power and capabilities of their character.

- Incremental Capacity Increase:
To maintain a balanced progression curve, I designed the level system to increase the capacity for experience points in each set of five levels. This meant that as players reached specific milestones, they needed to accumulate more experience points to level up further. The increased capacity matched the experience gained from gem drops, ensuring a coherent and rewarding progression system.

Strategic Decision-Making:
With the upgrade panel and the incremental capacity increase, players were encouraged to make strategic choices about their character's development. They needed to consider their playstyle, preferred abilities, and the challenges they faced in the game. This added depth and personalization to the gameplay experience, allowing players to tailor their character's growth according to their preferences.

#### Upgrade System (except Weapon Upgrades):
Designed and implemented an upgrade system, enabling players to enhance their character's abilities as they progressed. Created upgrade options, defined upgrade logic, and integrated corresponding UI elements. Provided players with opportunities to invest in character development and improving attributes. At each level up. upgrade panel will show up on the screen, and the panel allows players to make strategic decisions about which aspects of their character to enhance, such as increasing damage, improving maximum health points, or player movement.

### - Player, item, inventory

**WRITE STUFF HERE YE**


## Animation and Visuals

### Animation
In order to emphasize a simple topdown shooter aesthetic, we used more cartoonish and pixelated 2D model assets for the player, enemies, map, attacks, and items. We bought the rights to use an RPG Asset Mega Bundle. Some of the assets can be viewed here:

* [Fantasy RPG Monster Pack](https://franuka.itch.io/fantasy-rpg-monster-pack) - Assets for animated top-down enemies and their attacks
* [RPG Asset Pack](https://franuka.itch.io/rpg-asset-pack) - Assets used for a grassy tileset, objects, and character sprites

![Model assets](https://github.com/cioudfox/ECS-189-Project/assets/103870157/f7ce0e80-20ff-4503-9b58-402dd8e14497)

As our game has a more simple and old-school feel, our **player and enemy animations** were implemented to match the style. Player animation is simple and has animations for the states of moving left and right based on the player's keyboard input. As the player is constantly attacking in intervals, we made the decision to not implement a player attacking animation, but rather continuous weapon projectile animations coming from the player. The weapon projectile assets are also found in the mentioned bundle. The color of the model also changes upon damage, as we worked to select and combine the appropriate common animation and visual effects to match our gameplay and provide feedback to players.

The 2D enemy models are in a similar pixelated visual style. Enemies all have moving animations going north, east, south, and west, with some enemies flying and some walking. Players and enemies have different animators in Unity with these basic movements and room for more states, such as attacking, idle, and dying animations.

![Animator](https://github.com/cioudfox/ECS-189-Project/assets/103870157/86d962f3-141e-4546-b193-d4605aed0015)

![Blend Tree](https://github.com/cioudfox/ECS-189-Project/assets/103870157/9cf75f20-303e-4e2d-8b01-00f5277d7224)

**[Boss Animation Script that Determines Moving, Attacking, and Dying Animations](https://github.com/cioudfox/ECS-189-Project/blob/ec7c9e47ca0fac16c97ed597c4428ca20e288c85/Generic%20Project%20Name/Assets/Scripts/Enemy/BossAnimator.cs)**

We used a combination of animation and visual effects to make a better **game feel** that centers around being simple and cartoonish. We had similar animation implementations for players and enemies alike for simplicity's sake, while adding slight differences that establishes each sprite as its own type with unique looks, animations, and abilities. Game feel is also improved to feel more active and responsive to player input with clear visual responses and feedback, such color changes when taking damage and enemies that immediately change direction and animations based on the player's input. Additionally, our asset choices reflect our chosen fantasy theme and match our map design's style in terms of bright coloring and pixelated fantastical art.  

### Map Design

**To ensure variation in the map, maps are split into procedurally loaded tiles. To avoid a barren looking map, all tiles have random spawn points with a select list of random items to spawn. Additionally, to add variety and exploration, there are a several different types of tiles with different dynamics and environmental features tacked on. When the player inside a tile moves closer to an edge, an adjacent tile will spawn and randomly generate objects to make it different. There are a total of 8 different tilemaps for the MapSpawner to pick from and 12 different buildings and trees to spawn in the random location. [Randomized Item Script can be found here!](https://github.com/cioudfox/ECS-189-Project/blob/ec7c9e47ca0fac16c97ed597c4428ca20e288c85/Generic%20Project%20Name/Assets/Scripts/PropRandomizer.cs)** 

MS Paint Visualization of Tile Logic:

![Tile backend functionality in Paint](https://github.com/cioudfox/ECS-189-Project/assets/68248379/5418b4cb-f58f-4a0a-849a-eeec2976eead)

**The most important part of this game is to ensure the player gets the feeling of euphoria from the endless vanquishing of mobs. To ensure this, the environment has minimal collisions to enemies for easier access to the player and there are fewer objects to collide with players to ensure mobility and dodging. Even while near bodies of water that the players and walking enemies cannot walk on top of, flying enemies are able to get across to both emphasize their unique enemy abilities in the context of the game and allow continuous combat despite these obstacles.**

**To ensure ease of visibility, the map is a colored in a brighter shade of green to be distinctive from the darker hues of the enemies. Objects that can obscure players such as trees and large buildings also become opaque if a player moves behind it and enemies take priority of being visible on top of objects.**

Opaque buildings, darker goblins, and bright fields!

![ASDFGHJ](https://github.com/cioudfox/ECS-189-Project/assets/68248379/bcc45aa5-eb7d-446c-b592-cb54aac7e8b3)

**Since the game has a more open world to explore, in order to optimize gameplay, our MapOptimizer can disable objects and tilemaps once the player is far enough away. Since the tiles are disabled and not destroyed, they still remember the object items and the correct tile that was spawned. 
[Map Spawner/Chunk Optimizer can be found here!](https://github.com/cioudfox/ECS-189-Project/blob/ec7c9e47ca0fac16c97ed597c4428ca20e288c85/Generic%20Project%20Name/Assets/Scripts/MapController.cs)**


## Input

**WRITE STUFF HERE STEVEN**

**Add an entry for each platform or input style your project supports.**

# Sub-Roles

## UI


**WRITE STUFF HERE JASON. Menu buttons change shades of hue when hovered and click to add more pizzazz. Glamorous bright colors add to the rpg fantasy elements.**

**WRITE STUFF HERE YE**

**WRITE STUFF HERE YOUNG**

Subrole: UI - Young Cheol Ko

Contributed to the user interface (UI) system:

Scene UI:

![a1](https://github.com/cioudfox/ECS-189-Project/assets/44619284/0c80ce2b-7977-4e01-8d8b-8aa85f1ff44e)
![a2](https://github.com/cioudfox/ECS-189-Project/assets/44619284/c984851f-b73c-497c-8c3c-2eb8262c95a5)

Developed UI elements and scripts for the scene controller, character selector, main menu, and ESC menu. Ensured smooth transitions between scenes, allowed character selection, and provided accessible menus for navigation.

Game UI:

![a3](https://github.com/cioudfox/ECS-189-Project/assets/44619284/618507c7-dfc5-419b-9e4f-f25819c5d55d)

Created UI elements for the fixed camera display, time display, player health bar, player experience bar, game over popup, winning popup, score UI, boss health bar, and upgrade system UI. Offered players important information, including health and experience status, and provided visual feedback during gameplay. Conveyed game outcomes through the game over popup and winning popup screens. Tracked and displayed the player's score through the score UI. Enabled monitoring of the boss's health through the boss health bar, adding strategic elements to gameplay.

We added the **spatial elements of object text labels** that appear near items and consumables when the user's cursor hovers over them. The text displays the item or consumable's name and purpose, so the user can clarify on their own accord what the objects in this game are used for, without the descriptions obstructing the game. 

**WRITE STUFF HERE STEVEN**

## STEVEN

**UP TO YOU IF YOU WANT TO MAKE YOUR OWN CATEGORY**

## Audio

**1) [Crystal Caves Music](https://www.gamedevmarket.net/asset/crystal-cavern-game-assets-music)**

**The audio we received was from a free pack. The caves audio theme had a nice jazzy tune to it so we figured it be a fine addition to our 2D pixel style game.**

**2) [Win Game Sound Effect](https://freesound.org/people/EVRetro/sounds/495005/)** - [Code](https://github.com/cioudfox/ECS-189-Project/blob/d9ba4870dd381146096ad5be28a48c85746b334e/Generic%20Project%20Name/Assets/Scripts/Menu/Winning.cs#LL21C6-L21C6)

**Steady and upbeat music plays to celebrate when the player defeats the dragon boss and wins the game. The music has a classic video game feel that fits our fantasy theme.**

**3) [Lose Game Sound Effect](https://freesound.org/people/Jofae/sounds/364929/)** - [Code](https://github.com/cioudfox/ECS-189-Project/blob/d9ba4870dd381146096ad5be28a48c85746b334e/Generic%20Project%20Name/Assets/Scripts/Menu/GameOver.cs#LL22C33-L22C33)

**A shaky and descending sound effect plays when player dies to in order to reflect the tragedy of the loss. The sound is somewhat musical and funky, fitting the atmosphere of the background music as well.**

**Document the sound style.** 




## Press Kit and Trailer

**GENERIC GAME TRAILER HERE**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
