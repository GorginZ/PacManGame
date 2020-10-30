using System;
using System.Threading;

namespace PacManGame
{
  public class ConsoleGamePlay
  {
    public static void Run()
    {
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level1.txt")));

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
          renderer.Write(renderer.GetStateOfMapAsString(game.Grid, game.PacManCharacter.Heading, game.PacManCharacter.MouthOpen));
          Thread.Sleep(300);
          lock (programLock)
          {
            game.Tick();

          }
          Console.Clear();
          renderer.Write($"Current Level: {game.CurrentLevel}");
          renderer.Write($"Dots Eaten This Level: {game.DotsEatenThisLevel}");
          renderer.Write($"Score: {game.Score}");
          renderer.Write($"Lives: {game.PacManCharacter.Lives}");
        }

      }).Start();

    }
  }
}