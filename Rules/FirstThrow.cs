
namespace GameOfGoose.Rules
{
    public class FirstThrow
    {
        // TODO: This class is not an IRule -> It has no position
        private int rollDice1;
        private int rollDice2;

        public FirstThrow(int rollDice1, int rollDice2)
        {
            this.rollDice1 = rollDice1;
            this.rollDice2 = rollDice2;
        }

        public int Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ValidateRule(Player player)
        {
            if (new[] { rollDice1, rollDice2 }.OrderBy(x => x).SequenceEqual(new[] { 4, 5 }))
            {
                player.MoveTo(26);
            }
            else if (new[] { rollDice1, rollDice2 }.OrderBy(x => x).SequenceEqual(new[] { 3, 6 }))
            {
                player.MoveTo(53);
            }
        }
    }
}
