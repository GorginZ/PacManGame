# PacManGame

My PacManGame is a console version of PacMan. This kata presented some really fun and interesting challenges and is still a WIP. I am refactoring large components and plan on restructuring and approcahing a few things differently - for instance I am intersted in reprsenting my grid differently.

## Challenges and focuses

------



#### Building a cohesive core

A concern throughout this project is building game logic core that isn't tied to a console implementation. This has been a focus in my refactoring of my recent katas, particularly Conways Game of Life. I pulled off any console specific implementations into a seperate console specific running component.

The kata asks us to develop a console game, however I think this is an invaluable opportunity to try and think about things like decoupling and cohesiveness.

The game class previously hosted a couple of functions that are tied up with console implementation that undermined the cohesive 'core' I'm trying to build. These functions come from the need to visualize the game and 'animate' it.



```c#
    public string GetPacManSymbol() 
    {
      switch (PacManCharacter.Heading)
      {
        case Direction.North:
          var northSymbol = PacManCharacter.MouthOpen ? ("V") : ("|");
          return northSymbol;

        case Direction.East:
          var eastSymbol = PacManCharacter.MouthOpen ? ("<") : ("-");
          return eastSymbol;

        case Direction.South:
          var southSymbol = PacManCharacter.MouthOpen ? ("^") : ("|");
          return southSymbol;

        case Direction.West:
          var westSymbol = PacManCharacter.MouthOpen ? (">") : ("-");
          return westSymbol;

        default:
          throw new System.ArgumentOutOfRangeException(nameof(PacManCharacter.Heading));
      }
    }


public String GetStateOfMapAsString() 
    {
      var printableGrid = new StringBuilder();

      for (int i = 0; i < _grid.RowCount; i++)
      {
        for (int j = 0; j < _grid.ColumnCount; j++)
        {
          var coordinate = new RowColumn(i, j);

          printableGrid.Append(_grid[coordinate].PrintableCell(GetPacManSymbol()));
        }
        printableGrid.Append("\n");
      }

      return printableGrid.ToString();
    }
```



I have pulled these off into a ConsoleRenderer class and created a ConsoleImplementation directory where anythign strictly consol implementation sits. My ConsoleRenderer class implements a IRender interface member Render(), as well as the above functions.

 I am now able to pass in a renderer, input type and level into my GamePlay run func.



```c#
using System;
using System.Threading;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {      
      var level = LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt"));
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      GamePlay.Run(renderer, userInput, level);
    }
  }
}
```





#### Animating 

my console renderer renders a string which reflects the current state of the games grid data. It also renders stats like score, level, lives.

<img src="docs/PacmanScreen.png">

this data is updated every time the game Tick() function is called. 



```c#

```





#### OOP



### Tests

