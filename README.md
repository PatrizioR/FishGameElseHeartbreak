# Fish Knockout Game

## Description

The Fish Knockout Game is a game where the player controls a fish with the goal of knocking out enemies to win the game. The game is structured around a square board (e.g., 8x8) with different entities representing the player, enemies, and objects.

This game was developed as part of an assignment for a computer science course to explore object-oriented programming concepts, particularly inheritance and polymorphism.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Game Components](#game-components)
- [Features](#features)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Download the project files from the GitHub repository.
2. Install the necessary libraries and dependencies (provide a list here).
3. Open the project in your preferred IDE or text editor.

## Usage

1. Run the main file to start the game.
2. Use the arrow keys to control the player (fish).

## Game Components

The game consists of several components:

- **Board**: Represents the game area. It is a square grid with dimensions 8x8.
- **Entity**: The base class for objects in the game. It has attributes for position and direction.
- **Player**: Represents the player-controlled fish. Inherits from the Entity class.
- **Enemy**: Represents the enemies in the game that the player must knock out. Inherits from the Entity class.
- **Object**: Represents stationary objects in the game. Inherits from the Entity class, but unlike Player and Enemy, objects do not move.

## Features

- Player movement: The player can move in four directions (up, down, left, and right).
- Enemy knockout: The player can knock out enemies by moving into them.

## Contributing

If you're interested in contributing to the game, feel free to fork the repository and submit a pull request. All contributions are welcome.

## License
MIT
