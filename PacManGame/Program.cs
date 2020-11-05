using System;
using System.Threading;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {      
      var level = LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt"));
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      GamePlay.Run(renderer, userInput, level);

      // var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));
      // var userInput = new ConsoleUserInput();

      // var programLock = new object();

      // new Thread(() =>
      // {
      //   while (true) 
      //   {
      //     userInput.ReadInputDirection();
      //     var userInputDirection = userInput.ParseInputToDirection();
      //     lock (programLock)
      //     {
      //       game.SetPacManHeading(userInputDirection);
      //     }
      //   }

      // }).Start();

      // new Thread(() =>
      // {
      //   while (true)
      //   {
      //     Console.Write(game.GetStateOfMapAsString());
      //     Thread.Sleep(300);
      //     lock (programLock)
      //     {
      //       game.Tick();

      //     }
      //     Console.Clear();
      //     Console.WriteLine($"Current Level: {game.CurrentLevel}");
      //     Console.WriteLine($"Dots Eaten This Level: {game.DotsEatenThisLevel}");
      //     Console.WriteLine($"Score: {game.Score}");
      //     Console.WriteLine($"Lives: {game.PacManCharacter.Lives}");

         


      //   }

      // }).Start();

    }
  }
}

