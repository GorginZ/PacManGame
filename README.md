# PacManGame

My PacManGame is a console version of PacMan. This kata presented some really fun and interesting challenges and is still a WIP. I am refactoring large components and plan on restructuring and approcahing things differently.

This is what gameplay currently looks like

<img src="docs/PacmanScreen.png">

### Challenges and focuses

One thing I keep returning to throughout this project is wanting to build a foundational core of a game that isn't tied to a console implementation. This has been a focus in how I've refactored and approached some of my previous katas, for instance TicTacToe and Conways Game of Life. I made an effort to either build or pull off any console specific implementation into a seperate console specific running component. The kata IS to develop a console game, but I feel this concern is an important consideration and a valuable way to approach any project.

There's a few reasons this can be hard to approach with Pacman when the immediate goal is to hit MVP and just keep refactoring. 

#### Animating 

The options to 'animate' this game so it feels playable are obviously limited. My game renders a string grid, and so everything must move in the single tick() frame (as specified in the kata).



#### OOP

