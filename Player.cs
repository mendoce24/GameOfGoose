using GameOfGoose.Board;

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
        public bool InReverse { get; set; }
        public int ValueDice { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
            _board = BoardGoose.Instance;
            Winner = false;
            InReverse = false;
            ValueDice = 0;
        }

        public void Move(int[] dice)
        {
            ValueDice = dice.Sum();
            int destination = Position + ValueDice;

            MoveTo(destination);
            IRules action = _board.GetBoardAction(Position);
            action.ValidateRule(this);
        }

        public void MoveTo(int destination)
        {
            LastPosition = Position;
            Position = CheckNotOverstepFinalPosition(destination);
        }

        public void SetTurnsToSkip(int numberOfTurns)
        {
            TurnsToSkip = numberOfTurns;
        }

        public void SkipTurn()
        {
            if (TurnsToSkip > 0)
            {
                SetTurnsToSkip(TurnsToSkip - 1);
            }
        }

        public int CheckNotOverstepFinalPosition(int position)
        {
            InReverse = false;
            if (position > _board.FinalPosition)
            {
                InReverse = true;
                position = _board.FinalPosition * 2 - position;
            }

            return position;
        }

        public void ValidateWellExit(Player[] players)
        {
            if (players.FirstOrDefault(p => p.InWell && p.Name != Name) != null)
            {
                InWell = false;
            }
        }
    }
}