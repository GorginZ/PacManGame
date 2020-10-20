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



      while (1 < 100)
      {
        Console.Write(game.PrintableGrid());

        userInput.ReadInputDirection();
        var userInputDirection = userInput.ParseInputToDirection();
        game.SetPacManHeading(userInputDirection);

        game.Tick();
        Console.Clear();

        Console.WriteLine(game.PacManCharacter.Heading);

      }
    }


  }
}

