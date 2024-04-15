using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Prison : IRules
{
    public int Position { get; set; }

    private readonly ILogger _logger;

    public Prison(ILogger logger, int position)
    {
        Position = position;
        _logger = logger;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} is in Prison square {Position}!. Skip 3 turns");
        player.SetTurnsToSkip(3);
    }
}