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

### - Player, Item, Inventory, Damage Popup - Hongye Xu

#### Player Controller:
The player controller includes precise control over the character's attack toward the cursor and character movement, as well as enabling seamless item usage through intuitive keybindings (1, 2, and 3). Additionally, I have implemented smooth item pickup mechanics and the ability to effortlessly open and close the inventory by pressing the "I" key. To achieve these functionalities, I have employed the command design pattern. Furthermore, I have diligently incorporated the necessary logic for applying effects when items are utilized. This ensures that the game's mechanics remain coherent and consistent, allowing players to strategize and make informed decisions regarding their inventory usage. [The main player controller script](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/Player/PlayerController.cs#L6).

#### Item:
Within the item collection and item controller systems, I have implemented dynamic mechanics that enhance the realism and immersion of dropped items. When items are dropped, they scatter in random directions, adding a sense of unpredictability and excitement to the gameplay experience. By introducing this randomness, players need to adapt and react accordingly. Furthermore, to maintain balance and prevent clutter within the game world, I have implemented a limited existence life for dropped items. Each item is programmed to have a predefined lifespan, after which it will naturally disappear. This ensures that the game world remains uncluttered and that players are encouraged to promptly collect items to benefit from their associated advantages. [Item Class](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/Item/Item.cs#LL5C17-L5C17), [Item controller script](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/Item/ItemController.cs#L5).

#### Inventory:
The inventory system provides players with a comprehensive and user-friendly interface to view and manage their collected items. With this system in place, players can effortlessly access vital information such as the quantity of each item at their disposal. To enhance usability and convenience, I have incorporated visual indicators that display cooldown clocks for consumable items. This feature allows players to gauge the availability of these items and plan their strategies accordingly. By providing clear and intuitive visuals, players can make informed decisions about when to use their consumables effectively.
Moreover, I have implemented interactive elements within the inventory system. When hovering over an item, players are presented with relevant information. To further streamline item usage, I have implemented a right-click functionality besides keybindings 1, 2, and 3. [Inventory Class](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/Item/Inventory.cs#L12), [Inventory controller script](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/Item/InventoryController.cs#L7). [Reference tutorial](https://www.youtube.com/watch?v=2WnAOV7nHW0&t=19s&ab_channel=CodeMonkey).

![1686788602365](https://github.com/cioudfox/ECS-189-Project/assets/114460759/be8640a3-245d-4f24-80d5-928e8258efe2)


#### Damage Popup:
The damage pop-up controller effectively communicates the impact of each attack through visual cues in the form of pop-up text. To distinguish normal hits from critical hits, a color scheme is used, with yellow text representing normal hits and red text representing critical hits. To create a smooth visual experience, the pop-up text dynamically changes in size throughout its duration. It starts small and gradually increases in size during the first half of the pop-up, then gradually decreases in size during the second half. This approach provides a visually appealing and immersive experience for players during combat. [Damage popup controller script](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/DamgePopup.cs#L6).

![1686788851866](https://github.com/cioudfox/ECS-189-Project/assets/114460759/3fadefcd-a52d-44da-8838-675dd179d213)

### - Weapon System Weapon System(Projectile and Melee), Armor, Passive Regen, and weapon Upgrade system - Steven

#### Weapon System: 
In the game, each weapon is associated with a ScriptableObject that stores all the predefined properties and characteristics for that specific weapon type. This design allows for easy customization and future development of new weapon types. Projectile weapons utilize the ProjectileWeaponController and Behavior code, while melee weapons use the MeleeWeaponController and Behavior code. This modular approach ensures consistent functionality and simplifies the process of introducing new weapons with unique behaviors. It provides a flexible and scalable system for managing weapons in the game, facilitating customization and maintaining clarity in the overall design.
#### Projectile weapons: 
currently have the generic Damage, speed, cooldown(attackspeed), and lifetime. But also have the additional properties of “Pierce”, “chain”, “explosive”, and “boomerang”. 
-Pierce: how many enemy that projectile can hit before destroyed.
-Chain: the projectile will jump to the closest enemy after hiting one.
-Explosive: Initially wanted to use other prefab to create explosion on hit, because we have no assets for that so I changed it to: explode into x many numbers of another projectile, spread out evenly. thus, an orb can explode into dagger of different stats for example.
-Boomerang: return to the player after reaching a certain distance away.
-NumberofProjectile: shoot x many projectile at same time, spread is uneven within a 40 degree arc.
Initially, I encountered an issue where projectiles would unintentionally hit the same enemy multiple times. To resolve this, I implemented a solution using a list to keep track of all the enemies that were previously hit by a projectile. With this approach, every time a collider is detected, the system checks the list to ensure that the enemy has not been hit before. This prevents duplicate hits and ensures that each enemy is only affected once by the projectile. By employing this list-based tracking mechanism, I successfully resolved the problem of repeated enemy hits caused by the same projectile.

#### Melee weapons: 
Similar to projectile weapons, melee weapons share certain characteristics such as generic damage and attack speed. It can hit all enemy in its hit box once, thus a real aoe that requires player to get close to use.  However, it is not complete, mainly due to the lack of specific animations and sprites required for various attack variations. Implementing different attack animations and sprites is a task that requires specialized skills in animation, which I do not possess. Additionally, the implementation of knockback effects in melee combat is an area that requires further attention and refinement. While the foundation for melee weapons is in place, the overall development and polish of these weapons may require additional resources and expertise in animation and combat mechanics.
#### Armor System:
To enhance the gameplay balance, I have incorporated armor mechanics for both enemies and the player. It was Intended for Melee only player character in mind(however we scrapted that).  This addition brings an extra layer of strategic depth to the game. The armor is applied after all damage calculations have been performed, ensuring a more streamlined and balanced damage calculation process. By implementing armor in this manner, it simplifies the overall damage calculation process and provides a fairer and more balanced gameplay experience. This approach is different from, for example, the sentry shield in StarCraft II, where damage reduction is applied before damage calculations. The implementation of armor in this way aims to create a more engaging and strategically satisfying gameplay experience.
#### Passive Health Regen:
I also implemented passive HP regeneration for the player character to provide a slight reduction in the punishment for getting hit. It allows the player's health to gradually recover over time without needing external healing sources or consumables. This feature offers a more forgiving gameplay experience by providing a natural means of healing.
####UpgradeSystem(Weapon, and change to Health): 
I implemented an upgrade system that scales the damage and attack speed of weapons. The system utilizes stacking modifiers that multiply the base stats of the weapons. For example, if you upgrade the attack damage three times and the base damage is 4, the resulting damage would be calculated as 4 * (100% + 7.5% * 3). Although the damage pop-up might not reflect the exact change, the upgraded weapon effectively kills enemies faster since their health values are stored as float values. This scaling mechanism enhances the effectiveness of weapons over time and provides a sense of progression and power growth for the player.

## Animation and Visuals

### Animation - Megan Liu
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

### Map Design - Megan Liu, Jason Wu

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
(writing right now, sorry :(   
**Add an entry for each platform or input style your project supports.**

# Sub-Roles

## UI


**WRITE STUFF HERE JASON. Menu buttons change shades of hue when hovered and click to add more pizzazz. Glamorous bright colors add to the rpg fantasy elements.**

### Inventory and In-Game Button UI - Hongye Xu
By prioritizing user experience, the button UI provides users with helpful tooltips and information when hovering over buttons, empowering them with valuable insights to make informed decisions. Furthermore, the deliberate design of the inventory and item placement within it ensures a visually pleasing and functional play view, facilitating smooth navigation and effective item usage. These interface enhancements contribute to a more immersive and intuitive gameplay experience, allowing players to easily access important information and manage their inventory seamlessly. [Button Class](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/ButtonUI.cs#L6)

![1686789818365](https://github.com/cioudfox/ECS-189-Project/assets/114460759/b2b5afcb-67f3-4c82-9135-d0dbb7505b55)
![1686790127231](https://github.com/cioudfox/ECS-189-Project/assets/114460759/bba9f31d-fffc-41c8-a500-69d227f12230)



### Scene UI, Game UI - Young Cheol Ko

#### Scene UI:

![a1](https://github.com/cioudfox/ECS-189-Project/assets/44619284/0c80ce2b-7977-4e01-8d8b-8aa85f1ff44e)
![a2](https://github.com/cioudfox/ECS-189-Project/assets/44619284/c984851f-b73c-497c-8c3c-2eb8262c95a5)

Developed UI elements and scripts for the scene controller, character selector, main menu, and ESC menu. Ensured smooth transitions between scenes, allowed character selection, and provided accessible menus for navigation.

#### Game UI:

![a3](https://github.com/cioudfox/ECS-189-Project/assets/44619284/618507c7-dfc5-419b-9e4f-f25819c5d55d)

Created UI elements for the fixed camera display, time display, player health bar, player experience bar, game over popup, winning popup, score UI, boss health bar, and upgrade system UI. Offered players important information, including health and experience status, and provided visual feedback during gameplay. Conveyed game outcomes through the game over popup and winning popup screens. Tracked and displayed the player's score through the score UI. Enabled monitoring of the boss's health through the boss health bar, adding strategic elements to gameplay.

We added the **spatial elements of object text labels** that appear near items and consumables when the user's cursor hovers over them. The text displays the item or consumable's name and purpose, so the user can clarify on their own accord what the objects in this game are used for, without the descriptions obstructing the game. 

## Gameplay Testing(Layers/Collisions)
Ensured proper layering and tags so enemies, objects, and player are all properly displayed on the screen with proper collisions. Modified layers in the physics 2D engine for bugfixes to horde of enemies don't get stuck on each other. Fixed wonky physics with capsule colliders mishaping. 

Enemies have no collision with Terrain, however, they do have collision amongst themselves and the player. Flying enemies do not collide with terrain or enemies, but do with the player. In order to allow enemies to still collide with some objects in the map, tilemaps have a special upper tile layer that is treated as enemy which prevents normal enemies that are not flying to pass through.

Sorting Layers help distinguish where an object should be, for example, a tree should be in the midground while the floor should be in the background. Enemies, players, and projectiles should all be in the Foreground. Each sorting layer can have an integer value set to it to prioritize which object is located closer towards the camera. Using sorting layers, the opaqueness of buildings utilizes this by moving the building from the background into the foreground and setting its opacity down to 40% so it seems like the player is still behind it. Similarly, items have full priority over everything else since enemies and buildings blocking item sightline would make them difficult to collect. 

Layers/Sorting Layers for Colliders:

![Screenshot 2023-06-14 152536 png](https://github.com/cioudfox/ECS-189-Project/assets/68248379/92855ccb-e80a-4907-9ebd-0fb7b210b095)

Buildings have 2 parts to them, a 2D collider that acts as a trigger for when the player is on top of it and a 2D collider that only restricts player movement. The addition of the first collider is to allow the building to become opaque when a player is behind it to give the illusion that they are standing behind the building. The second collider is a player only collider that makes it seem like the building is a blocking object in the map and not just some painted on carpet on the map. 

Object Colliders:

![Screenshot 2023-06-14 152536](https://github.com/cioudfox/ECS-189-Project/assets/68248379/e808ba5c-c217-431b-85db-ca6f881ff422)


## Game Feel and Gameplay Testing  - Steven
I have dedicated significant time to playtesting and balancing our game, aiming to strike a balance between challenge and accessibility. During this process, I made several important changes and improvements:
Shooting mechanics: Initially, players had the option to shoot in the direction of their movement. However, I found this to be cumbersome and decided to remove it. Now, players shoot directly towards the location of the mouse cursor, making the shooting experience more intuitive and user-friendly.

Health upgrades: Instead of simply increasing the maximum HP and instantly healing the player to full, I modified the health upgrades to increase the maximum HP and passive health regeneration speed. This change adds a gradual healing aspect to the game and slightly reduces the overall difficulty, considering the presence of healing items.

Item functionality changes: I made adjustments to the functionality of the items to enhance their effectiveness and impact:
-The first item now heals the player for 40% of their maximum HP, providing a more substantial healing effect compared to the previous flat value of 20 HP.
-The second item not only temporary increases critical chance but also slightly boosts attack speed, providing additional benefits to the player's combat capabilities.
-The third item now grants a temporary increase in movement speed, removing its previous effect of increasing attack speed.
Global cooldown for items: After a player uses an item, I introduced a global cooldown mechanism that temporarily disables the use of any other items. This encourages players to carefully consider their choices and strategize their item usage in different situations, adding a layer of decision-making to the gameplay.

Weapon and enemy balancing: I iterated multiple times on the stats and characteristics of all weapons and enemies. This iterative process resulted in a game that starts off relatively easy but progressively becomes more challenging as players progress. This approach increases replayability and provides a satisfying sense of progression and difficulty curve.

Adjusted enemy spawning: I expanded the area in which enemies spawn, creating a larger space for encounters and making the waves of enemies less overwhelming and lethal. This modification allows players to maneuver more effectively and strategize their actions during intense combat situations.

## Audio - Hongye Xu, Megan Liu

Our audio and sound effects have an upbeat vibe and consist of jazzy electronic keyboard and drums, in order to match the pleasant energy of exploring a fantasy landscape and fighting constant mobs.

To implement our audio system, we used a sound manager script adapted from "Introduction to AUDIO in Unity" by Brackeys. The public sound manager allowed us to easily attach audio clips and customize title, volume, pitch, and loop from the editor, as well as play any of the attached audios in other scripts. [Sound Manager Class, referencing assignment 1 Captain's sound manager](https://github.com/cioudfox/ECS-189-Project/blob/f12713189b42f11b884d53a79a240c921986cd05/Generic%20Project%20Name/Assets/Scripts/SoundManager.cs#L13).

**1) [Crystal Caves Music](https://www.gamedevmarket.net/asset/crystal-cavern-game-assets-music)**

**The audio we received was from a free pack. The caves audio theme had a nice jazzy tune to it so we figured it be a fine addition to our 2D pixel style game.**

**2) [Win Game Sound Effect](https://freesound.org/people/EVRetro/sounds/495005/)** - [Code](https://github.com/cioudfox/ECS-189-Project/blob/d9ba4870dd381146096ad5be28a48c85746b334e/Generic%20Project%20Name/Assets/Scripts/Menu/Winning.cs#LL21C6-L21C6)

**Steady and upbeat music plays to celebrate when the player defeats the dragon boss and wins the game. The music has a classic video game feel that fits our fantasy theme.**

**3) [Lose Game Sound Effect](https://freesound.org/people/Jofae/sounds/364929/)** - [Code](https://github.com/cioudfox/ECS-189-Project/blob/d9ba4870dd381146096ad5be28a48c85746b334e/Generic%20Project%20Name/Assets/Scripts/Menu/GameOver.cs#LL22C33-L22C33)

**A shaky and descending sound effect plays when player dies to in order to reflect the tragedy of the loss. The sound is somewhat musical and funky, fitting the atmosphere of the background music as well.**

**4) [Other Sound Effects](https://sirental.itch.io/elemental-dungeons)**

**Most of the sound effects for events, such as taking a hit, using a consumable, or selecting an item, are audio assets from https://sirental.itch.io/elemental-dungeons that are simple, silly, and fitting to the cartoonish, fantasy style.** 


## Trailer
[TRAILER](https://drive.google.com/file/d/1FTuCzd0b-yqRPbuzUG1IwLNcrNJUhEgT/view?usp=drive_link)

Our game trailer expertly captures the essence of our work by showcasing its main features in a concise and engaging manner. The trailer highlights various types of weapons, demonstrating their unique characteristics and devastating power. It also emphasizes the strength upgrade system, illustrating how players can enhance their abilities as they progress in the game. Additionally, the strategic use of items is showcased, providing players with tactical advantages during intense gameplay moments. The trailer teases waves of challenging enemies, conveying the excitement and adrenaline of combat encounters. Finally, it unveils the imposing boss character, promising epic battles that will test players' skills and determination. Carefully selected screenshots and gameplay footage combine to create a professional trailer that captivates viewers, leaving them eager to delve into the thrilling gaming experience that awaits them. (Music is from https://opengameart.org/content/rainbow)

