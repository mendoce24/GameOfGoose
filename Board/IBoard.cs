namespace GameOfGoose.Board
{
    public interface IBoard
    {
        int FinalPosition();
        IRules GetBoardAction(int position);
    }
}
