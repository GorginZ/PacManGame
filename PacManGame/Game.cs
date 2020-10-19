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


      var levelWalls = new List<RowColumn> { 
        //row 0
      new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2), new RowColumn(0, 3), new RowColumn(0, 4), new RowColumn(0, 5), new RowColumn(0, 6), new RowColumn(0, 7),
      new RowColumn(0, 8), new RowColumn(0, 9), new RowColumn(0, 10),new RowColumn(0, 11),new RowColumn(0, 12),new RowColumn(0, 13),new RowColumn(0, 14),new RowColumn(0, 15),new RowColumn(0, 16),new RowColumn(0, 17),new RowColumn(0, 18),new RowColumn(0, 19),new RowColumn(0, 20),new RowColumn(0, 21),new RowColumn(0, 22),new RowColumn(0, 23),new RowColumn(0, 24),new RowColumn(0, 25),new RowColumn(0, 26),new RowColumn(0, 27),new RowColumn(0, 27),
      //row 1
new RowColumn(1, 0),new RowColumn(1,13),new RowColumn(1, 14),new RowColumn(1, 27),
//row 2
new RowColumn(2,0),new RowColumn(2,2),new RowColumn(2,3),new RowColumn(2,4),new RowColumn(2,5),new RowColumn(2,7),new RowColumn(2,8),new RowColumn(2,9),new RowColumn(2,10),new RowColumn(2,11),new RowColumn(2,13),new RowColumn(2,14),new RowColumn(2,16),new RowColumn(2,17),new RowColumn(2,18),new RowColumn(2,19),new RowColumn(2,20),new RowColumn(2,22), new RowColumn(2,23),new RowColumn(2,24),new RowColumn(2,25),new RowColumn(2,27),
//row 3
new RowColumn(3,0),new RowColumn(3,2),new RowColumn(3,5),new RowColumn(3,7),new RowColumn(3,11),new RowColumn(3,13),new RowColumn(3,14),new RowColumn(3,16),new RowColumn(3,20), new RowColumn(3,22),new RowColumn(3,25),new RowColumn(3,27), 
//row 4
new RowColumn(4,0),new RowColumn(4,2),new RowColumn(4,3),new RowColumn(4,4),new RowColumn(4,5),new RowColumn(4,7),new RowColumn(4,11),new RowColumn(4,13),new RowColumn(4,14),new RowColumn(4,16),new RowColumn(4,20), new RowColumn(4,22),new RowColumn(4,25),new RowColumn(4,27), 

//row 5

//dots
// new RowColumn(5,0),new RowColumn(5,2),new RowColumn(5,3),new RowColumn(5,4),new RowColumn(5,5)
new RowColumn(5,0),new RowColumn(5,7),new RowColumn(5,8),new RowColumn(5,9),new RowColumn(5,10),new RowColumn(5,11),new RowColumn(5,16),new RowColumn(5,20),new RowColumn(5,22), new RowColumn(5,23),new RowColumn(5,24),new RowColumn(5,25),new RowColumn(5,27),

//row 6

   new RowColumn(6, 0), new RowColumn(6, 1), new RowColumn(6, 2), new RowColumn(6, 3), new RowColumn(6, 4), new RowColumn(6, 5), new RowColumn(6, 7),
      new RowColumn(6, 8), new RowColumn(6, 9), new RowColumn(6, 10),new RowColumn(6, 11),new RowColumn(6, 13),new RowColumn(6, 14),new RowColumn(6, 16),new RowColumn(6, 17),new RowColumn(6, 18),new RowColumn(6, 19),new RowColumn(6, 20),new RowColumn(6, 27),

// dots new RowColumn(6, 6),new RowColumn(6, 12),new RowColumn(6, 15),new RowColumn(6, 21),new RowColumn(6, 22),new RowColumn(6, 23),new RowColumn(6, 24),new RowColumn(6, 25),new RowColumn(6, 26)

