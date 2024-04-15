using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Inn : IRules
{
    public int Position { get; set; }

    private readonly ILogger _logger;

    public Inn(ILogger logger, int position)
    {
        _logger = logger;
        Position = position;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} is spending an evening at the Inn, square {Position}. Skip 1 turn");
        player.SetTurnsToSkip(1);
    }
}