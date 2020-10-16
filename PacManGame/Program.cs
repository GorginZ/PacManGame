using System;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new Game(10, 10);
      var userInput = new ConsoleUserInput();

      game.PacManCharacter.Heading = userInput.GetUserInput();
      Console.WriteLine(game.PacManCharacter.Heading);



    }
 
  }
}
