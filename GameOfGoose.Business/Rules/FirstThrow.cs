using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules;

public class FirstThrow : IRuleValidation
{
    // TODO: This class is not an IRule -> It has no position
    private readonly int[] _dices;

    private readonly ILogger _logger;

    public FirstThrow(ILogger logger, int[] dices)
    {
        _logger = logger;
        _dices = dices;
    }

    public void ValidateRule(Player player)
    {
        if (_dices.OrderBy(x => x).SequenceEqual([4, 5]))
        {
            _logger.Log($"\t{player.Name} move to 26 !");
            player.MoveTo(26);
        }
        else if (_dices.OrderBy(x => x).SequenceEqual([3, 6]))
        {
            _logger.Log($"\t{player.Name} move to 53 !");
            player.MoveTo(53);
        }
        else
        {
            player.Move(_dices);
        }
    }
}