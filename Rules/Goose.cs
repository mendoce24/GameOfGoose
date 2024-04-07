namespace GameOfGoose.Rules
{
    public class Goose : IRules
    {
        public void ValidateRule(Player player)
        {
            int valueToMove = (player.Position - player.LastPosition)   + player.Position;
            player.MoveTo(valueToMove);
        }
    }
}