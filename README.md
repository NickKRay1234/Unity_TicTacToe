![image]([https://user-images.githubusercontent.com/76531899/216824082-f614e3da-2bec-450c-9529-81d38a542a99.png](https://www.coolmathgames.com/sites/default/files/TicTacToe_OG-logo.jpg))

<p align="center">
    <img src="https://img.shields.io/badge/Engine-2022.3.4f1-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-0.1-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-None-success" alt="License">
</p>

Tic-Tac-Toe
About the Game
"Tic-Tac-Toe" is a classic board game where two players alternately place symbols (one always uses Xs, the other Os) on the free cells of a 3x3 grid. The goal is to align three of their symbols vertically, horizontally, or diagonally.

Implementation Features
Design Patterns:
MVP (Model-View-Presenter):

Model: Stores game data and logic but does not interact with the user.
View: Responsible for displaying data (game board, game results) and interactivity (cell clicks).
Presenter: Acts as a mediator between Model and View, processing game logic and updating the View.
Command:

Encapsulates requests or simple operations (e.g., a player's move) as objects. This facilitates management and logging of operations, as well as undoing changes.
Observer:

Used for notifying components about changes in other parts of the system, such as signaling the end of a turn or a player's victory.
Composite:

Can be used to build complex structures, specifically combining AI and player moves.
StateMachine:

Manages UI states, switching between different states based on incoming events.
EntryPoint:

Defines the initial entry point into the game or system, such as initializing the game process or loading resources.
Factory:

Used for creating objects (e.g., game elements or AI agents) without specifying concrete classes of objects.
DataContainer:

Provides storage and management of game data, such as the state of the game board, turn order, game history, etc.
Artificial Intelligence Algorithm - Heuristic:
The Heuristic Algorithm in "Tic-Tac-Toe" implies using heuristic methods to determine the best move. These methods can include:

Evaluating Winning Opportunities: AI analyzes the game board to identify moves that increase the chances of winning or block the opponent's attempts to win.
Prioritizing Moves: Choosing moves that are most likely to lead to victory, such as occupying the center of the board or preventing the opponent from forming a continuous line.
Adaptive Learning: AI can analyze previous games to improve its strategies and predictions.
Each of these patterns and algorithms contributes to creating a flexible, scalable, and easily maintainable structure for the "Tic-Tac-Toe" game.
