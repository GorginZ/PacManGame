namespace PacManGame
{
  public class Dot : ICharacter
  {
      public RowColumn CurrentPosition;

    RowColumn ICharacter.CurrentPosition => throw new System.NotImplementedException();
  }
}