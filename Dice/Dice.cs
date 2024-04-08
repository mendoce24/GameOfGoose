namespace GameOfGoose.Dice
{
    internal class Dice : IDice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}