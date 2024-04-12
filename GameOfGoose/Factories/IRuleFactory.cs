namespace GameOfGoose.Factories
{
    public interface IRuleFactory
    {
        IRules CreateRule(int position, RuleType type);
    }
}