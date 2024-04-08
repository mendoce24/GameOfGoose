namespace GameOfGoose.Rules
{
    public class Prison : IRules
    {
        public void ValidateRule(Player player)
        {
            player.SetTurnsToSkip(3);
        }
    }
}
