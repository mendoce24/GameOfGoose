
namespace GameOfGoose
{
    public class Player
    {
        public string Name { get; private set; }
        public int LastPosition { get; private set; }
        public int Position { get; private set; }//ToDo Private
        public int TurnsToSkip { get; private set; }
        //public int[] DiceTurn { get; set; }

        public Player(string name) {
            Name = name;
            Position = 0;
            //DiceTurn = new int[];
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

    }
}
