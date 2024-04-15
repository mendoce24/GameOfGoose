using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

internal class End : IRules
{
    public int Position { get; set; }

    private readonly ILogger _logger;

    public End(ILogger logger, int position)
    {
        Position = position;
        this._logger = logger;
    }

    public void ValidateRule(Player player)
    {
        _logger.Log($"\tPlayer {player.Name} Won!");
        player.Winner = true;
    }
}