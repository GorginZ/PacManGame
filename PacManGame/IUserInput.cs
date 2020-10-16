namespace PacManGame
{
    public interface IUserInput
    {
          Direction ParseInputToDirection();

          string ReadInput();
    }
}