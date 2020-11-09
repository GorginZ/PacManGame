using System;

namespace PacManGame
{
  public class RandomDirectionGenerator : IGhostDirectionGenerator
  {
    public Direction SetDirection()
    {
      var rng = new Random();

      return (Direction)rng.Next((int)Direction.North, (int)Direction.West + 1);
    }

  }
}
