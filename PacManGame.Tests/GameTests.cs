using System;
using System.Linq;
using System.Text;
using Xunit;

namespace PacManGame.Tests
{
  public class GameTests
  {
    [Fact]
    public void PacManCanMoveOnTheBoardOnTick()
    {

      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      var pacManBeforeTick = game.PacManCharacter.CurrentPosition;


      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);

      var pacManAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.NotEqual(pacManBeforeTick, pacManAfterTick);

    }


    [Fact]
    public void PacManWontRotateIntoAWallAndHeadingRemainsAsItWasPreviously()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);
      game.SetPacManHeading(Direction.North);

      Assert.Equal(Direction.East, game.PacManCharacter.Heading);
    }

    [Fact]
    public void PacManStopsAtAWall()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);

      game.SetPacManHeading(Direction.North);
      var pacManPositionBeforeTick = game.PacManCharacter.CurrentPosition;
      game.Tick(directionSetter);
      
      var pacManPositionAfterTick = game.PacManCharacter.CurrentPosition;

      Assert.Equal(pacManPositionBeforeTick, pacManPositionAfterTick);
    }
    [Fact]
    public void ScoreIncrementsWhenPacManEatDot()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      game.SetPacManHeading(Direction.East);
      game.Tick(directionSetter);
      Assert.Equal(1, game.DotsEatenThisLevel);
    }
    [Fact]
    public void PacManWrapsAroundHorizontalAxis()
    {
     var level = "...\n...\n..P";
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(level), directionSetter);
      game.SetPacManHeading(Direction.East);
        
      game.Tick(directionSetter);
      var actualColumnAfterWrap = game.PacManCharacter.CurrentPosition.Column;

      Assert.Equal(0, actualColumnAfterWrap);
    }

    [Fact]
    public void PacManWrapsAroundVerticalAxis()
    {
       var level = "...\n...\n..P";
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(level), directionSetter);

      game.SetPacManHeading(Direction.South);
      game.Tick(directionSetter);
        
      var actualRowAfterWrap = game.PacManCharacter.CurrentPosition.Row;

      Assert.Equal(0, actualRowAfterWrap);
    }

  }
}