//row 7
new RowColumn(7, 0),new RowColumn(7, 5),new RowColumn(7, 13),new RowColumn(7, 14), new RowColumn(7,22), new RowColumn(7,23),new RowColumn(7,24),new RowColumn(7,25),new RowColumn(7,27),
    //  0 5 13 14 22-25 27 wall 

    //row 8
    new RowColumn(8,0),new RowColumn(8,1),new RowColumn(8,2),new RowColumn(8,3),new RowColumn(8,4),new RowColumn(8,5),new RowColumn(8,7),new RowColumn(8,8),new RowColumn(8,9),new RowColumn(8,10),new RowColumn(8,11),new RowColumn(8,13),new RowColumn(8,14),new RowColumn(8,16),new RowColumn(8,17),new RowColumn(8,18),new RowColumn(8,19),new RowColumn(8,20),new RowColumn(8,22), new RowColumn(8,25),new RowColumn(8,27),

    //row 9
          // wall 7 11 13 14 16 20 22 25 
    new RowColumn(9,7),new RowColumn(9,11),new RowColumn(9,13),new RowColumn(9,14),new RowColumn(9,16),new RowColumn(9,20),new RowColumn(9,22),new RowColumn(9,25),

    //row 10

    new RowColumn(10,0),new RowColumn(10,1),new RowColumn(10,2),new RowColumn(10,3),new RowColumn(10,4),new RowColumn(10,5),new RowColumn(10,7),new RowColumn(10,11),new RowColumn(10,13),new RowColumn(10,14),new RowColumn(10,16),new RowColumn(10,17),new RowColumn(10,18),new RowColumn(10,19),new RowColumn(10,20),new RowColumn(10,22), new RowColumn(10,23),new RowColumn(10,24),new RowColumn(10,25),new RowColumn(10,27),

    //row 11

        new RowColumn(11,0),new RowColumn(11,5), new RowColumn(11,7),new RowColumn(11,8),new RowColumn(11,9),new RowColumn(11,10), new RowColumn(11,11),new RowColumn(11,13),new RowColumn(11,14),new RowColumn(11,16),new RowColumn(11,20),new RowColumn(11,22),new RowColumn(11,25),new RowColumn(11,27),

        //row 12

        new RowColumn(12,0), new RowColumn(12,1), new RowColumn(12,2),new RowColumn(12,3),new RowColumn(12,4),new RowColumn(12,5),new RowColumn(12,7),new RowColumn(12,8),new RowColumn(12,9),new RowColumn(12,10),new RowColumn(12,11),new RowColumn(12,13),new RowColumn(12,14),new RowColumn(12,16),new RowColumn(12,17),new RowColumn(12,18),new RowColumn(12,19),new RowColumn(12,20),new RowColumn(12,22), new RowColumn(12,23),new RowColumn(12,24),new RowColumn(12,25),new RowColumn(12,27),
//row 13
        new RowColumn(13, 0),new RowColumn(13,13),new RowColumn(13, 14),new RowColumn(13, 27),

        //row 14

         new RowColumn(14, 0), new RowColumn(14, 1), new RowColumn(14, 2), new RowColumn(14, 3), new RowColumn(14, 4), new RowColumn(14, 5), new RowColumn(14, 6), new RowColumn(14, 7),
      new RowColumn(14, 8), new RowColumn(14, 9), new RowColumn(14, 10),new RowColumn(14, 11),new RowColumn(14, 12),new RowColumn(14, 13),new RowColumn(14, 14),new RowColumn(14, 15),new RowColumn(14, 16),new RowColumn(14, 17),new RowColumn(14, 18),new RowColumn(14, 19),new RowColumn(14, 20),new RowColumn(14, 21),new RowColumn(14, 22),new RowColumn(14, 23),new RowColumn(14, 24),new RowColumn(14, 25),new RowColumn(14, 26),new RowColumn(14, 27),

    };
      //row3
      var levelGaps = new List<RowColumn>{ new RowColumn(3,3),new RowColumn(3,4),new RowColumn(3,8),new RowColumn(3,9),new RowColumn(3,10),new RowColumn(3,17),new RowColumn(3,18), new RowColumn(3,19),new RowColumn(3,23),new RowColumn(3,24),
    //row 4
    new RowColumn(4,8),new RowColumn(4,9),new RowColumn(4,10),new RowColumn(4,17),new RowColumn(4,18), new RowColumn(4,19),new RowColumn(4,23),new RowColumn(4,24),
    //row 5
    new RowColumn(5,17),new RowColumn(5,18),new RowColumn(5,19),
    //row 7  1234  
    new RowColumn(7,1),new RowColumn(7,2),new RowColumn(7,3),new RowColumn(7,4),

    //row 8
    new RowColumn(8,23),new RowColumn(8,24),

    //row 9
          // gap 8 9 10 17 18 19 23 24
      new RowColumn(9,8), new RowColumn(9,9),new RowColumn(9,10),new RowColumn(9,17),new RowColumn(9,18),new RowColumn(9,19),new RowColumn(9,23),new RowColumn(9,24),

      //row 10 
      new RowColumn(10,8),new RowColumn(10,9),new RowColumn(10,10),

      //row 11

           new RowColumn(11,1),new RowColumn(11,2),new RowColumn(11,3),   new RowColumn(11,4), new RowColumn(11,17),new RowColumn(11,18),new RowColumn(11,19),new RowColumn(11,23),   new RowColumn(11,24)
    };

      SetMany(levelWalls, CellType.Wall);
      SetMany(levelGaps, CellType.Empty);
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