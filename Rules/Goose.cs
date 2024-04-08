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
            int valueToMove = (player.Position - player.LastPosition) + player.Position;
            player.MoveTo(valueToMove);//TODO validate position greater than 63
        }
    }
}