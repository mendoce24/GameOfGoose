namespace GameOfGoose.Rules
{
    public class NoneRule : IRules
    {
        public int Position { get; set; }

        public NoneRule(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
        }
    }
}