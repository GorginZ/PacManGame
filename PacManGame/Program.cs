using System;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new Game(10, 10);
      var userInput = new ConsoleUserInput();
      
      userInput.ReadInputDirection();
      game.PacManCharacter.Heading = userInput.ParseInputToDirection();
      Console.WriteLine(game.PacManCharacter.Heading);



    }

  }
}
