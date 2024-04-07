
namespace GameOfGoose.Rules
{
    public class Prison : IRules
    {
        public void ValidateRule(Player player)
        {
            int TurnsToSkip;
            TurnsToSkip = (player.TurnsToSkip > 0) ? player.TurnsToSkip - 1 : 3;
            player.SkipTurn(TurnsToSkip);
        }
    }
}
