using GameOfGoose.Business.Board;

namespace GameOfGoose.Business.Factories;

public class PlayerFactory : IPlayerFactory
{
    private readonly IBoard _board;

    public PlayerFactory(IBoard board)
    {
        _board = board;
    }

    public Player Create(string playerName)
    {
        return new Player(_board, playerName);
    }
}