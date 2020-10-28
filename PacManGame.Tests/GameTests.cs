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
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));
      var pacManBeforeTick = game.PacManCharacter.CurrentPosition;

      game.SetPacManHeading(Direction.East);
      game.Tick();

      var pacManAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.NotEqual(pacManBeforeTick, pacManAfterTick);

    }
    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));

      var expectedGrid =
        "######.##############.######\n"
        + "#............##............#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "............................\n"
        + "#.####.######  ######.####.#\n"
        + "#.#  #.### M M M ####.#  #.#\n"
        + "#.####.##############.####.#\n"
        + ".............V..............\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#............##............#\n"
        + "######.##############.######\n";

      var actualGrid = game.GetStateOfMapAsString();

      Assert.Equal(expectedGrid, actualGrid);
    }

    [Fact]
    public void PacManWontRotateIntoAWallAndHeadingRemainsAsItWasPreviously()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));
      game.SetPacManHeading(Direction.East);
      game.Tick();
      game.SetPacManHeading(Direction.North);

      Assert.Equal(Direction.East, game.PacManCharacter.Heading);
    }
    [Fact]
    public void PacManStopsAtAWall()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));

      game.SetPacManHeading(Direction.North);
      var pacManPositionBeforeTick = game.PacManCharacter.CurrentPosition;
      game.Tick();
      var pacManPositionAfterTick = game.PacManCharacter.CurrentPosition;

      var gameGrid = game.GetStateOfMapAsString();

      Assert.Equal(pacManPositionBeforeTick, pacManPositionAfterTick);
    }
    [Fact]
    public void ScoreIncrementsWhenPacManEatDot()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));
      game.SetPacManHeading(Direction.East);
      game.Tick();
      Assert.Equal(1, game.DotsEatenThisLevel);
    }
    [Fact]
    public void PacManWrapsAroundRows()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));
      game.SetPacManHeading(Direction.West);

      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      var pacManBeforeWrap = game.PacManCharacter.CurrentPosition;
      game.Tick();
      var pacManAfterWrap = game.PacManCharacter.CurrentPosition;

      Assert.Equal(new RowColumn(10, 0), pacManBeforeWrap);
      Assert.Equal(new RowColumn(10, 27), pacManAfterWrap);
    }

    [Fact]

    public void GhostChangesHeadingWhenHitsWall()
    {

      //change this test. this is unclear.
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));

      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();

      bool rowEquals = game.YellowGhost.CurrentPosition.Row == 1;
      bool colEquals = game.YellowGhost.CurrentPosition.Column == 26;

      Assert.False(rowEquals && colEquals);
    }

    // [Fact]
    // public void GhostDoesntLeaveTrailOfGhosts()
    // {
    //   {
    //        var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));

    //     var ghostStartRow = game.YellowGhost.CurrentPosition.Row;
    //     var ghostStartCol = game.YellowGhost.CurrentPosition.Column;

    //     game.Tick();

    //     bool rowEquals = game.YellowGhost.CurrentPosition.Row == ghostStartRow;
    //     bool colEquals = game.YellowGhost.CurrentPosition.Column == ghostStartCol;

    //     Assert.False(rowEquals && colEquals);
    //   }
    // }
  }
}