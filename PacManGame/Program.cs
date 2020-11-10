using System;
using System.Threading;

namespace PacManGame
{
  class Program
  {
    static void Main(string[] args)
    {
      var level = LevelCore.Parse(System.IO.File.ReadAllText(@"./GameCore/LevelConfig/LevelMaps/level1.txt"));
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      var directionGenerator = new RandomDirectionGenerator();
      
     GamePlay.Run(renderer, userInput, level, directionGenerator);
    }

  }
}


