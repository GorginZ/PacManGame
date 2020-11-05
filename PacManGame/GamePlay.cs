using System;
using System.Threading;

namespace PacManGame
{
  public class GamePlay
  {
    public static void Run(IRenderer renderer, IUserInput userInput, LevelCore level)
    {
      var game = new Game(level);
      var programLock = new object();
      bool running = true;

      Thread listenForUserInput = new Thread(() =>
      {
        while (running)
        {
          
          userInput.SetInputKey();
          userInput.SetContinuePlay();
          // SetRunning();
          var userInputDirection = userInput.ParseInputToDirection();
          lock (programLock)
          {
            game.SetPacManHeading(userInputDirection);
          }
        }

      }); listenForUserInput.Start();

      Thread render = new Thread(() =>
           {
             while (running)
             {
               Thread.Sleep(300);
               lock (programLock)
               {
                 renderer.Render(game);
                 game.Tick();
               }
             }
           }); render.Start();

    }

    // public static void SetRunning()
    // {
    //   var running = (userInput.ContinuePlay) ? true : false;

    // }
  }
}