using System;
using System.Linq;
using System.Text;
using Xunit;

namespace PacManGame.Tests
{
  public class GameTests
  {
    [Fact]
    public void PacManCanMoveOnTheBoardOnTick()
    {

      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      var pacManBeforeTick = game.PacManCharacter.CurrentPosition;


      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);

      var pacManAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.NotEqual(pacManBeforeTick, pacManAfterTick);

    }

    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      var consoleRenderer = new ConsoleRenderer();


      var expectedGrid =
        "######.##############.######\n"
        + "#............##............#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "............................\n"
        + "#.####.#####    #####.####.#\n"
        + "#.#  #.##          ##.#  #.#\n"
        + "#.####.##############.####.#\n"
        + ".............V..............\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#............##............#\n"
        + "######.##############.######\n";
      var actualGrid = consoleRenderer.GetStateOfMapAsString(game);

      Assert.Equal(expectedGrid, actualGrid);
    }

    [Fact]
    public void PacManWontRotateIntoAWallAndHeadingRemainsAsItWasPreviously()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);
      game.SetPacManHeading(Direction.North);

      Assert.Equal(Direction.East, game.PacManCharacter.Heading);
    }

    [Fact]
    public void PacManStopsAtAWall()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);

      game.SetPacManHeading(Direction.North);
      var pacManPositionBeforeTick = game.PacManCharacter.CurrentPosition;
      game.Tick(directionSetter);
      
      var pacManPositionAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.Equal(pacManPositionBeforeTick, pacManPositionAfterTick);
    }
    [Fact]
    public void ScoreIncrementsWhenPacManEatDot()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);
      Assert.Equal(1, game.DotsEatenThisLevel);
    }
    [Fact]
    public void PacManWrapsAroundHorizontalAxis()
    {
      var consoleRenderer = new ConsoleRenderer();

      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      
      var pacmanCharBeforeWrap = game.PacManCharacter.CurrentPosition;
        
      game.Tick(directionSetter);
      var actualAfterWrap = game.PacManCharacter.CurrentPosition;

      var beforeTickIndex = new RowColumn(10,27);
      Assert.Equal(beforeTickIndex.Column, pacmanCharBeforeWrap.Column); 
      Assert.Equal(0, actualAfterWrap.Column);
    }

    [Fact]
    public void PacManWrapsAroundVerticalAxis()
    {
      var consoleRenderer = new ConsoleRenderer();

      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      //8 7
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.SetPacManHeading(Direction.South);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      game.Tick(directionSetter);
      var pacmanIndexBeforeWrap = game.PacManCharacter.CurrentPosition.Row;
      game.Tick(directionSetter);
        
      var actualAfterWrap = game.PacManCharacter.CurrentPosition.Row;

      Assert.Equal(17, pacmanIndexBeforeWrap); 
      Assert.Equal(0, actualAfterWrap);
    }


    [Fact]
    public void GhostCanNavigate()
    {

    }

    [Fact]
    public void GhostLeavesCellStateThatWasPreviouslyThereBehind()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.Tick(directionSetter);
      var position = game.Ghosts[0].CurrentPosition;
      

      // where wil it be what 
      game.Tick(directionSetter);
// ghost not ther anymore

// at posiiton, is it a dot?
//      Assert.Equal(positi)
    }
  }
}
