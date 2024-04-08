namespace GameOfGoose.Rules
{
    public class Prison : IRules
    {
        public int Position { get; set; }

        public Prison(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.SetTurnsToSkip(3);
        }
    }
}
