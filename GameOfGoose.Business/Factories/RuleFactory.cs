using GameOfGoose.Business.Print;
using GameOfGoose.Business.Rules;

namespace GameOfGoose.Business.Factories;

public class RuleFactory : IRuleFactory
{
    private ILogger _logger;

    public RuleFactory(ILogger logger)
    {
        _logger = logger;
    }

    public IRules CreateRule(int position, RuleType ruleType)
    {
        switch (ruleType)
        {
            case RuleType.None:
                return new NoneRule(_logger, position);

            case RuleType.Goose:
                return new Goose(_logger, position);

            case RuleType.Bridge:
                return new Bridge(_logger, position);

            case RuleType.Inn:
                return new Inn(_logger, position);

            case RuleType.Maze:
                return new Maze(_logger, position);

            case RuleType.Prison:
                return new Prison(_logger, position);

            case RuleType.Well:
                return new Well(_logger, position);

            case RuleType.Death:
                return new Death(_logger, position);

            case RuleType.End:
                return new End(_logger, position);

            default:
                throw new ArgumentOutOfRangeException(nameof(ruleType), $"This type is not supported");
        }
    }
}