namespace GameOfGoose.Rules
{
    public class FirstThrow : IRuleValidation
    {
        // TODO: This class is not an IRule -> It has no position
        private int[] _dices;

        public FirstThrow(int[] dices)
        {
            _dices = dices;
        }

        public void ValidateRule(Player player)
        {
            if (_dices.OrderBy(x => x).SequenceEqual(new[] { 4, 5 }))
            {
                player.MoveTo(26);
            }
            else if (_dices.OrderBy(x => x).SequenceEqual(new[] { 3, 6 }))
            {
                player.MoveTo(53);
            }
            else
            {
                player.Move(_dices);
            }
        }
    }
}