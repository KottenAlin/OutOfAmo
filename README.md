# OutOfAmmo

![image](https://github.com/user-attachments/assets/2708df46-c3eb-4309-8e88-727e057071c1)

## Table of Contents
- [OutOfAmmo](#outofammo)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
    - [Discalmer](#discalmer)
  - [Features](#features)
  - [Powerpoint](#powerpoint)
  - [Installation](#installation)
  - [Contribute](#contribute)
    - [Prerequisites](#prerequisites)
    - [Download the Project](#download-the-project)
    - [Commit changes](#commit-changes)
  - [Known bugs](#known-bugs)
  - [Fixed bugs](#fixed-bugs)
  - [Tools and Sources](#tools-and-sources)
    - [Tools](#tools)
    - [Sources](#sources)
  - [Thank You](#thank-you)
  - [Design Choices and Justification](#design-choices-and-justification)
    - [Interface and Usability](#interface-and-usability)
    - [Graphics and Resource Allocation](#graphics-and-resource-allocation)
  - [Project evaluation](#project-evaluation)
    - [Sucesses](#sucesses)
    - [Lessons learned](#lessons-learned)
    - [Potential improvemnts](#potential-improvemnts)
  - [Contact](#contact)


## Introduction

**OutOfAmmo** is a sniper assassin game where your objective is to assassinate your targets. Unfortunatly for you, you only have a single ammunition to execute your mission, which means that if you miss you need to find a clever solution to the difficulty you have put yourself in. The objective of the game is to kill (put to sleep) the targets before you either get killed of they flee the scene.
The game is designed in [Unity](https://unity.com/) and the 3D models are designed in [blender](https://www.blender.org/).

### Discalmer
Content Warning: This game contains fictional violence and themes of assassination. It is intended solely for entertainment purposes and does not endorse or encourage any form of real-world violence or illegal activities. The actions depicted in the game are purely imaginary and should not be replicated in real life.

Responsibility: Players are encouraged to approach the game responsibly and to recognize the distinction between virtual experiences and real-world actions. By playing this game, you acknowledge that the scenarios and content are fictional and do not reflect acceptable behavior outside the game environment.

## Features

- **3 maps**: Our game includes 3 maps with the objective to assassinate one target on each map.
- **Sniper**: At the start of each map you will attempt to shoot the target, there is unfortunatly for you a mechanic that makes you miss
- **Movement**: After you miss your only shot you will need to move to the target to punch it down and succeed with your objective that way. There is both slide and sprint which will help you move faster. There is also a crouch function and zoom, however they are only astetic and do not have any practical purposes in the game.
- **Police**: Scattered around the map are police who will protect the target and shoot you if they notice you.
- **Pick up**: Scattered around the map are also objects that you can pick up and throw
- **Target**: The Target will try to escape and if it reaches a point you will lose, therefore you need to hurry.
- **Animations**: Our characters have animations that help bring life to the world.
- **Post-processing**: To enchance the visuals we have post-processing

## Powerpoint

- **Powerpoint**: [OutOfAmmo.pptx](https://github.com/user-attachments/files/17144318/OutOfAmmo.pptx)

## Installation

To install and play the game please contact Simon Meier on teams and he will invite you to the Quantum Studios teams group. There you go into files at generals and in the builds folder download the newest version. To play the game simply run OutOfAmmo.exe.

## Contribute

Tutorial for how to contribute to the project.

### Prerequisites

In order to contribute to the project you need unity: [link to download](https://unity.com/download). If you wish to create 3d models any 3d software that can export to fbx will work, we used [blender](https://www.blender.org/).

### Download the Project

To contribute to the project you need to access our code by cloning the repository and create your own branch. You can of course also use Github desktop or other platforms to do that same as below but this is how to clone and commit changes with a terminal. 

```bash
git clone https://github.com/KottenAlin/OutOfAmo.git # Clone the repo

cd OutOfAmo
git checkout -b your-own-branch  # Create your own branch
```

You can now open the project in unity hub by choosing open and "Add project from disk". Make sure that you have unity version 2022.3.10f1 as that is the version we have used. (It is due to the difficulty of downloading new versions at our school computers.)

### Commit changes

```bash
git add .
git commit -m "Description of changes"
git push origin your-own-branch # Pusha din branch till GitHub
# You can now open a pull request on GitHub to propose you changes.
```

## Known bugs

- When you punch the police or target the hit sometimes don't register.
- If you would miss when shoting sniper the script that makes you miss kicks in nonetheless. (This is not really a bug but for the game to feel better a check would have to be added so the camera doesn't move quickly towards the target.)
- You can get stuck in the wheat in scene 3 due to collider issues. We have plans to change the wheat textures all together but we haven't had the time yet. (Fixed)
- Change location of signs in map 2 as many miss the first sign which says Weapon ahead. (Fixed)
- You can slide past the arresting police in map 3 which confuses the player of why they got arrested.
- Tutorial buttons move strangly.

## Fixed bugs
- Palm starts walking before shooting sniper
- Police can shoot through walls.
- Trees don't have colliders
- Sound issues. Sometimes you can't here sounds at all. And some sounds like arresting sound plays at the start of a map (Not rigorously tested)
- Health becomes negative instead of simply zero. (This bug is now fixed)
- JFK drives in circles sometimes. (Not rigorously tested)
- Falldamage is also illocial as it deals a lot of damage sometimes but less sometimes even though you fall less. (Map 2 staircase to replicate.)

## Tools and Sources

We used the following tools and sources for the creation of **OutOfAmmo**:

### Tools
1. [Unity](https://unity.com/) - Unity is the game engine of our game
2. [Gihub-Copilot](https://github.com/features/copilot) used for programming and debugging
3. [Blender](https://www.blender.org/) - Blender is where we have designed the maps and several of our 3d models
4. [sketchfab](https://sketchfab.com/feed) - A few 3d models have been imported for free from sketchfab. The models we have imported are under the standard CC0 and Free standard.
5. [mixamo](https://www.mixamo.com/) - We have used mixamo for our character animations.
6. [Paint.net](https://www.getpaint.net/download.html) - Paint.net has been used to create and edit our 2d sprites.
7. [Pixaaby](https://pixabay.com/sound-effects/search/freesounds/) - Our sounds have been taken from Pixabay.
8. [Audacity](https://www.audacityteam.org/) - for audio recording and editing
9. [Powerpoint-Template](https://github.com/user-attachments/files/17144309/Video.Games.Competition.Newsletter.by.Slidesgo.pptx)

### Sources

1. [Chat GPT](https://chatgpt.com/) - Chat gpt has been used mainly to help with debuging errors.
2. [Unity Docs](https://docs.unity.com/) - Source for unity code.
3. [stack overflow](https://stackoverflow.com/) - Code for unity and buggfix help.
4. [Unity Discussions](https://discussions.unity.com/) - Much like stack overflow, a forum to find code and bugfix help. 
5. [Youtube](https://www.youtube.com/) - Tutorials
   - [Countdown Timer](https://www.youtube.com/watch?v=POq1i8FyRyQ&ab_channel=RehopeGames)
   - [Main Menu, buttons and canvas tutorial](https://www.youtube.com/watch?v=DX7HyN7oJjE&ab_channel=RehopeGames)
   - [Post prossessing](https://www.youtube.com/watch?v=9tjYz6Ab0oc)
   - [movement](https://www.youtube.com/watch?v=f473C43s8nE)
   - [Cop movement](https://www.youtube.com/watch?v=UjkSFoLxesw&t=292s)
   - [Punching](https://www.youtube.com/watch?v=yZhKUViKS_w)
   - [Item Pickup](https://www.youtube.com/watch?v=pPcYr3tL3Sc&t=35s)

## Thank You

We would like to thank everyone who contributed to the Quantum Coinmaster project. Their dedication and efforts have been crucial to the success of the project.

- ### Simon Meier - [abbsimmei](https://github.com/abbsimmei)
  - __Project Lead__
  - __Level Design__
  - Trump scene
    - Trump scene model
  - Sniper script
  - Timer
  - Import 3D models & textures to Unity
  - Death mechanics
  - Main menu design
  - Documentation (Readme)
  - Bugfixes

- ### Viggo Haimanas Bygden - [abbvighai](https://github.com/abbvighai)
  - __Animation Lead__
    - 3d models
      - Cop and target models
      - Palme Model
      - Jeff Model
      - Jeff Car Model
      - Palm scene model
    - Palm scene
    - Jeff scene
    - Trumpet Ending
    - Animations (all characters except for player)
    - Import 3D models & textures to Unity
    - Rocket mechanics
    - Car movement
  - Bugfixes

- ### Sebastian Alin - [sebastian200](https://github.com/sebastian200)
  - __Code and Game Mechanics Lead__
    - Camera and Player movement
      -Crouch
      -Slide
    - Item pickup
    - Enemy movement, and kiling (Navmesh)
    - Punching
    - Player health
    - Player animation (punch)
    - Palm scene and tutorial
  - __Sound Designer__
    - Music
    - Ambient Sounds
    - SFX
    - Sound Recording
  - Bugfixes

- ### Lovisa Bylund - [abblovbyl](https://github.com/abblovbyl)
  - __3D modeling lead__
    - Jeff Scene
    - Wheat (that was never used)
    - Rocket & popcorn models
    - Cop and target models
    - Gavel
    - Gun
  - PowerPoint creation

## Design Choices and Justification

### Interface and Usability

To maximize usability, we have taken several steps to make the game easy to understand:

- **Intuetivemovement mechanics** Input layout is standard for games with not overwelmingly keybinds to remember.
**Clear Instructions** The Guide for how to play the game is clear intuetive, and reactive, by using audio and visual communication. The objective i clear, and the buttons that show the player how to move dissapear when doing said action.
- **Clear GUI:** We have implemented a clear GUI with high contrast, easy-to-understand buttons, and indicators that clearly display the number of collected coins.
- **Sound:** By integrating sounds for jumping, sliding, and shooting, the gameplay experience becomes clearer.

### Graphics and Resource Allocation

We have also carefully considered resource allocation to optimize the game's performance:

- **Low poly assets** The polygon count of the 3D assets are intentionally low to better run on slower computers and integrated GPUs
- **Animation:** NPCs have animations to increase visual appeal, but excessive animation is avoided to maintain performance.
- **Scene Division:** By dividing the game into different scenes, we reduce the number of objects the game has to handle at once, resulting in improved performance.
- **Object Destruction:** The bullets from the Cops are destroyed after five seconds, to decrease lag.

## Project evaluation

### Sucesses
- **Goal Achievement:** We successfully completed all the project requirements, delivering a game with three maps and functional mechanics for sniper gameplay. The game was completed on time, meeting the initial goals we set for ourselves.
- **Early Version Delivery:** One of the strongest points of the project was our ability to develop a working prototype quickly. This allowed our level designers to start working on map design early in the process, ensuring that they had enough time to refine and improve the maps.


### Lessons learned



- **Define the Concept Early:** The initial idea for our project was too vague, which led to confusion and inconsistent interpretations within the team. In the future, we need to ensure that the concept is clearly defined at the outset to avoid miscommunication.

- **Create a Project Plan:** The absence of a detailed project plan led to inefficiencies and overlapping work. Moving forward, we need to establish a clear plan, outlining roles, tasks, and timelines, to keep the project organized and on track.

- **Coordinate Mechanics and Level Design:** Developing game mechanics while level design was in progress created integration challenges and merge conflicts. We learned that mechanics and level design should be planned in parallel but implemented in stages to avoid these issues.

- **Standardize Asset Sources:** Using textures from different sources caused inconsistencies in the visual style of the game. For future projects, we need to standardize asset sources or ensure proper editing so that all assets match the visual style and function seamlessly in Unity.


### Potential improvemnts

- __Speedrun-Timer__  Add speedrun timer at the end showing how fast you played the game.
- Add visuals to make it easier to find the target when shooting.
- Make more userfriendly by giving visual or audio for several of our fuctions. Mainly that you have limited time and that you need items (popcorn and missile)
- When you die it says the victim fleed the scene, it should say you died.
- **Better GUI:** A more polished and user-friendly interface would enhance the player experience significantly.
- **Customization and Settings:** Adding more customization options for players, such as different sniper rifles, adjustable difficulty settings, and enhanced options for game controls.
- **Improved Grass Textures:** The grass textures in the game were not very realistic, which detracted from the overall aesthetic of the maps. Improving this aspect would make the game environment more immersive.
- **More Models for Characters:** Adding a wider variety of character models, especially for NPCs, would improve the visual quality and realism of the game.
- **Creative Gameplay Mechanics:** To increase the game's fun factor, we could introduce more creative and diverse ways of eliminating targets, adding more strategic depth and variety to gameplay.




## Contact

[Sebastian Alin](sebastianalin@hitachigymnasiet.se), alin.sebastia@gmail.com

[Viggo Haimanas Bygden](ViggoHaimanas@hitachigymnasiet.se)

[Simon Meier](sm0765809875@gmail.com)

[Lovisa Bylund](lovisa.bylund@hitachigymnasiet.se)
