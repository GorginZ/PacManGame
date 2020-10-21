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
    public void UsersInputViaWSADKeysCanBeUsedToSetDirection()
    {
      var userInput = new ConsoleUserInput();
      userInput.InputKey = ConsoleKey.A;
      
      var parsedDirection = userInput.ParseInputToDirection();

      Assert.True(parsedDirection == Direction.West);
    }

  }

}