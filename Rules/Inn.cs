namespace GameOfGoose.Rules
{
    public class Inn : IRules
    {
        public void ValidateRule(Player player)
        {
            player.SetTurnsToSkip(1);
        }
    }
}