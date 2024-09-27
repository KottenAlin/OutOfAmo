# OutOfAmmo

![image](https://github.com/user-attachments/assets/2708df46-c3eb-4309-8e88-727e057071c1)

## Table of Contents
1. [Introduction](#introduction)
2. [Features](#features)
3. [Powerpoint](#powerpoint)
4. [Installation](#installation)
   - [Prerequisites](#Prerequisites)
   - [Download the Project](#download-the-project)
6. [Contribute](#contribute)
7. [Known Bugs](#known-bugs)
8. [Tools and Sources](#tools-and-sources)
   - [Tools](#tools)
   - [Sources](#sources)
9. [Contact](#Contact)


## Introduction

**OutOfAmmo** is a sniper assassin game where your objective is to assassinate your targets. Unfortunatly for you, you only have a single ammunition to execute your mission, which means that if you miss you need to find a clever solution to the difficulty you have put yourself in. The game is designed in [Unity](https://unity.com/) and the 3D models are designed in [blender](https://www.blender.org/).

## Features

- **3 maps**: Our game includes 3 maps with the objective to assassinate one target on each map.
- **Sniper**: At the start of each map you will attempt to shoot the target, there is unfortunatly for you a mechanic that makes you miss
- **Movement**: After you miss your only shot you will need to move to the target to punch it down and succeed with your objective that way. There is both slide and sprint which will help you move faster
- **Police**: Scattered around the map are police who will protect the target and shoot you if they notice you.
- **Pick up**: Scattered around the map are also objects that you can pick up and throw
- **Target**: The Target will try to escape and if it reaches a point you will lose, therefore you need to hurry.
- **Animations**: Our characters have animations that help bring life to the world.
- **Post-processing**: To enchance the visuals we have post-processing

## Powerpoint

- **Powerpoint**: [OutOfAmmo.pptx](https://github.com/user-attachments/files/17144318/OutOfAmmo.pptx)

## Installation

TBA

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
- Health becomes negative instead of simply zero.
- Trees don't have colliders
- If you would miss when shoting sniper the script that makes you miss kicks in nonetheless. (This is not really a bug but for the game to feel better a check would have to be added so the camera doesn't move quickly towards the target.)
- The rocket in map 2 can go through buildings.
- You can get stuck in the wheat in scene 3 due to collider issues. We have plans to change the wheat textures all together but we haven't had the time yet.
- In the first map you can cheat falldamage by hugging the walls of buildings. 

## Tools and Sources

We used the following tools and sources for the creation of **OutOfAmmo**:

### Tools
1. [Unity](https://unity.com/) - Unity is the game engine of our game
2. [Blender](https://www.blender.org/) - Blender is where we have designed the maps and several of our 3d models
3. [sketchfab](https://sketchfab.com/feed) - A few 3d models have been imported for free from sketchfab. The models we have imported are under the standard CC0 and Free standard.
4. [mixamo](https://www.mixamo.com/) - We have used mixamo for our character animations.
5. [Paint.net](https://www.getpaint.net/download.html) - Paint.net has been used to create and edit our 2d sprites.
6. [Pixaaby](https://pixabay.com/sound-effects/search/freesounds/) - Our sounds have been taken from Pixabay.
7. [Powerpoint-Template](https://github.com/user-attachments/files/17144309/Video.Games.Competition.Newsletter.by.Slidesgo.pptx)

### Sources

1. [Chat GPT](https://chatgpt.com/) - Chat gpt has been used mainly to help with debuging errors.
2. [Unity Docs](https://docs.unity.com/) - Source for unity code.
3. [stack overflow](https://stackoverflow.com/) - Code for unity and buggfix help.
4. [Unity Discussions](https://discussions.unity.com/) - Much like stack overflow, a forum to find code and bugfix help. 
5. [Youtube](https://www.youtube.com/) - Tutorials
   - [Countdown Timer](https://www.youtube.com/watch?v=POq1i8FyRyQ&ab_channel=RehopeGames)
   - [Main Menu, buttons and canvas tutorial](https://www.youtube.com/watch?v=DX7HyN7oJjE&ab_channel=RehopeGames)

## Contact

[Sebastian Alin](sebastianalin@hitachigymnasiet.se)

[Viggo Haimanas Bygden](ViggoHaimanas@hitachigymnasiet.se)

[Simon Meier](sm0765809875@gmail.com)

[Lovisa Bylund](lovisa.bylund@hitachigymnasiet.se)
   
