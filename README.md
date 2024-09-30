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
  - [Tools and Sources](#tools-and-sources)
    - [Tools](#tools)
    - [Sources](#sources)
  - [Thank You](#thank-you)
  - [Design Choices and Justification](#design-choices-and-justification)
    - [Interface and Usability](#interface-and-usability)
    - [Graphics and Resource Allocation](#graphics-and-resource-allocation)
  - [Contact](#contact)


## Introduction

**OutOfAmmo** is a sniper assassin game where your objective is to assassinate your targets. Unfortunatly for you, you only have a single ammunition to execute your mission, which means that if you miss you need to find a clever solution to the difficulty you have put yourself in. The objective of the game is to kill (put to sleep) the targets before you either get killed of they flee the scene.



The game is designed in [Unity](https://unity.com/) and the 3D models are designed in [blender](https://www.blender.org/).

### Discalmer
The project was inspired by the horrible assassinations, and attempted assassinations of political figures, however this does in no way mean that the project is related to any specific assassination. Neither does it mean that the project endorses or condemns any political ideology. This game is for entertainment and educational purposes only.

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
- Health becomes negative instead of simply zero. (This bug is now fixed)
- Trees don't have colliders
- If you would miss when shoting sniper the script that makes you miss kicks in nonetheless. (This is not really a bug but for the game to feel better a check would have to be added so the camera doesn't move quickly towards the target.)
- The rocket in map 2 can go through buildings.
- You can get stuck in the wheat in scene 3 due to collider issues. We have plans to change the wheat textures all together but we haven't had the time yet.
- In the first map you can cheat falldamage by hugging the walls of buildings. 

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
  - Death mechanics
  - Main menu design
  - Documentation (Readme)
  - Bugfixes

- ### Viggo Haimanas Bygden - [abbvighai](https://github.com/abbvighai)
  - __Animation Lead__
    - 3d models
      - Cop and target models
      - Palm scene model
    - Palm scene
    - Jeff scene
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
    - Cop and target models
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

## Contact

[Sebastian Alin](sebastianalin@hitachigymnasiet.se), alin.sebastia@gmail.com

[Viggo Haimanas Bygden](ViggoHaimanas@hitachigymnasiet.se)

[Simon Meier](sm0765809875@gmail.com)

[Lovisa Bylund](lovisa.bylund@hitachigymnasiet.se)
