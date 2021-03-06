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
    private IGhostDirectionGenerator _directionGenerator;
    public Grid Grid { get; private set;}
    public PacMan PacManCharacter;

    public List<Ghost> Ghosts;

    private HashSet<RowColumn> _emptySpace = new HashSet<RowColumn>();
    private HashSet<RowColumn> _remainingDots = new HashSet<RowColumn>();

    public int DotsEatenThisLevel = 0;
    public int Score = 0;

    public Game(LevelCore level, IGhostDirectionGenerator directionGenerator)
    {
      Level = level;
      PacManCharacter = new PacMan(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);
      Grid = new Grid(Level.RowCount, Level.ColumnCount);
      _directionGenerator = directionGenerator;
      InitializeMapWithLevelData();
    }

    private string GetLevelPathName()
    {
      return $"./GameCore/LevelConfig/LevelMaps/level{CurrentLevel}.txt";
    }

    private void InitializeMapWithLevelData()
    {
      PacManCharacter.CurrentPosition = new RowColumn(Level.LevelPacMan[0].Row, Level.LevelPacMan[0].Column);

      Ghosts = new List<Ghost>();
      Level.LevelGhosts.ForEach(x => Ghosts.Add(new Ghost(x.Row, x.Column)));

      _emptySpace = new HashSet<RowColumn>();
      _emptySpace.UnionWith(Level.LevelGaps);

      _remainingDots = new HashSet<RowColumn>();
      _remainingDots.UnionWith(Level.LevelDots);

      Grid.SetMany(Level.LevelWalls, CellType.Wall);
      Grid.SetMany(Level.LevelPacMan, CellType.Pacman);
      Grid.SetMany(Level.LevelGhosts, CellType.Ghost);
      Grid.SetMany(Level.LevelDots, CellType.Dot);

    }

    public void SetPacManHeading(Direction heading)
    {
      if (IsValidMove(PacManCharacter.CurrentPosition.GetNeighbour(heading, Level.RowCount, Level.ColumnCount)))
      {
        PacManCharacter.Heading = heading;
      }

    }

    private void SetGhostHeading(Ghost ghost)
    {
      if (!IsValidMove(ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount)))
      {
        ghost.Heading = _directionGenerator.SetDirection();
      }

    }

    private bool IsValidMove(RowColumn potentialMove)
    {
      return Grid[potentialMove].CellContents != CellType.Wall;
    }

    private void MoveGhost(Ghost ghost)
    {
      var ghostsOldPosition = ghost.CurrentPosition;

      var potentialPosition = ghost.CurrentPosition.GetNeighbour(ghost.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(potentialPosition))
      {
        ghost.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        var cellTypeToLeaveBehind = _emptySpace.Contains(ghostsOldPosition) ? (CellType.Empty) : (CellType.Dot);

        Grid[ghostsOldPosition].CellContents = cellTypeToLeaveBehind;

        Grid[ghost.CurrentPosition].CellContents = CellType.Ghost;
      }
    }

    private void MovePacMan()
    {
      var pacManPotentialMove = PacManCharacter.CurrentPosition.GetNeighbour(PacManCharacter.Heading, Level.RowCount, Level.ColumnCount);

      if (IsValidMove(pacManPotentialMove))
      {
        OscillatePacManMouthState();


        Grid[PacManCharacter.CurrentPosition].CellContents = CellType.Empty;

        PacManCharacter.UpdateCurrentPosition(Level.RowCount, Level.ColumnCount);

        if (!_emptySpace.Contains(PacManCharacter.CurrentPosition))
        {
          ApplyEatDotRules();
        }

        Grid[PacManCharacter.CurrentPosition].CellContents = CellType.Pacman;
      }
    }

    private void ApplyEatDotRules()
    {
      DotsEatenThisLevel++;
      Score++;
      _emptySpace.Add(PacManCharacter.CurrentPosition);
      _remainingDots.Remove(PacManCharacter.CurrentPosition);

    }

    private void LevelUp()
    {
      CurrentLevel++;
      Grid = new Grid(Level.RowCount, Level.ColumnCount);
      string levelPath = GetLevelPathName();
      Level = LevelCore.Parse(System.IO.File.ReadAllText(levelPath));
      InitializeMapWithLevelData();
      PacManCharacter.HasDied = false;
      DotsEatenThisLevel = 0;
    }

    private void OscillatePacManMouthState()
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

    private bool GhostCollideWithPacman()
    {
      return Ghosts.Any(x => x.CurrentPosition.Equals(PacManCharacter.CurrentPosition));
    }

    private void UpdateGhosts()
    {
      foreach (Ghost ghost in Ghosts)
      {
        SetGhostHeading(ghost);
        MoveGhost(ghost);
      }
    }

    private void PacManDieAndReStartLevelSequence()
    {
      Grid = new Grid(Level.RowCount, Level.ColumnCount);
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
