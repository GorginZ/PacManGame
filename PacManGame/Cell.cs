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
        public override String ToString()
        {
            if (CellContents.Equals(CellType.Dot))
            {
                return ".";
            }
            if (CellContents.Equals(CellType.Pacman))
            {
                return "P";
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