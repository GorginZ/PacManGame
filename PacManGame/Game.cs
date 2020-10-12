using System.Collections.Generic;

namespace PacManGame
{
  public class Game
  {
    private List<List<ICharacter>> _game = new List<List<ICharacter>>();

    public Game(int height, int width)
    {

      for (int row = 0; row < height; row++)
      {
        _game.Add(new List<ICharacter>());

        for (int column = 0; column < width; column++)
        {
          _game[row].Add(new Dot { CurrentPosition = new RowColumn(row, column) });

        }
      }
      _game[1][1] = new PacMan(1,1);
    }

    public List<List<ICharacter>> GetGrid() => _game;
  }
}