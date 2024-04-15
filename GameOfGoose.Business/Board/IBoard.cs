using GameOfGoose.Business.Rules;

namespace GameOfGoose.Business.Board;

public interface IBoard
{
    int FinalPosition { get; }

    IRules GetBoardAction(int position);
}