namespace GameOfGoose.Board
{
    public interface IBoard
    {
        int FinalPosition { get; }

        IRules GetBoardAction(int position);
    }
}