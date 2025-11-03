🎮 Unity Test Assignment - README
This repository contains a Unity project developed as a test assignment, showcasing various core game development concepts including asset integration, game management, UI/UX, and local data persistence.

Project Overview
The core gameplay involves a third-person character collecting pickups within a 60-second time limit. The final score is determined by how quickly and efficiently the player collects the pickups and reaches the escape point before the timer runs out.

Key Features
Third-Person Controller: Integrated and utilized a free third-person asset for player movement and camera control.

Pickups System: Created custom collectible items that, when gathered, contribute to the final score calculation.

Game Management: A robust system orchestrates the flow between the Main Menu and the core Game Scene.

Scoring & Persistence: The final score is calculated based on time and pickup collection, and then saved locally using a JSON file.

Main Menu: A dedicated scene managed by the MenuManager for starting the game.

Game Logic: The GameManager handles the primary game loop, rules, timer, and win/loss conditions.

Core Components
The project relies on a few key managers to handle different aspects of the game:

1. MenuManager
Scene: Primarily resides in the Main Menu Scene (Scene 1).

Functionality:

Handles the navigation and button logic for the Main Menu (e.g., Start Game, Quit).

Responsible for transitioning from the Main Menu to the main Game Scene.

2. GameManager
Scene: Active in the Main Game Scene.

Functionality:

Manages the 60-second game timer.

Tracks the overall state of the game (e.g., Running, Win, Lose).

Coordinates with the ScoreManager for score calculation upon game completion.

Handles the transition to the "Escape" or Game End state.

3. ScoreManager
Scene: Active in the Main Game Scene and persists to handle score saving.

Functionality:

Tracks the number of pickups collected.

Calculates the final score based on the time elapsed and the number of collected pickups (quick collection is rewarded).

Implements Local Data Persistence by saving the final and/or high score to a local scores.json file.

Installation and Setup
Clone the Repository:

Bash

git clone [Your Repository URL]
Open in Unity: Open the cloned folder as a project in the Unity Editor (Version [Specify Unity Version Used, e.g., 2022.3.LTS]).

Required Asset: Ensure the free Third-Person asset (e.g., Unity Standard Assets Third Person Character or similar) is correctly imported and linked to the player prefab.

Scene Order: Confirm that the Main Menu Scene is set as the first scene in the Build Settings.

How to Play
Start the game from the Main Menu.

Control the character using standard third-person controls (W, A, S, D, Mouse Look).

Collect as many pickups as possible within the 60-second timer.

Once all/enough pickups are collected, reach the designated escape point to end the game and calculate your final score.

The final score will be displayed and saved locally.
