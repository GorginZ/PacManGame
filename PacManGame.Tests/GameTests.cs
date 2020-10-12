using System;
using Xunit;

namespace PacManGame.Tests
{
  public class GameTests
  {
    [Fact]
    public void PacManGameHasACurrentPosition()
    {
      var game = new Game(10, 10);
      var gameGrid = game.GetGrid();

      var expectedPacman = new PacMan(1, 1);
      var actualValue = gameGrid[1][1];


      Assert.Equal(1, expectedPacman.CurrentPosition.Column);
      Assert.Equal(1, expectedPacman.CurrentPosition.Row);


    }
  }
}
