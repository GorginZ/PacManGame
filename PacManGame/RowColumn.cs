using System;
using System.Collections.Generic;

namespace PacManGame
{
  public struct RowColumn : IEquatable<RowColumn>
  {
    public int Row;
    public int Column;

    public RowColumn(int row, int column)
    {
      Row = row;
      Column = column;
    }

    public RowColumn GetNeighbour(Direction heading, int rowCount, int colCount)
    {
      switch (heading)
      {
        case Direction.North:
          var northRow = this.Row == 0 ? (rowCount - 1) : (Row - 1);
          return new RowColumn(northRow, this.Column);

        case Direction.East:
          var eastColumn = this.Column == (colCount - 1) ? (0) : (Column + 1);
          return new RowColumn(this.Row, eastColumn);

        case Direction.South:
          var southRow = this.Row == (rowCount - 1) ? (0) : (Row + 1);
          return new RowColumn(southRow, this.Column);

        case Direction.West:
          var westColumn = this.Column == 0 ? (colCount - 1) : (Column - 1);
          return new RowColumn(this.Row, westColumn);

        default:
          throw new System.ArgumentOutOfRangeException(nameof(heading));
      }
    }

    public bool Equals(RowColumn other) =>
      Row == other.Row && Column == other.Column;

    public override int GetHashCode() =>
      HashCode.Combine(Row, Column);
  }
}