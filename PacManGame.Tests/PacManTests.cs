using Xunit;

namespace PacManGame.Tests
{
  public class PacManTests
  {
    [Fact]
    public void PacMansCurrentPositionCanBeUpdatedToReflectHeading()
    {
      int rowCount = 15;
      int columnCount =28;
      var pac = new PacMan(1, 1);

      pac.Heading = Direction.East;
      pac.UpdateCurrentPosition(rowCount, columnCount);

      Assert.Equal(2, pac.CurrentPosition.Column);

      pac.Heading = Direction.North;
      pac.UpdateCurrentPosition(rowCount, columnCount);

      Assert.Equal(0, pac.CurrentPosition.Row);

      pac.Heading = Direction.South;
      pac.UpdateCurrentPosition(rowCount, columnCount);

      Assert.Equal(1, pac.CurrentPosition.Row);

      pac.Heading = Direction.West;
      pac.UpdateCurrentPosition(rowCount, columnCount);

      Assert.Equal(1, pac.CurrentPosition.Column);

    }
  }
}