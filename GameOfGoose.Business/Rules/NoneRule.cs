using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class NoneRule : IRules
{
    public int Position { get; set; }

    private readonly ILogger _logger;

    public NoneRule(ILogger logger, int position)
    {
        _logger = logger;
        Position = position;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} entered normal square {Position}");
    }
}