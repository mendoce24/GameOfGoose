using GameOfGoose.Rules;

namespace GameOfGoose.Factories
{
    public class RuleFactory : IRuleFactory
    {
        public IRules CreateRule(int position, RuleType ruleType)
        {
            switch (ruleType)
            {
                case RuleType.None:
                    return new NoneRule(position);

                case RuleType.Goose:
                    return new Goose(position);

                case RuleType.Bridge:
                    return new Bridge(position);

                case RuleType.Inn:
                    return new Inn(position);

                case RuleType.Maze:
                    return new Maze(position);

                case RuleType.Prison:
                    return new Prison(position);

                case RuleType.Well:
                    return new Well(position);

                case RuleType.Death:
                    return new Death(position);

                case RuleType.End:
                    return new End(position);

                default:
                    throw new ArgumentOutOfRangeException(nameof(ruleType), $"This type is not supported");
            }
        }
    }
}