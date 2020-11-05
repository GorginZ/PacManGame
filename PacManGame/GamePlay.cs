using System;
using System.Threading;

namespace PacManGame
{
  public class GamePlay
  {
    public static void Run(IRenderer renderer, ConsoleUserInput userInput, LevelCore level)
    {
      var game = new Game(level);

      var programLock = new object();

      new Thread(() =>
      {
        while (true)
        {
          userInput.ReadInputDirection();
          var userInputDirection = userInput.ParseInputToDirection();
          lock (programLock)
          {
            game.SetPacManHeading(userInputDirection);
          }
        }

      }).Start();

      new Thread(() =>
      {
        while (true)
        {
          Thread.Sleep(300);
          lock (programLock)
          {
            renderer.Render(game);
            game.Tick();
          }
        }
      }).Start();

    }
  }
}