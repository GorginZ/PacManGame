namespace PacManGame
{
  public class PacMan 
  {
    public RowColumn CurrentPosition {get;}

    public PacMan(int row, int column)
    {
      CurrentPosition = new RowColumn(row, column);
    }

 
  }
}