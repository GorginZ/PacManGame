using System;
using System.Collections.Generic;
using System.Text;

namespace PacManGame
{
  public class Game
  {
    public static LevelCore Level = LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/levelOne.txt"));

    private Grid _grid;

    public PacMan PacManCharacter = new PacMan(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);

    public Ghost YellowGhost = new Ghost(Level.LevelGhosts[0].Row, Level.LevelGhosts[0].Column);
    public Ghost BlueGhost = new Ghost(Level.LevelGhosts[1].Row, Level.LevelGhosts[1].Column);
    public Ghost RedGhost = new Ghost(Level.LevelGhosts[2].Row, Level.LevelGhosts[2].Column);

    private HashSet<RowColumn> _emptySpace = new HashSet<RowColumn>();

    public int DotsEatenThisLevel = 0;

    public int Lives = 3;

    public bool HasDied = false;

    public Game()
    {
      _grid = new Grid(Level.RowCount, Level.ColumnCount);
      InitializeMap();
    }

    private void InitializeMap()
    {
      PacManCharacter.CurrentPosition = new RowColumn(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);
      YellowGhost.CurrentPosition = new RowColumn(Level.LevelGhosts[0].Row, Level.LevelGhosts[0].Column);
      BlueGhost.CurrentPosition = new RowColumn(Level.LevelGhosts[1].Row, Level.LevelGhosts[1].Column);
      RedGhost.CurrentPosition = new RowColumn(Level.LevelGhosts[2].Row, Level.LevelGhosts[2].Column);

      _emptySpace = new HashSet<RowColumn>();

      _grid.SetMany(Level.LevelWalls, CellType.Wall);
      _grid.SetMany(Level.LevelGaps, CellType.Empty);
      _grid.SetMany(Level.LevelPacMan, CellType.Pacman);
      _grid.SetMany(Level.LevelGhosts, CellType.Ghost);
    }

    public String PrintableGrid()
    {
      var printableGrid = new StringBuilder();

      for (int i = 0; i < _grid.RowCount; i++)
      {
        for (int j = 0; j < _grid.ColumnCount; j++)
        {
          var coordinate = new RowColumn(i, j);

          printableGrid.Append(_grid[coordinate].ToString());
        }
        printableGrid.Append("\n");
      }

      return printableGrid.ToString();
    }


    public bool IsPacMan(Cell valueAtIndex)
    {
      if (valueAtIndex.CellContents.Equals(CellType.Pacman))
      {
        return true;

      }
      return false;
    }

    public void SetPacManHeading(Direction heading)
    {
      if (IsValidMove(PacManCharacter.CurrentPosition.GetNeighbour(heading, Level.RowCount, Level.ColumnCount)))
      {
        PacManCharacter.Heading = heading;
      }

    }

    public void SetGhostHeading(Ghost ghost)
    {
      if (!IsValidMove(ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount)))
      {
        var rng = new Random();
        ghost.Heading = (Direction)rng.Next((int)Direction.North, (int)Direction.West + 1);
      }

    }

    public bool IsValidMove(RowColumn potentialMove)
    {
      return _grid[potentialMove].CellContents != CellType.Wall;
    }

    public bool GhostCollideWithPacman(RowColumn ghostMove, RowColumn pacmanMove)
    {
      return ghostMove.Equals(pacmanMove);
    }

    public void MoveGhost(Ghost ghost)
    {
      var ghostsOldPosition = ghost.CurrentPosition;

      var potentialPosition = ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(potentialPosition))
      {

        ghost.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        if (GhostCollideWithPacman(ghost.CurrentPosition, PacManCharacter.CurrentPosition))
        {
          HasDied = true;
        }

        var cellTypeToLeaveBehind = _emptySpace.Contains(ghostsOldPosition) ? (CellType.Empty) : (CellType.Dot);

        _grid[ghostsOldPosition].CellContents = cellTypeToLeaveBehind;

        _grid[ghost.CurrentPosition].CellContents = CellType.Ghost;
      }
    }

    public void MovePacMan()
    {
      var pacManPotentialMove = PacManCharacter.CurrentPosition.GetNeighbour(PacManCharacter.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(pacManPotentialMove))
      {
        //re-thinking this line -cop out
        _grid[PacManCharacter.CurrentPosition].CellContents = CellType.Empty;

        PacManCharacter.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        if (!_emptySpace.Contains(PacManCharacter.CurrentPosition))
        {
          DotsEatenThisLevel++;

          _emptySpace.Add(PacManCharacter.CurrentPosition);
        }

        _grid[PacManCharacter.CurrentPosition].CellContents = CellType.Pacman;
      }
    }


    public void Tick()
    {
      SetGhostHeading(YellowGhost);
      SetGhostHeading(BlueGhost);
      SetGhostHeading(RedGhost);
      MoveGhost(YellowGhost);
      MoveGhost(BlueGhost);
      MoveGhost(RedGhost);
      MovePacMan();

      if (HasDied)
      {
        _grid = new Grid(Level.RowCount, Level.ColumnCount);
        InitializeMap();
        Lives--;
        HasDied = false;
        DotsEatenThisLevel = 0;
      }

    }
  }
}