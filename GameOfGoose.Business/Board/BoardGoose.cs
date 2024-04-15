using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Rules;

namespace GameOfGoose.Business.Board;

public sealed class BoardGoose : IBoard
{
    private readonly int[] _geese = [5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59];
    private readonly List<IRules> _rules;
    private readonly IRuleFactory _ruleFactory;

    public BoardGoose(IRuleFactory ruleFactory)
    {
        _ruleFactory = ruleFactory;
        _rules = CreateBoard();
    }

    public int FinalPosition => _rules == null ? 63 : _rules.Count - 1;

    public IRules GetBoardAction(int position) => _rules[position];

    private List<IRules> CreateBoard()
    {
        List<IRules> result = [];
        for (int i = 0; i <= FinalPosition; i++)
        {
            switch (i)
            {
                case 6:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Bridge));
                    break;

                case 19:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Inn));
                    break;

                case 31:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Well));
                    break;

                case 42:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Maze));
                    break;

                case 52:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Prison));
                    break;

                case 58:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Death));
                    break;

                case 63:
                    result.Add(_ruleFactory.CreateRule(i, RuleType.End));
                    break;

                default:
                    if (_geese.Contains(i))
                    {
                        result.Add(_ruleFactory.CreateRule(i, RuleType.Goose));
                    }
                    else
                    {
                        result.Add(_ruleFactory.CreateRule(i, RuleType.None));
                    }

                    break;
            }
        }

        return result;
    }
}