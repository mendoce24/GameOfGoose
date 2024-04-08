
namespace GameOfGoose.Rules
{
    public class Well : IRules
    {
        public void ValidateRule(Player player)
        {
            player.InWell = true;
        }
    }
}
