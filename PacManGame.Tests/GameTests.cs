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
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")));
      var pacManBeforeTick = game.PacManCharacter.CurrentPosition;

      game.SetPacManHeading(Direction.East);
      game.Tick();

      var pacManAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.NotEqual(pacManBeforeTick, pacManAfterTick);

    }

    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")));
      var consoleRenderer = new ConsoleRenderer();


      var expectedGrid =
        "######.##############.######\n"
        + "#............##............#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "............................\n"
        + "#.####.######  ######.####.#\n"
        + "#.#  #.###       ####.#  #.#\n"
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
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")));
      game.SetPacManHeading(Direction.East);
      game.Tick();
      game.SetPacManHeading(Direction.North);

      Assert.Equal(Direction.East, game.PacManCharacter.Heading);
    }
    [Fact]
    public void PacManStopsAtAWall()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")));

      game.SetPacManHeading(Direction.North);
      var pacManPositionBeforeTick = game.PacManCharacter.CurrentPosition;
      game.Tick();
      var pacManPositionAfterTick = game.PacManCharacter.CurrentPosition;


      Assert.Equal(pacManPositionBeforeTick, pacManPositionAfterTick);
    }
    [Fact]
    public void ScoreIncrementsWhenPacManEatDot()
    {
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")));
      game.SetPacManHeading(Direction.East);
      game.Tick();
      Assert.Equal(1, game.DotsEatenThisLevel);
    }
    [Fact]
    public void PacManWrapsAroundRows()
    {
      var consoleRenderer = new ConsoleRenderer();

      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame.Tests/TestMaps/SimpleWrappingMap.txt")));
      game.SetPacManHeading(Direction.East);

      var expectedGrid =
      "-..... \n"
    + ".......\n"
    + ".......\n";

      game.Tick();
      var actualGrid = consoleRenderer.GetStateOfMapAsString(game);

      Assert.Equal(expectedGrid, actualGrid);
    }

    [Fact]
    public void PacManWrapsAroundColumns()
    {
      var consoleRenderer = new ConsoleRenderer();

      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame.Tests/TestMaps/SimpleWrappingMap.txt")));
      game.SetPacManHeading(Direction.North);

      var expectedGrid =
      "...... \n"
    + ".......\n"
    + "......|\n";

      game.Tick();
      var actualGrid = consoleRenderer.GetStateOfMapAsString(game);

      Assert.Equal(expectedGrid, actualGrid);
    }


    [Fact]
    public void GhostCanNavigate()
    {

    }

    [Fact]
    public void GhostLeavesAppropriateCellStateBehind()
    {

    }
  }
}