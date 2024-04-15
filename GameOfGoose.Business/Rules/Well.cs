using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Well : IRules
{
    public int Position { get; set; }

    private readonly ILogger _logger;

    public Well(ILogger logger, int position)
    {
        Position = position;
        _logger = logger;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} is in Well, square {Position}!");
        player.InWell = true;
    }
}