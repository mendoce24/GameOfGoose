namespace GameOfGoose.Rules
{
    internal class End : IRules
    {
        public int Position { get; set; }

        public End(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.Winner = true;
        }
    }
}