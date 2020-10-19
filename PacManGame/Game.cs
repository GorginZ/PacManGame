using System;
using System.Collections.Generic;
using System.Text;

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

      //  var string =  "############################\n"
      //              + "#P...........##............#\n"

      //              + "#.####.#####.##.#####.####.#\n"

      //              + "#.#  #.#   #.##.#   #.#  #.#\n"
      //              + "#.####.#   #.##.#   #.#  #.#\n"
      //              + "#......#####....#   #.####.#\n"
      //              + "######.#####.##.#####......#\n"
      //              + "#    #.......##.......####.#\n"
      //              + "######.#####.##.#####.#  #.#\n"
      //              + ".......#   #.##.#   #.#  #. \n"
      //              + "######.#   #.##.#####.####.#\n"
      //              + "#    #.#####.##.#   #.#  #.#\n"
      //              + "######.#####.##.#####.####.#\n"
      //              + "#............##............#\n"
      //              + "############################\n";

      var Walls = new List<RowColumn> { //row 0
      new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2), new RowColumn(0, 3), new RowColumn(0, 4), new RowColumn(0, 5), new RowColumn(0, 6), new RowColumn(0, 7),
      new RowColumn(0, 8), new RowColumn(0, 9), new RowColumn(0, 10),new RowColumn(0, 11),new RowColumn(0, 12),new RowColumn(0, 13),new RowColumn(0, 14),new RowColumn(0, 15),new RowColumn(0, 16),new RowColumn(0, 17),new RowColumn(0, 18),new RowColumn(0, 19),new RowColumn(0, 20),new RowColumn(0, 21),new RowColumn(0, 22),new RowColumn(0, 23),new RowColumn(0, 24),new RowColumn(0, 25),new RowColumn(0, 26),new RowColumn(0, 27),new RowColumn(0, 28),
      //row 1
new RowColumn(1, 0),new RowColumn(1,13),new RowColumn(1,14),new RowColumn(1,28),
//row 2
new RowColumn(2,0),new RowColumn(2,2),new RowColumn(2,3),new RowColumn(2,4),new RowColumn(2,5),new RowColumn(2,7),new RowColumn(2,8),new RowColumn(2,9),new RowColumn(2,10),new RowColumn(2,11),new RowColumn(2,13),new RowColumn(2,14),new RowColumn(2,16),new RowColumn(2,17),new RowColumn(2,18),new RowColumn(2,19),new RowColumn(2,20),new RowColumn(2,22), new RowColumn(2,23),new RowColumn(2,24),new RowColumn(2,25),new RowColumn(2,27)



    };
      SetMany(Walls, CellType.Wall);
    }

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

    public void SetPacManHeading(Direction heading)
    {
      PacManCharacter.Heading = heading;
    }



    public void Tick()
    {
      PacManCharacter.UpdateCurrentPosition();

      _cells[PacManCharacter.CurrentPosition.Row][PacManCharacter.CurrentPosition.Column].CellContents = CellType.Pacman;
    }
  }
}