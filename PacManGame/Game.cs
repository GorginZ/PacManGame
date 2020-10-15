using System.Collections.Generic;

namespace PacManGame
{
  public class Game
  {
    private List<List<Cell>> _cells = new List<List<Cell>>();
    public PacMan PacManCharacter = new PacMan(1, 1);



    public Game(int height, int width)
    {

      for (int row = 0; row < height; row++)
      {
        _cells.Add(new List<Cell>());

        for (int column = 0; column < width; column++)
        {
          _cells[row].Add(new Cell(CellType.Dot));

        }
      }
      _cells[1][1] = new Cell(CellType.Pacman);
    }

    public List<List<Cell>> GetGrid() => _cells;


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




    public void Tick()
    {
      PacManCharacter.UpdateCurrentPosition();

      _cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents = CellType.Pacman;
    }
  }
}