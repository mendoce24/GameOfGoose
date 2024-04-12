using GameOfGoose.Rules;

namespace GameOfGoose
{
    public interface IRules : IRuleValidation
    {
        public int Position { get; set; }
    }
}