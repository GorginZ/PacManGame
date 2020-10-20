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
    public void MapHasWalls()
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
    public void PacManWontRotateIntoAWall()
    {
      var game = new Game();
      game.SetPacManHeading(Direction.West);

      Assert.Equal(Direction.North, game.PacManCharacter.Heading);
    }


  }
}