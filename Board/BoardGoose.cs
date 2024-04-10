using GameOfGoose.Factories;

namespace GameOfGoose.Board
{
    public sealed class BoardGoose : IBoard
    {
        private static BoardGoose instance = null;

        private readonly int[] _geese = [5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59];
        private readonly List<IRules> _rules;
        private readonly IRuleFactory _ruleFactory;

        private BoardGoose()
        {
            _ruleFactory = new RuleFactory();
            _rules = CreateBoard();
        }

        public static BoardGoose Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoardGoose();
                }
                return instance;
            }
        }

        public int FinalPosition => _rules == null ? 63 : _rules.Count - 1;

        public IRules GetBoardAction(int position)
        {
            return _rules[position];
        }

        private List<IRules> CreateBoard()
        {
            List<IRules> result = [];
            for (int i = 0; i <= FinalPosition; i++)
            {
                if (i == 6)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Bridge));
                }
                else if (i == 19)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Inn));
                }
                else if (i == 31)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Well));
                }
                else if (i == 42)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Maze));
                }
                else if (i == 52)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Prison));
                }
                else if (i == 58)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Death));
                }
                else if (i == 63)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.End));
                }
                else if (_geese.Contains(i))
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Goose));
                }
                else
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.None));
                }
            }

            return result;
        }
    }
}