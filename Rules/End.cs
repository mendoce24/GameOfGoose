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
            //TODO Validate 63 position
            throw new NotImplementedException();
        }
    }
}