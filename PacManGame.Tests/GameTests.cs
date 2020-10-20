using System;
using System.Linq;
using Xunit;

namespace PacManGame.Tests
{
  public class GameTests
  {
    [Fact]
    public void PacManHasACurrentPosition()
    {
      var game = new Game();

      var pacmanPosition = game.FindPacman();

      Assert.Equal(1, pacmanPosition.Row);
      Assert.Equal(1, pacmanPosition.Column);
    }
    [Fact]
    public void PacManCanMoveOnTheBoardOnTick()
    {
      var game = new Game();
      var pacManStartingPosition = game.FindPacman();

      game.Tick();
      var pacManCurrentPosition = game.FindPacman();
      

      Assert.NotEqual(pacManStartingPosition, pacManCurrentPosition);


    }
    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var game = new Game();

      var expectedGrid = "############################\n"
                       + "#P...........##............#\n"
                       + "#.####.#####.##.#####.####.#\n"
                       + "#.#  #.#   #.##.#   #.#  #.#\n"
                       + "#.####.#   #.##.#   #.#  #.#\n"
                       + "#......#####....#   #.####.#\n"
                       + "######.#####.##.#####......#\n"
                       + "#    #.......##.......####.#\n"
                       + "######.#####.##.#####.#  #.#\n"
                       + ".......#   #.##.#   #.#  #..\n"
                       + "######.#   #.##.#####.####.#\n"
                       + "#    #.#####.##.#   #.#  #.#\n"
                       + "######.#####.##.#####.####.#\n"
                       + "#............##............#\n"
                       + "############################\n";

      var actualGrid = game.PrintableGrid();

      Assert.Equal(expectedGrid, actualGrid);
    }

    [Fact]
    public void PacManWontRotateIntoAWallAndHeadingRemainsAsItWasPreviously()
    {
      var game = new Game();
      game.SetPacManHeading(Direction.East);
      game.Tick();
      game.SetPacManHeading(Direction.North);

      Assert.Equal(Direction.East, game.PacManCharacter.Heading);
    }
[Fact]
    public void PacManCantMoveOnOrThroughWall()
    {
      var game = new Game();

      var expectedGrid = "############################\n"
                       + "#P...........##............#\n"
                       + "#.####.#####.##.#####.####.#\n"
                       + "#.#  #.#   #.##.#   #.#  #.#\n"
                       + "#.####.#   #.##.#   #.#  #.#\n"
                       + "#......#####....#   #.####.#\n"
                       + "######.#####.##.#####......#\n"
                       + "#    #.......##.......####.#\n"
                       + "######.#####.##.#####.#  #.#\n"
                       + ".......#   #.##.#   #.#  #..\n"
                       + "######.#   #.##.#####.####.#\n"
                       + "#    #.#####.##.#   #.#  #.#\n"
                       + "######.#####.##.#####.####.#\n"
                       + "#............##............#\n"
                       + "############################\n";
      game.SetPacManHeading(Direction.North);
      game.Tick();

      var gameGrid = game.PrintableGrid();

      Assert.Equal(expectedGrid, gameGrid);

    }


  }
}