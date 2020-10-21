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

      new Thread(() =>
      {
        while (1 < 100)
        {
          userInput.ReadInputDirection();
          var userInputDirection = userInput.ParseInputToDirection();
          game.SetPacManHeading(userInputDirection);

        }

      }).Start();

      new Thread(() =>
      {
        while (1 < 100)
        {
          Console.Write(game.PrintableGrid());
          Thread.Sleep(300);
          game.Tick();
          Console.Clear();

          Console.WriteLine($"Score: {game.DotsEatenThisLevel}");

        }

      }).Start();





    }
  }
}

