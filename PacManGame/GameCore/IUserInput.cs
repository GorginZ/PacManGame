namespace PacManGame
{
  public interface IUserInput
  {

    Direction ParseInputToDirection();

    bool ContinuePlay
    {
      get;
      set;
    }

    void SetContinuePlay();

    void SetInputKey();
  }
}