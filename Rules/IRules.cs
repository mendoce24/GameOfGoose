
namespace GameOfGoose
{
    public interface IRules
    {
        public int Position { get; set; }

        void ValidateRule(Player player);
    }
}
