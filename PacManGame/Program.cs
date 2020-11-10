using System;
using System.Threading;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var level = LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt"));
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      var directionGenerator = new RandomDirectionGenerator();
      
      //this isn't serious I just wanted to break something with threads

      // var programLock = new object();
      // Thread listenForUserInput = new Thread(() =>
      // {
      //   while (!userInput.ContinuePlay)
      //   {
      //     lock (programLock)
      //     {
      //       renderer.RenderMenu();
      //       userInput.SetInputKey();
      //       userInput.SetContinuePlay();
      //     }
      //   }
      // }); listenForUserInput.Start();


     GamePlay.Run(renderer, userInput, level, directionGenerator);
    }

  }
}


