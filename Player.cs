
using GameOfGoose.Board;
using System.Numerics;

namespace GameOfGoose
{
    public class Player
    {
        private BoardGoose _board;

        public string Name { get; private set; }
        public int LastPosition { get; private set; }
        public int Position { get; private set; }
        public int TurnsToSkip { get; private set; }
        public bool InWell { get; set; }
        public bool Winner { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
            _board = BoardGoose.Instance;
            Winner = false;
        }

        public void Move(int[] dice)
        {
            int destination = Position + dice.Sum();

            destination = _board.CheckPosition(destination);

            MoveTo(destination);
            IRules action = _board.GetBoardAction(Position);
            action.ValidateRule(this);
        }

        public void MoveTo(int destination)
        {
            LastPosition = Position;
            Position = destination;
            // *TODO: Have player enter square and handle event
        }

        public void SetTurnsToSkip(int numberOfTurns)
        {
            TurnsToSkip = numberOfTurns;
        }

        public void SkipTurn()
        {
            if(TurnsToSkip > 0)
            {
                SetTurnsToSkip(TurnsToSkip - 1);
            }
        }
    }
}