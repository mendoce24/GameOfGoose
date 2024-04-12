namespace GameOfGoose.Rules
{
    public class Inn : IRules
    {
        public int Position { get; set; }

        public Inn(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.SetTurnsToSkip(1);
        }
    }
}