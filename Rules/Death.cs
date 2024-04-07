namespace GameOfGoose.Rules
{
    public class Death : IRules
    {
        public void ValidateRule(Player player)
        {
            player.MoveTo(0);
        }
    }
}