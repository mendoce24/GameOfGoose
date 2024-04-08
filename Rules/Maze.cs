namespace GameOfGoose.Rules
{
    public class Maze : IRules
    {
        public int Position { get; set; }

        public Maze(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.MoveTo(39);
        }
    }
}