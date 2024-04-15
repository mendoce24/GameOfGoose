using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Maze : IRules
{
    public int Position { get; set; }
    private readonly ILogger _logger;

    public Maze(ILogger logger, int position)
    {
        Position = position;
        _logger = logger;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} hit a Maze in square {Position}!. Move to square 39!");
        player.MoveTo(39);
    }
}