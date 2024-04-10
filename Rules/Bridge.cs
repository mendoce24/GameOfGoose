namespace GameOfGoose.Rules
{
    public class Bridge : IRules
    {
        public int Position { get; set; }

        public Bridge(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.MoveTo(12);
        }
    }
}