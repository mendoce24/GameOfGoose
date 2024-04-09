namespace GameOfGoose.Rules
{
    public class Goose : IRules
    {
        public int Position { get; set; }

        public Goose(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            int valueToMove = (Position - player.Position) + Position;
            player.MoveTo(valueToMove);// TODO 
        }
    }
}