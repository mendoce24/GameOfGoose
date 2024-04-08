namespace GameOfGoose.Rules
{
    public class Death : IRules
    {
        public int Position { get; set; }

        public Death(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.MoveTo(0);
        }
    }
}