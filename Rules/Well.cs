
namespace GameOfGoose.Rules
{
    public class Well : IRules
    {
        public void ValidateRule(Player player)
        {
            player.SkipTurn(1); // TODO: Stuck unless other player enters
        }
    }
}
