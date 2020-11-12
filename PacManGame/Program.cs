using System;
using System.IO;
using System.Reflection;
using System.Threading;
using static System.IO.Path;

namespace PacManGame
{
  class Program
  {
    public static string ProgramFolder => GetDirectoryName(new Uri(typeof(Program).Assembly.Location).LocalPath);
    public static string LevelFolder => Combine(ProgramFolder, @"./GameCore/LevelConfig/LevelMaps" );
    static void Main(string[] args)
    {
      var level = LevelCore.Parse(File.ReadAllText(Combine(LevelFolder, "level1.txt")));
      var renderer = new ConsoleRenderer();
      var userInput = new ConsoleUserInput();
      var directionGenerator = new RandomDirectionGenerator();
      
     GamePlay.Run(renderer, userInput, level, directionGenerator);
    }

  }
}


