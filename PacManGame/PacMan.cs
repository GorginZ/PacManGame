namespace PacManGame
{
  public class PacMan
  {
    public RowColumn CurrentPosition;

    public Direction Heading;

    public PacMan(int row, int column)
    {
      CurrentPosition = new RowColumn(row, column);
    }

    public void UpdateCurrentPosition()
    {
      if (Heading == Direction.North)
      {
        CurrentPosition.Row--;
      }

      if (Heading == Direction.East)
      {
        CurrentPosition.Column++;
      }

      if (Heading == Direction.South)
      {
        CurrentPosition.Row++;
      }

      if (Heading == Direction.West)
      {
        CurrentPosition.Column--;
      }


    }
  }
}