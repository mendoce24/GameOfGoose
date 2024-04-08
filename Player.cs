
namespace GameOfGoose
{
    public class Player
    {
        public string Name { get; private set; }
        public int LastPosition { get; private set; }
        public int Position { get; private set; }
        public int TurnsToSkip { get; private set; }
        public bool InWelling { get; private set; }

        public Player(string name) {
            Name = name;
            Position = 0;
        }

        public void MoveTo(int destination)
        {
            LastPosition = Position;
            Position = destination;
        }

        public void SkipTurn(int numberOfTurns)
        {
            TurnsToSkip = numberOfTurns;
        }

        public void InWell(bool numberOfTurns)
        {
            InWelling = numberOfTurns;
        }
    }
}
