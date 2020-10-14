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
    public void PacManCanMoveInAnyValidDirection()
    {
      var game = new Game(10, 10);
      var pacmanStartPosition = game.FindPacman();

      game.Tick();

      //East
      Assert.Equal(2, game.FindPacman().Column);

      // game.Tick();
      // //Down/South
      // Assert.Equal(pacmanStartPosition.Column + 1, game.FindPacman().Row - 1);

      // game.Tick();

      //up/ North
      // Assert.Equal(pacmanStartPosition.Column, game.FindPacman().Column - 1);

      // game.Tick();

      // //West
      // Assert.Equal(pacmanStartPosition.Column, game.FindPacman().Column - 1);

    }
  }
}