using System;

namespace PacManGame
{
  public class ConsoleUserInput : IUserInput
  {
    public ConsoleKey InputKey { get; set; }

    public bool ContinuePlay { get; set; } = true;

    public void SetInputKey() => InputKey = Console.ReadKey(true).Key;

    public void SetContinuePlay()
    {
      if (InputKey == ConsoleKey.Escape)
      {
        ContinuePlay = false;
      }
      if (InputKey == ConsoleKey.P)
      {
        ContinuePlay = true;
      }
    }
    public Direction ParseInputToDirection()
    {
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
 
      throw new InvalidOperationException();

    }


  }
}