# RPG Game CLI - Game State Machine

## Overview

This project is a **text-based RPG (Role-Playing Game)** Command Line Interface (CLI) built using C#. The game allows players to navigate between rooms, pick up objects, manage their inventory, and save/load their progress. The game is designed with a **state machine architecture**, making it modular and easy to extend with new features.

The game features:
- **Room navigation**: Move between connected rooms.
- **Inventory management**: Pick up items, drop them, and view your inventory.
- **Item interaction**: Use or pick up items found in rooms.
- **Save/Load functionality**: Save your game progress and load it later.
- **Command-based system**: Execute commands like moving, picking items, saving, and loading.

---

## Project Structure

The project is organized into several namespaces and classes, each responsible for different aspects of the game:

---

### Key Classes and Interfaces

- **ICommand**: Defines the `Execute` method for commands.
- **IGame**: Defines the game interface with methods for managing game objects.
- **IGameObject**: Defines the interface for game objects, including methods for saving and loading.
- **IState**: Defines the interface for game states, including methods for rendering and getting commands.
- **Game**: Implements the `IGame` interface and manages the game objects and player.
- **StateManager**: Manages the current state of the game and handles state transitions.
- **GameFilePersistence**: Handles saving and loading game states to/from files.

---

## How It Works

1. **Game States**: The game is divided into different states, such as `MainMenuState`, `InventoryState`, `RoomState`, etc. Each state is responsible for rendering its UI and handling user input.
2. **Commands**: Each state can return a command based on user input. Commands are responsible for executing specific actions, such as switching states, picking up items, or saving the game.
3. **State Manager**: The `StateManager` class is responsible for managing the current state and executing commands. It runs in a loop, continuously rendering the current state and executing commands.
4. **Game Objects**: The game objects, such as `Player`, `Room`, and `Item`, are managed by the `Game` class. These objects can be saved and loaded using the `GameFilePersistence` class.

---

## Features

### Room Navigation
- Players can move between connected rooms using the `move` command.
- Each room has a description and a list of connected rooms.

### Inventory Management
- Players can pick up items using the `pick` command.
- Players can drop items from their inventory using the `drop` command.
- Players can view their inventory by entering the `inventory` state.

### Item Interaction
- Players can interact with items in rooms using the `use` command.
- Some items are `IPickupable`, meaning they can be picked up and added to the inventory.

### Save and Load
- Players can save their game progress using the `save` command.
- Players can load a previously saved game using the `load` command.

---

## Usage

To run the game, initialize the `StateManager` with an initial state, such as the `MainMenuState`. The game will then enter a loop where it continuously renders the current state and processes user input.

### Example

```csharp
var game = new Game();
var stateManager = new StateManager();
var mainMenuState = new MainMenuState(stateManager, game);

stateManager.Run(mainMenuState);