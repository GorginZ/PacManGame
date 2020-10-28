namespace PacManGame
{
  public class PacMan
  {
    public RowColumn CurrentPosition;

    public Direction Heading;

    public bool MouthOpen = true;

    public PacMan(int row, int column)
    {
      CurrentPosition = new RowColumn(row, column);
    }

    public void UpdateCurrentPosition(int rowCount, int columnCount)
    {
      CurrentPosition = CurrentPosition.GetNeighbour(Heading, rowCount, columnCount);
    }
  }
}