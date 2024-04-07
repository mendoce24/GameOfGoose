namespace GameOfGoose.Rules
{
    public class Maze : IRules
    {
        public void ValidateRule(Player player)
        {
            player.MoveTo(39);
        }
    }
}