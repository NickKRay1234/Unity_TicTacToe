![91jhs5+HeYL](https://github.com/NickKRay1234/Unity_TicTacToe/assets/80714127/38123431-ac02-429f-8bc5-b20f0ce7a773)

<p align="center">
    <img src="https://img.shields.io/badge/Engine-2022.3.4f1-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-0.1-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-None-success" alt="License">
</p>

# Tic-Tac-Toe
## About the Game
"Tic-Tac-Toe" is a classic board game where two players alternately place symbols (one always uses Xs, the other Os) on the free cells of a 3x3 grid. The goal is to align three of their symbols vertically, horizontally, or diagonally.

## Implementation Features
### Design Patterns:
#### MVP (Model-View-Presenter):
- **Model**: Stores game data and logic but does not interact with the user.
- **View**: Responsible for displaying data (game board, game results) and interactivity (cell clicks).
- **Presenter**: Acts as a mediator between Model and View, processing game logic and updating the View.

#### Command:
- Encapsulates requests or simple operations (e.g., a player's move) as objects. This facilitates management and logging of operations, as well as undoing changes.

#### Observer:
- Used for notifying components about changes in other parts of the system, such as signaling the end of a turn or a player's victory.

#### Composite:
- Can be used to build complex structures, specifically combining AI and player moves.

#### StateMachine:
- Manages UI states, switching between different states based on incoming events.

#### EntryPoint:
- Defines the initial entry point into the game or system, such as initializing the game process or loading resources.

#### Factory:
- Used for creating objects (e.g., game elements or AI agents) without specifying concrete classes of objects.

#### DataContainer:
- Provides storage and management of game data, such as the state of the game board, turn order, game history, etc.

### Artificial Intelligence Algorithm - Heuristic:
The **Heuristic Algorithm** in "Tic-Tac-Toe" implies using heuristic methods to determine the best move. These methods can include:
- **Evaluating Winning Opportunities**: AI analyzes the game board to identify moves that increase the chances of winning or block the opponent's attempts to win.
- **Prioritizing Moves**: Choosing moves that are most likely to lead to victory, such as occupying the center of the board or preventing the opponent from forming a continuous line.
- **Adaptive Learning**: AI can analyze previous games to improve its strategies and predictions.

  



https://github.com/NickKRay1234/Unity_TicTacToe/assets/80714127/0373c23d-9506-481a-9022-899abafdc2b8

![image](https://github.com/NickKRay1234/Unity_TicTacToe/assets/80714127/ef472c7c-cb91-4675-9f6d-fde9759f4f34)




https://github.com/NickKRay1234/Unity_TicTacToe/assets/80714127/05537d64-8796-40d8-9cca-f82dfb04d04c




