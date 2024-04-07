namespace GameOfGoose.Rules
{
    public class Bridge : IRules
    {
        public void ValidateRule(Player player)
        {
            player.MoveTo(12);
        }
    }
}