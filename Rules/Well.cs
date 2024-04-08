
namespace GameOfGoose.Rules
{
    public class Well : IRules
    {
        public int Position { get; set; }

        public Well(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            player.InWell = true;
        }
    }
}
