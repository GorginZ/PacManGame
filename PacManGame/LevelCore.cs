using System.Collections.Generic;

namespace PacManGame
{
  public class LevelCore
  {
    public int RowCount = 15;
    public int ColumnCount = 28;
    public List<RowColumn> LevelWalls;
    public List<RowColumn> LevelGaps;
    public List<RowColumn> LevelDots;
    public List<RowColumn> LevelPacMan;
    public List<RowColumn> LevelGhosts;

    public static LevelCore Parse(string level)
    {
      var walls = new List<RowColumn>();
      var gaps = new List<RowColumn>();
      var dots = new List<RowColumn>();
      var pacMan = new List<RowColumn>();
      var ghosts = new List<RowColumn>();

      var rows = level.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
      for (var row = 0; row < rows.Length; row++)
      {
        for (var col = 0; col < rows[row].Length; col++)
        {
          var c = rows[row][col];
          if (c == '#')
          {
            walls.Add(new RowColumn(row, col));
          }
          if (c == '.')
          {
            dots.Add(new RowColumn(row, col));
          }
           if (c == 'P')
          {
            pacMan.Add(new RowColumn(row, col));
          }
          if (c == 'M')
          {
            ghosts.Add(new RowColumn(row, col));
          }
          else if (c == ' ')
          {
            gaps.Add(new RowColumn(row, col));
          }
        }
      }

      return new LevelCore
      {
        RowCount = rows.Length,
        ColumnCount = rows[0].Length,
        LevelWalls = walls,
        LevelGaps = gaps,
        LevelDots = dots,
        LevelPacMan = pacMan,
        LevelGhosts = ghosts
      };
    }

  }
}