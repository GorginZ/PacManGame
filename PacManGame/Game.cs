using System;
using System.Collections.Generic;
using System.Text;

namespace PacManGame
{
  public class Game
  {
    private List<List<Cell>> _cells = new List<List<Cell>>();
    public PacMan PacManCharacter = new PacMan(1, 1);
    public LevelCore Level = new LevelCore();

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
      _cells[1][1] = new Cell(CellType.Pacman);

      SetMany(Level.LevelWalls, CellType.Wall);
      SetMany(Level.LevelGaps, CellType.Empty);
    }
    public List<List<Cell>> GetGrid() => _cells;


    public void SetMany(List<RowColumn> coordinatesToSet, CellType value)
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

    public RowColumn FindPacman()
    {
      for (int row = 0; row < _cells.Count; row++)
      {
        for (int col = 0; col < _cells[0].Count; col++)
        {
          if (IsPacMan(_cells[row][col]))
          {
            return new RowColumn(row, col);
          }
        }
      }
      throw new System.Exception("There is no PacMan!!!!!");
    }

    public void SetPacManHeading(Direction heading)
    {
      if (IsValidMove(ParseDirectionToPotentialMove(heading)))
      {
        PacManCharacter.Heading = heading;
      }

    }

    public bool IsValidMove(RowColumn potentialMove)
    {
      if (_cells[potentialMove.Row][potentialMove.Column].CellContents.Equals(CellType.Wall))
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public RowColumn ParseDirectionToPotentialMove(Direction heading)
    {
      var potentialMove = new RowColumn(PacManCharacter.CurrentPosition.Row, PacManCharacter.CurrentPosition.Column);

      if (heading == Direction.North)
      {
        potentialMove.Row--;
      }

      if (heading == Direction.East)
      {
        potentialMove.Column++;
      }

      if (heading == Direction.South)
      {
        potentialMove.Row++;
      }

      if (heading == Direction.West)
      {
        potentialMove.Column--;
      }
      return potentialMove;
    }



    public void Tick()
    {
      var potentialMove = ParseDirectionToPotentialMove(PacManCharacter.Heading);
      if (IsValidMove(potentialMove))
      {
        PacManCharacter.UpdateCurrentPosition();

        _cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents = CellType.Pacman;
      }



    }
  }
}