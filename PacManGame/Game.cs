using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PacManGame
{
  public class Game
  {
    public int CurrentLevel = 1;
    public static LevelCore Level;

    private Grid _grid;
    public PacMan PacManCharacter;

    public List<Ghost> Ghosts;

    private HashSet<RowColumn> _emptySpace = new HashSet<RowColumn>();
    private HashSet<RowColumn> _remainingDots = new HashSet<RowColumn>();


    public int DotsEatenThisLevel = 0;
    public int Score = 0;

    public Game(LevelCore level)
    {
      Level = level;
      PacManCharacter = new PacMan(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);
      _grid = new Grid(Level.RowCount, Level.ColumnCount);

      InitializeMapWithLevelData();
    }

    private string GetLevelPathName()
    {
      string path = $"/Users/georgia.leng/Desktop/C#/PacManGame/PacManGame/LevelMaps/level{CurrentLevel}.txt";
      return path;
    }

    private void InitializeMapWithLevelData() // kinda console only
    {
      PacManCharacter.CurrentPosition = new RowColumn(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);

      Ghosts = new List<Ghost>();
      Level.LevelGhosts.ForEach(x => Ghosts.Add(new Ghost(x.Row, x.Column)));

      _emptySpace = new HashSet<RowColumn>();
      _emptySpace.UnionWith(Level.LevelGaps);

      _remainingDots = new HashSet<RowColumn>();
      _remainingDots.UnionWith(Level.LevelDots);

      _grid.SetMany(Level.LevelWalls, CellType.Wall);
      _grid.SetMany(Level.LevelGaps, CellType.Empty);
      _grid.SetMany(Level.LevelPacMan, CellType.Pacman);
      _grid.SetMany(Level.LevelGhosts, CellType.Ghost);
      _grid.SetMany(Level.LevelDots, CellType.Dot);

    }

    public String GetStateOfMapAsString() //console only
    {
      var printableGrid = new StringBuilder();

      for (int i = 0; i < _grid.RowCount; i++)
      {
        for (int j = 0; j < _grid.ColumnCount; j++)
        {
          var coordinate = new RowColumn(i, j);

          printableGrid.Append(_grid[coordinate].PrintableCell(GetPacManSymbol()));
        }
        printableGrid.Append("\n");
      }

      return printableGrid.ToString();
    }
    public bool IsPacMan(Cell valueAtIndex)
    {
      if (valueAtIndex.CellContents.Equals(CellType.Pacman))
      {
        return true;

      }
      return false;
    }

    public void SetPacManHeading(Direction heading)
    {
      if (IsValidMove(PacManCharacter.CurrentPosition.GetNeighbour(heading, Level.RowCount, Level.ColumnCount)))
      {
        PacManCharacter.Heading = heading;
      }

    }

    public void SetGhostHeading(Ghost ghost)
    {
      if (!IsValidMove(ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount)))
      {
        var rng = new Random();
        ghost.Heading = (Direction)rng.Next((int)Direction.North, (int)Direction.West + 1);
      }

    }

    public bool IsValidMove(RowColumn potentialMove)
    {
      return _grid[potentialMove].CellContents != CellType.Wall;
    }



    public void MoveGhost(Ghost ghost)
    {
      var ghostsOldPosition = ghost.CurrentPosition;

      var potentialPosition = ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(potentialPosition))
      {
        ghost.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        var cellTypeToLeaveBehind = _emptySpace.Contains(ghostsOldPosition) ? (CellType.Empty) : (CellType.Dot);

        _grid[ghostsOldPosition].CellContents = cellTypeToLeaveBehind;

        _grid[ghost.CurrentPosition].CellContents = CellType.Ghost;
      }
    }

    public void MovePacMan()
    {
      var pacManPotentialMove = PacManCharacter.CurrentPosition.GetNeighbour(PacManCharacter.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(pacManPotentialMove))
      {
        OscillatePacManMouthState();


        _grid[PacManCharacter.CurrentPosition].CellContents = CellType.Empty;

        PacManCharacter.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        if (!_emptySpace.Contains(PacManCharacter.CurrentPosition))
        {
          ApplyEatDotRules();
        }

        _grid[PacManCharacter.CurrentPosition].CellContents = CellType.Pacman;
      }
    }

    public void ApplyEatDotRules()
    {
      DotsEatenThisLevel++;
      Score++;
      _emptySpace.Add(PacManCharacter.CurrentPosition);
      _remainingDots.Remove(PacManCharacter.CurrentPosition);

    }

    public void LevelUp() //console only
    {
      CurrentLevel++;
      _grid = new Grid(Level.RowCount, Level.ColumnCount);
      string levelPath = GetLevelPathName();
      Level = LevelCore.Parse(System.IO.File.ReadAllText(levelPath));
      InitializeMapWithLevelData();
      PacManCharacter.HasDied = false;
      Score += DotsEatenThisLevel;
      DotsEatenThisLevel = 0;
    }

    public void OscillatePacManMouthState() // console only
    {
      if (PacManCharacter.MouthOpen)
      {
        PacManCharacter.MouthOpen = false;
      }
      else if (!PacManCharacter.MouthOpen)
      {
        PacManCharacter.MouthOpen = true;
      }
    }

    public string GetPacManSymbol() //console only
    {
      switch (PacManCharacter.Heading)
      {
        case Direction.North:
          var northSymbol = PacManCharacter.MouthOpen ? ("V") : ("|");
          return northSymbol;

        case Direction.East:
          var eastSymbol = PacManCharacter.MouthOpen ? ("<") : ("-");
          return eastSymbol;

        case Direction.South:
          var southSymbol = PacManCharacter.MouthOpen ? ("^") : ("|");
          return southSymbol;

        case Direction.West:
          var westSymbol = PacManCharacter.MouthOpen ? (">") : ("-");
          return westSymbol;

        default:
          throw new System.ArgumentOutOfRangeException(nameof(PacManCharacter.Heading));
      }
    }

    public bool GhostCollideWithPacman()
    {
      return Ghosts.Any(x => x.CurrentPosition.Equals(PacManCharacter.CurrentPosition));
    }

    public void UpdateGhosts()
    {
      foreach (Ghost ghost in Ghosts)
      {
        SetGhostHeading(ghost);
        MoveGhost(ghost);
      }
    }

    public void PacManDieAndReStartLevelSequence()
    {
      _grid = new Grid(Level.RowCount, Level.ColumnCount);
      InitializeMapWithLevelData();
      PacManCharacter.Lives--;
      PacManCharacter.HasDied = false;
      DotsEatenThisLevel = 0;
    }

    public void Tick()
    {
      UpdateGhosts();
      MovePacMan();

      if (GhostCollideWithPacman())
      {
        PacManDieAndReStartLevelSequence();
      }
      if (_remainingDots.Count == 0)
      {
        LevelUp();
      }

    }
  }
}