namespace PacManGame
{
  public class PacMan
  {
    public RowColumn CurrentPosition;

    public Direction Heading;

    public int Lives = 3;
    public bool HasDied = false;

    public bool MouthOpen = true;

    public PacMan(int row, int column)
    {
      CurrentPosition = new RowColumn(row, column);
    }

    public void UpdateCurrentPosition(int gridRowDimension, int gridColumnDimension)
    {
      CurrentPosition = CurrentPosition.GetNeighbour(Heading, gridRowDimension, gridColumnDimension);
    }
  }
}
