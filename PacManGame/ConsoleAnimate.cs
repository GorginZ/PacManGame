using System;
using System.Threading;

namespace PacManGame
{
  public class ConsoleAnimate
  {
    static string[,] sequence = null;

    public int Delay { get; set; } = 200;

    int totalSequences = 0;
    int counter;

    public ConsoleAnimate()
    {
      counter = 0;
      sequence = new string[,] {
                //east
                { "<", "-", "<", "-" },
                //west
                { ">", "-", ">", "-" },
                //north
                { "V", "|", "V", "|" },
                //south
                { "^", "|", "^", "|" },
               // ADD YOUR OWN CREATIVE SEQUENCE HERE IF YOU LIKE
            };

      totalSequences = sequence.GetLength(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sequenceCode"> 0 | 1 | 2 |3 | 4 | 5 </param>
    public void Turn(string displayMsg = "", int sequenceCode = 0)
    {
      counter++;

      Thread.Sleep(Delay);

      sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;

      int counterValue = counter % 4;

      string fullMessage = displayMsg + sequence[sequenceCode, counterValue];
      int msglength = fullMessage.Length;

      // Console.Write(fullMessage);
//I want this to be pacman, maybe this wont work with curser position.
      Console.SetCursorPosition(Console.CursorLeft - msglength, Console.CursorTop);
    }
  }
}