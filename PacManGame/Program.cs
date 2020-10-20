using System;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var game = new Game();
      var userInput = new ConsoleUserInput();

      userInput.ReadInputDirection();
      var userInputDirection = userInput.ParseInputToDirection();

      game.SetPacManHeading(userInputDirection);

      Console.WriteLine(game.PacManCharacter.Heading);

      Console.Write(game.PrintableGrid());



  }

}
}
