using System;
using System.Text;

namespace PacManGame
{
  public class ConsoleRenderer : IOutput
  {
    
    public void Write(string myString) => Console.WriteLine(myString);


  public String GetStateOfMapAsString(Game game) 
    {
      var printableGrid = new StringBuilder();

      for (int i = 0; i < game.Grid.RowCount; i++)
      {
        for (int j = 0; j < game.Grid.ColumnCount; j++)
        {
          var coordinate = new RowColumn(i, j);

          printableGrid.Append(game.Grid[coordinate].CellAsString(GetPacManSymbol(game.PacManCharacter.Heading, game.PacManCharacter.MouthOpen)));
        }
        printableGrid.Append("\n");
      }

      return printableGrid.ToString();
    }


    public string GetPacManSymbol(Direction pacManHeading, bool pacManMouthOpen) 
    {
      switch (pacManHeading)
      {
        case Direction.North:
          var northSymbol = pacManMouthOpen ? ("V") : ("|");
          return northSymbol;

        case Direction.East:
          var eastSymbol = pacManMouthOpen ? ("<") : ("-");
          return eastSymbol;

        case Direction.South:
          var southSymbol = pacManMouthOpen ? ("^") : ("|");
          return southSymbol;

        case Direction.West:
          var westSymbol = pacManMouthOpen ? (">") : ("-");
          return westSymbol;

        default:
          throw new System.ArgumentOutOfRangeException(nameof(pacManHeading));
      }

      
    }

  }
}