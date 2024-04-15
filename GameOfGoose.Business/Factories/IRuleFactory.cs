using GameOfGoose.Business.Rules;

namespace GameOfGoose.Business.Factories;

public interface IRuleFactory
{
    IRules CreateRule(int position, RuleType type);
}