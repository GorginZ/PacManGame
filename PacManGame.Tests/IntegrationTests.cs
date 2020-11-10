using System;
using System.Linq;
using System.Text;
using Xunit;

namespace PacManGame.Tests
{
public class IntegrationTests
{
    [Fact]
    public void WhenGhostMovesOnTheGridTheGridCellMaintainsItsPreviousCellTypeWhenGhostMovesOffTheCell()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      var  position = game.Ghosts[0].CurrentPosition;
      var index = new RowColumn(position.Row, position.Column+1);
      CellType cellTypeAtPosBeforeGhost = game.Grid[index].CellContents;

      game.Tick(directionSetter);
      CellType cellTypeAtPosAfterGhost = game.Grid[index].CellContents;
      
      Assert.Equal(cellTypeAtPosBeforeGhost,cellTypeAtPosAfterGhost);
    }
    [Fact]
    public void MapInitializesInCorrectFormat()
    {
      var directionSetter = new SetDirectionGenerator();
      var game = new Game(LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/GameCore/LevelConfig/LevelMaps/level1.txt")), directionSetter);
      var consoleRenderer = new ConsoleRenderer();


      var expectedGrid =
        "######.##############.######\n"
        + "#............##............#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "............................\n"
        + "#.####.#####    #####.####.#\n"
        + "#.#  #.##    M     ##.#  #.#\n"
        + "#.####.##############.####.#\n"
        + ".............V..............\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.#  #.#   #.##.#   #.#  #.#\n"
        + "#.####.#####.##.#####.####.#\n"
        + "#............##............#\n"
        + "######.##############.######\n";
      var actualGrid = consoleRenderer.GetStateOfMapAsString(game);

      Assert.Equal(expectedGrid, actualGrid);
    }
  
}
}
