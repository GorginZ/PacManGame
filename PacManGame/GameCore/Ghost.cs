namespace PacManGame
{
  public class Ghost
  {
    public RowColumn CurrentPosition;

    public Direction Heading;

    public Ghost(int row, int column)
    {
      CurrentPosition = new RowColumn(row, column);
    }

    public void UpdateCurrentPosition(int rowCount, int columnCount)
    {
      CurrentPosition = CurrentPosition.GetNeighbour(Heading, rowCount, columnCount);
    }
  }
}
