using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class Bridge : IRules
{
    private readonly ILogger _logger;

    public int Position { get; set; }

    public Bridge(ILogger logger, int position)
    {
        _logger = logger;
        Position = position;
    }

    public void ValidateRule(Player player)
    {
        int destination = 12;
        _logger.Log($"\t{player.Name} got a bridge in square {Position}. Move to {destination}");
        player.MoveTo(destination);
    }
}