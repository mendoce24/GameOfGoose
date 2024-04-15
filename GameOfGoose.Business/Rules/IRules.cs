namespace GameOfGoose.Business.Rules;

public interface IRules : IRuleValidation
{
    public int Position { get; set; }
}