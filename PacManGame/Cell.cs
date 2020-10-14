using System;

namespace PacManGame
{
public class Cell
    {
        public CellType CellContents { get; }
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
            return CellContents.ToString();
        }
    }
}