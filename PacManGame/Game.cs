using System;
using System.Collections.Generic;
using System.Text;

namespace PacManGame
{
  public class Game
  {
    public static LevelCore Level = LevelCore.Parse(System.IO.File.ReadAllText(@"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/levelOne.txt"));

    private List<List<Cell>> _cells = new List<List<Cell>>();

    public PacMan PacManCharacter = new PacMan(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);

    public Ghost YellowGhost = new Ghost(13, 26);
    public Ghost BlueGhost = new Ghost(13, 25);
    public Ghost RedGhost = new Ghost(13, 24);



    public int DotsEatenThisLevel = 0;

    public int Lives = 3;

    public Game()
    {
      for (int row = 0; row < Level.RowCount; row++)
      {
        _cells.Add(new List<Cell>());

        for (int column = 0; column < Level.ColumnCount; column++)
        {
          _cells[row].Add(new Cell(CellType.Dot));

        }
      }

      SetMany(Level.LevelWalls, CellType.Wall);
      SetMany(Level.LevelGaps, CellType.Empty);
      SetMany(Level.LevelPacMan, CellType.Pacman);
      SetMany(Level.LevelGhosts, CellType.Ghost);
    }

    private void SetMany(List<RowColumn> coordinatesToSet, CellType value)
    {
      foreach (RowColumn coordinate in coordinatesToSet)
      {
        if (coordinate.Row < _cells.Count && coordinate.Column < _cells[0].Count)
        {
          _cells[coordinate.Row][coordinate.Column].CellContents = value;
        }
      }
    }


    public String PrintableGrid()
    {
      var printableGrid = new StringBuilder();

      for (int i = 0; i < _cells.Count; i++)
      {
        for (int j = 0; j < _cells[0].Count; j++)
        {

          printableGrid.Append(_cells[i][j].ToString());
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



    //  while (IsValidMove(ghost.CurrentPosition.GetNeighbour(direction, Level.RowCount, Level.ColumnCount)))
    //       {
    //         ghost.Heading = direction;
    //       }

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
      return _cells[potentialMove.Row][potentialMove.Column].CellContents != CellType.Wall;
    }

    public void MoveYellowGhost()
    {
      var YellowGhostPotentialMove = YellowGhost.CurrentPosition.GetNeighbour(YellowGhost.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(YellowGhostPotentialMove))
      {
        var previousCellStateToPreserve = _cells[YellowGhostPotentialMove.Row][YellowGhostPotentialMove.Column].CellContents;

        _cells[YellowGhost.CurrentPosition.Row][YellowGhost.CurrentPosition.Column].CellContents = previousCellStateToPreserve;

        YellowGhost.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        _cells[YellowGhost.CurrentPosition.Row][YellowGhost.CurrentPosition.Column].CellContents = CellType.Ghost;
      }
    }

    public void MovePacMan()
    {
      var pacManPotentialMove = PacManCharacter.CurrentPosition.GetNeighbour(PacManCharacter.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(pacManPotentialMove))
      {
        _cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents = CellType.Empty;

        PacManCharacter.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        if (_cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents.Equals(CellType.Dot))
        {
          DotsEatenThisLevel++;
        }

        _cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents = CellType.Pacman;
      }
    }


    public void Tick()
    {
      SetGhostHeading(YellowGhost);
      MoveYellowGhost();
      MovePacMan();
    }
  }
}