using System;

namespace PacManGame
{
  public class ConsoleUserInput : IUserInput
  {
    public Direction GetUserInput()
    {
      ConsoleKeyInfo input = Console.ReadKey(true);
      if (input.Key == ConsoleKey.W)
      {
        return Direction.North;
      }
      else if (input.Key == ConsoleKey.S)
      {
        return Direction.South;
      }
      else if (input.Key == ConsoleKey.D)
      {
        return Direction.East;
      }
      else if (input.Key == ConsoleKey.A)
      {
        return Direction.West;
      }
      else

        throw new InvalidOperationException();
    }
  }
}