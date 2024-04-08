using GameOfGoose.Factories;
using GameOfGoose.Rules;

namespace GameOfGoose.Board
{
    public class BoardGoose : IBoard
    {
        public int[] geese = { 5, 9, 14, 18, 23, 32, 36, 41, 45, 50, 54, 59 };

        private readonly List<IRules> _rules;
        private IRuleFactory _ruleFactory;

        public BoardGoose(IRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
            _rules = CreateBoard();
        }

        public int FinalPosition => _rules.Count;

        public int CheckPosition(int position)
        {
            return (position > FinalPosition) ? FinalPosition - (position - FinalPosition) : position;
        }

        public IRules GetBoardAction(int position)
        {
            return _rules[position];
        }

        private List<IRules> CreateBoard()
        {
            List<IRules> result = new List<IRules>();
            for(int i = 0; i < FinalPosition; i++)
            {
                if(i == 6)
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Bridge));
                }
                else if(i == 19) 
                {
                    result.Add(_ruleFactory.CreateRule(i, RuleType.Inn));
                }
                // TODO: Add other Rules


                else if(geese.Contains(i)) 
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