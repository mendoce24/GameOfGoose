
namespace GameOfGoose.Rules
{
    public class Inn : IRules
    {
        public void ValidateRule(Player player)
        {
            int TurnsToSkip;
            TurnsToSkip = (player.TurnsToSkip > 0) ? 0 : 1;
            player.SkipTurn(TurnsToSkip);
        }
    }
}
