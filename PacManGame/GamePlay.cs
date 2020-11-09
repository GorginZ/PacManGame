using System;
using System.Threading;

namespace PacManGame
{
  public class GamePlay
  {
    public static void Run(IRenderer renderer, IUserInput userInput, LevelCore level, IGhostDirectionGenerator directionGenerator)
    {
      var game = new Game(level, directionGenerator);
      var programLock = new object();

      Thread listenForUserInput = new Thread(() =>
       {
         while (userInput.Command < CurrentCommand.Quit)
         {
           userInput.SetCurrentCommand();
           var userInputDirection = userInput.ParseInputToDirection();
           lock (programLock)
           {
             game.SetPacManHeading(userInputDirection);
           }
         }

       }); listenForUserInput.Start();

      Thread render = new Thread(() =>
           {
             while (userInput.Command < CurrentCommand.Quit)
             {
               Thread.Sleep(300);
               lock (programLock)
               {
                 renderer.Render(game);
                 game.Tick(directionGenerator);

               }
             }
           }); render.Start();
    }


  }
}