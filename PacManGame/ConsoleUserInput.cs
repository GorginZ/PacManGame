using System;

namespace PacManGame
{
  public class ConsoleUserInput : IUserInput
  {
    public ConsoleKeyInfo InputKey { get; set; }
    public void ReadInputDirection() => InputKey = Console.ReadKey(true);

    public Direction ParseInputToDirection()
    {
      if (InputKey.Key == ConsoleKey.W)
      {
        return Direction.North;
      }
      else if (InputKey.Key == ConsoleKey.S)
      {
        return Direction.South;
      }
      else if (InputKey.Key == ConsoleKey.D)
      {
        return Direction.East;
      }
      else if (InputKey.Key == ConsoleKey.A)
      {
        return Direction.West;
      }
      else

        throw new InvalidOperationException();
    }

  }
}