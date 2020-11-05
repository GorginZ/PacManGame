using System.Collections;
using System.Collections.Generic;

namespace PacManGame
{
  public class Grid : IEnumerable<Cell>
  {
    private List<List<Cell>> _cellGrid = new List<List<Cell>>();

    public Grid(int rowDimension, int columnDimension)
    {
      InitializeGrid(rowDimension, columnDimension);
    }
    private void InitializeGrid(int rowDimension, int columnDimension)
    {
      for (int row = 0; row < rowDimension; row++)
      {
        _cellGrid.Add(new List<Cell>());

        for (int column = 0; column < columnDimension; column++)
        {
          _cellGrid[row].Add(new Cell(CellType.Empty));
        }
      }
    }

      public void SetMany(IEnumerable<RowColumn> coordinatesToSet, CellType value)
    {
      foreach (RowColumn coordinate in coordinatesToSet)
      {
        if (coordinate.Row < RowCount && coordinate.Column < ColumnCount)
        {
          this[coordinate].CellContents = value;
        }
      }
    }

    public int RowCount => _cellGrid.Count;
    public int ColumnCount => _cellGrid[0].Count;

    public Cell this[RowColumn coordinates]
    {
      get => _cellGrid[coordinates.Row][coordinates.Column];
      set => _cellGrid[coordinates.Row][coordinates.Column] = value;
    }

    public IEnumerator<Cell> GetEnumerator()
    {
      for (int i = 0; i < RowCount; i++)
      {
        for (int j = 0; j < ColumnCount; j++)
        { 
            yield return _cellGrid[i][j];
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}