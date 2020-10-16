using System;
using Xunit;

namespace PacManGame.Tests
{
  public class ConsoleUserInputTests
  {
    // [Theory]
    // [InlineData(ConsoleKey.W, ConsoleKey.S, ConsoleKey.A, ConsoleKey.D)]
    // [InlineData(Direction.North, Direction.South, Direction.West, Direction.East)]
    [Fact]
    public void UserCanRotatePacmanWithWSADKeys()
    {
      var game = new Game(10, 10);
      var userInput = new ConsoleUserInput();
      userInput.InputKey = ConsoleKey.A;
      
      game.PacManCharacter.Heading = userInput.ParseInputToDirection();

      Assert.True(game.PacManCharacter.Heading == Direction.West);
    }

  }

}