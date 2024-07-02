# Humanitarian Helicopter Project

## Overview

This repository contains the scripts for the Humanitarian Helicopter project, a simulation game designed to provide humanitarian aid using helicopters. The scripts manage various aspects of the game, including player controls, UI elements, game management, and in-game objects like buildings and helicopters.

## Gameplay

In the Humanitarian Helicopter game, players take on the role of a helicopter pilot tasked with delivering supplies, rescuing civilians, and performing other humanitarian missions. The game features different types of helicopters, each with unique capabilities, and various in-game challenges such as managing fuel levels, avoiding obstacles, and upgrading equipment to improve performance. Players navigate through different levels, each presenting new objectives and difficulties.

## Directory Structure

The `Scripts` folder contains all the C# scripts used in the Unity game. The directory is organized as follows:

- **GameManagement**
  - `GameManagement.cs`: Manages overall game functions.
  - `LevelLoader.cs`: Handles the loading of different levels in the game.
  - `PlayButton.cs`: Script for the play button functionality.
  - `BackgroundMusicControl.cs`: Controls background music settings.
  - `SceneController.cs`: Manages scene transitions.
  - `UpgradesManager.cs`: Manages upgrades available in the game.
  - `WinScene.cs`: Handles the win condition and transitions to the win scene.
  - `ReturnButton.cs`: Functionality for return button.

- **UI**
  - `DragonDataBar.cs`: Displays dragon data in the UI.
  - `HouseText.cs`: Manages text related to houses.
  - `PlayerHealthBar.cs`: Displays the player's health bar.
  - `FuelBar.cs`: Displays the fuel bar.
  - `FuelText.cs`: Manages text related to fuel.
  - `HealthBarText.cs`: Manages health bar text.
  - `DragonData.cs`: Manages dragon data.
  - `HousesBar.cs`: Manages house bar UI element.

- **Player**
  - `BasicHelicopterController.cs`: Controls the basic helicopter.
  - `HellFireMissile.cs`: Manages the hellfire missile weapon.
  - `TransportCopter.cs`: Controls the transport helicopter.
  - `SupplyCrate.cs`: Manages supply crate drops.
  - `CameraController.cs`: Controls the camera.
  - `AttackHelicopterController.cs`: Controls the attack helicopter.

- **Buildings - Blocks**
  - `Block.cs`: General block functionality.
  - `House.cs`: Manages house objects.
  - `FuelBrick.cs`: Manages fuel bricks.
  - `People.cs`: Manages people objects.
  - `Door.cs`: Manages door objects.
  - `RepairBrick.cs`: Manages repair bricks.
  - `Key.cs`: Manages key objects.
  - `Checkpoint.cs`: Manages checkpoints.
  - `Base.cs`: Base functionality for building blocks.

- **Miscellaneous**
  - `RotateContinuously.cs`: Makes an object rotate continuously.

## Usage

To use these scripts in your Unity project:

1. Copy the `Scripts` folder into your Unity project's `Assets` directory.
2. Ensure all necessary game objects in your scenes are linked to the appropriate scripts.
3. Customize the scripts as needed for your specific game requirements.


## Acknowledgements

This project is a collaborative effort and includes contributions from various developers. Special thanks to everyone involved in the development and testing of this game.
