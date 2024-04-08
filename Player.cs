
namespace GameOfGoose
{
    public class Player
    {
        public string Name { get; private set; }
        public int LastPosition { get; private set; }
        public int Position { get; private set; }
        public int TurnsToSkip { get; private set; }
        public bool InWell { get; set; }

        public Player(string name) {
            Name = name;
            Position = 0;
        }

        public void MoveTo(int destination)
        {
            LastPosition = Position;
            Position = destination;
        }

        public void SetTurnsToSkip(int numberOfTurns)
        {
            TurnsToSkip = numberOfTurns;
        }

       
    }
}
