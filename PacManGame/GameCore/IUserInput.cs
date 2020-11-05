namespace PacManGame
{
  public interface IUserInput
  {
    
    Direction ParseInputToDirection();

    void ReadInputDirection();
  }
}