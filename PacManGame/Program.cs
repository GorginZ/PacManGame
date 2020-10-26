using System;
using System.Threading;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new Game();
      var userInput = new ConsoleUserInput();

      var programLock = new object();

      new Thread(() =>
      {
        while (1 < 100)
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
        while (1 < 100)
        {
          Console.Write(game.PrintableGrid());
          Thread.Sleep(300);
          lock (programLock)
          {
            game.Tick();
          }
          Console.Clear();

          Console.WriteLine($"Score: {game.DotsEatenThisLevel}");
          Console.WriteLine($"Lives: {game.Lives}");

        }

      }).Start();





    }
  }
}

