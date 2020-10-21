using System;

namespace PacManGame
{
  public class ConsoleUserInput : IUserInput
  {
    public ConsoleKey InputKey { get; set; }

    public void ReadInputDirection() => InputKey = Console.ReadKey(true).Key;

    public Direction ParseInputToDirection()
    {
      // while (IsKeyDown(InputKey))
      // {
        if (InputKey == ConsoleKey.W)
        {
          return Direction.North;
        }
        else if (InputKey == ConsoleKey.S)
        {
          return Direction.South;
        }
        else if (InputKey == ConsoleKey.D)
        {
          return Direction.East;
        }
        else if (InputKey == ConsoleKey.A)
        {
          return Direction.West;
        }
      // }
      throw new InvalidOperationException();

    }

    public static Boolean IsKeyDown(ConsoleKey key)
    {
      if (key != ConsoleKey.A || key != ConsoleKey.W || key != ConsoleKey.S || key != ConsoleKey.D)
      {
        if (key == ConsoleKey.A || key == ConsoleKey.W || key == ConsoleKey.S || key == ConsoleKey.D)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        return false;
      }
    }



  }
}