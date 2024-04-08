using GameOfGoose.Dice;
using System.Numerics;

namespace GameOfGoose
{
    public class Player
    {
        public string Name { get; private set; }
        public int LastPosition { get; private set; }
        public int Position { get; private set; }
        public int TurnsToSkip { get; private set; }
        public bool InWell { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
        }

        public void Move(int[] dice)
        {
            int destination = Position + dice.Sum();

            // TODO: is the player over the last square?
            if (true) // Calculate overshot
            {
                MoveTo(destination);
            }
            else
            {
                // MoveBack
            }


        }

        public void MoveTo(int destination)
        {
            LastPosition = Position;
            Position = destination;

           // TODO: Have player enter square and handle event
        }

        public void SetTurnsToSkip(int numberOfTurns)
        {
            TurnsToSkip = numberOfTurns;
        }

        internal void SkipTurn()
        {
            throw new NotImplementedException();
        }
    }
}