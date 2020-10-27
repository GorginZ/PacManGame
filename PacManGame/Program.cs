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
          Console.Write(game.PrintableGrid());
          Thread.Sleep(300);
          lock (programLock)
          {
            game.Tick();

          }
          Console.Clear();
          Console.WriteLine($"Current Level: {game.CurrentLevel}");
          Console.WriteLine($"Dots Eaten This Level: {game.DotsEatenThisLevel}");
          Console.WriteLine($"Score: {game.Score}");
          Console.WriteLine($"Lives: {game.Lives}");

         


        }

      }).Start();





    }
  }
}

