using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Death : IRules
{
    public int Position { get; set; }
    private readonly ILogger _logger;

    public Death(ILogger logger, int position)
    {
        _logger = logger;
        Position = position;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\t{player.Name} died in square {Position}! Move back to start");
        player.MoveTo(0);
    }
}