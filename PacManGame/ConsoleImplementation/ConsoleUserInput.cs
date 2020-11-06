using System;

namespace PacManGame
{
  public class ConsoleUserInput : IUserInput
  {
    public ConsoleKey InputKey { get; set; }

    public CurrentCommand Command { get; set; }

    public void SetInputKey() => InputKey = Console.ReadKey(true).Key;

    public void SetCurrentCommand()
    {
      SetInputKey();
      if (InputKey == ConsoleKey.Escape)
      {
        Command = CurrentCommand.Quit;
      }
      else
      {
        Command = CurrentCommand.Controller;
      }
    }

    public Direction ParseInputToDirection()
    {
      return InputKey switch
      {
        ConsoleKey.W => Direction.North,
        ConsoleKey.S => Direction.South,
        ConsoleKey.A => Direction.West,
        ConsoleKey.D => Direction.East,
        _ => Direction.North

      };

    }

    // public Direction ParseInputToDirection()
    // {
    //   if (InputKey == ConsoleKey.W)
    //   {
    //     return Direction.North;
    //   }
    //   else if (InputKey == ConsoleKey.S)
    //   {
    //     return Direction.South;
    //   }
    //   else if (InputKey == ConsoleKey.D)
    //   {
    //     return Direction.East;
    //   }
    //   else if (InputKey == ConsoleKey.A)
    //   {
    //     return Direction.West;
    //   }

    //   throw new InvalidOperationException();

    // }


  }
}