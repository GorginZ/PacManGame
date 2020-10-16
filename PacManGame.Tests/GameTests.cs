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
      var game = new Game(10, 10);

      var pacmanPosition = game.FindPacman();

      Assert.Equal(1, pacmanPosition.Row);
      Assert.Equal(1, pacmanPosition.Column);
    }
    [Fact]
    public void PacManCanMoveOnTheBoardOnTick()
    {
      var game = new Game(10, 10);
      var pacManStartingPosition = game.FindPacman();

      game.Tick();
      var pacManCurrentPosition = game.FindPacman();

      Assert.NotEqual(pacManStartingPosition, pacManCurrentPosition);


    }

 
  }
}