namespace GameOfGoose.Business.Factories;

public interface IPlayerFactory
{
    Player Create(string playerName);
}