namespace PacManGame
{
  public interface IUserInput
  {
    CurrentCommand Command { get; set; }
    Direction ParseInputToDirection();





    void SetCurrentCommand();
  }
}