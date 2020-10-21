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
      var game = new Game();
      var expectedGrid = "###### ############## ######\n"
                      + "# P..........##............#\n"
                      + "#.####.#####.##.#####.####.#\n"
                      + "#.#  #.#   #.##.#   #.#  #.#\n"
                      + "#.####.#   #.##.#   #.#  #.#\n"
                      + "#......#####....#   #.####.#\n"
                      + "######.#####.##.#####......#\n"
                      + "#    #.......##.......####.#\n"
                      + "######.#####.##.#####.#  #.#\n"
                      + " ......#   #.##.#   #.#  #. \n"
                      + "######.#   #.##.#####.####.#\n"
                      + "#    #.#####.##.#   #.#  #.#\n"
                      + "######.#####.##.#####.####.#\n"
                      + "#............##.........MMM#\n"
                      + "###### ############## ######\n";
      game.SetPacManHeading(Direction.East);

      game.Tick();
      var actualGrid = game.PrintableGrid();


      Assert.Equal(expectedGrid, actualGrid);


    }
    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var game = new Game();

      var expectedGrid = "###### ############## ######\n"
                       + "#P...........##............#\n"
                       + "#.####.#####.##.#####.####.#\n"
                       + "#.#  #.#   #.##.#   #.#  #.#\n"
                       + "#.####.#   #.##.#   #.#  #.#\n"
                       + "#......#####....#   #.####.#\n"
                       + "######.#####.##.#####......#\n"
                       + "#    #.......##.......####.#\n"
                       + "######.#####.##.#####.#  #.#\n"
                       + " ......#   #.##.#   #.#  #. \n"
                       + "######.#   #.##.#####.####.#\n"
                       + "#    #.#####.##.#   #.#  #.#\n"
                       + "######.#####.##.#####.####.#\n"
                       + "#............##.........MMM#\n"
                       + "###### ############## ######\n";

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
    public void PacManStopsAtAWall()
    {
      var game = new Game();

      var expectedGrid = "###### ############## ######\n"
                      + "#P...........##............#\n"
                      + "#.####.#####.##.#####.####.#\n"
                      + "#.#  #.#   #.##.#   #.#  #.#\n"
                      + "#.####.#   #.##.#   #.#  #.#\n"
                      + "#......#####....#   #.####.#\n"
                      + "######.#####.##.#####......#\n"
                      + "#    #.......##.......####.#\n"
                      + "######.#####.##.#####.#  #.#\n"
                      + " ......#   #.##.#   #.#  #. \n"
                      + "######.#   #.##.#####.####.#\n"
                      + "#    #.#####.##.#   #.#  #.#\n"
                      + "######.#####.##.#####.####.#\n"
                      + "#............##.........MMM#\n"
                      + "###### ############## ######\n";
      game.SetPacManHeading(Direction.North);
      game.Tick();

      var gameGrid = game.PrintableGrid();

      Assert.Equal(expectedGrid, gameGrid);

    }
    [Fact]
    public void ScoreIncrementsWhenPacManEatDot()
    {
      var game = new Game();
      game.SetPacManHeading(Direction.East);
      game.Tick();
      Assert.Equal(1, game.DotsEatenThisLevel);
    }
    [Fact]
    public void PacManWrapsAround()
    {
      var game = new Game();

      var expectedGrid = "###### ############## ######\n"
                       + "#      ......##............#\n"
                       + "#.####.#####.##.#####.####.#\n"
                       + "#.#  #.#   #.##.#   #.#  #.#\n"
                       + "#.####.#   #.##.#   #.#  #.#\n"
                       + "#......#####....#   #.####.#\n"
                       + "######.#####.##.#####......#\n"
                       + "#    #.......##.......####.#\n"
                       + "######.#####.##.#####.#  #.#\n"
                       + " ......#   #.##.#   #.#  #. \n"
                       + "######.#   #.##.#####.####.#\n"
                       + "#    #.#####.##.#   #.#  #.#\n"
                       + "######.#####.##.#####.####.#\n"
                       + "#............##.........MMM#\n"
                       + "######P############## ######\n";
      game.SetPacManHeading(Direction.East);
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.Tick();
      game.SetPacManHeading(Direction.North);
      game.Tick();
      game.Tick();

      var gameGrid = game.PrintableGrid();

      Assert.Equal(expectedGrid, gameGrid);

    }

    [Fact]

    public void GhostChangesHeadingWhenHitsWall()
    {
      var game = new Game();

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

    public void GhostDoesntLeaveTrailOfGhosts(){
      
    }

  }
}