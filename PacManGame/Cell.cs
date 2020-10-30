using System;

namespace PacManGame
{
  public class Cell
  {
    public CellType CellContents;
    public Cell(CellType cellType)
    {
      CellContents = cellType;
    }


    public String CellAsString(string pacManSymbol)
    {
      if (CellContents.Equals(CellType.Dot))
      {
        return ".";
      }
      if (CellContents.Equals(CellType.Pacman))
      {
        
        return pacManSymbol;
      }
      if (CellContents.Equals(CellType.Ghost))
      {
        return "M";
      }
      if (CellContents.Equals(CellType.Wall))
      {
        return "#";
      }
      if (CellContents.Equals(CellType.Empty))
      {
        return " ";
      }
      return CellContents.ToString();
    }

   
  }
}