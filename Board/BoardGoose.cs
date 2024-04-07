using GameOfGoose.Rules;

namespace GameOfGoose.Board
{
    public class BoardGoose : IBoard
    {
        private readonly int _FinalPosition = 63;
        public int FinalPosition() => _FinalPosition;

        private readonly Dictionary<int, IRules> _board = new Dictionary<int, IRules>
        {
            {6, new Bridge()},
            {19,new Inn()},
            {31, new Well()},
            {42, new Maze()},
            {52, new Prison()},
            {58, new Death()},
            {5, new Goose()},
            {9, new Goose()},
            {14, new Goose()},
            {18, new Goose()},
            {23, new Goose()},
            {32, new Goose()},
            {36, new Goose()},
            {41, new Goose()},
            {45, new Goose()},
            {50, new Goose()},
            {54, new Goose()},
            {59, new Goose()}
        };

        public IRules GetBoardAction(int position)
        {
            return _board.ContainsKey(position) ? _board[position] : new None();
        }
    }
}