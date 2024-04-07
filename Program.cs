using GameOfGoose.Board;
using GameOfGoose.Print;

namespace GameOfGoose
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = {
                new Player("PIECE 1"),
                new Player("PIECE 2")
            };

            IDice dice = new Dice();
            IBoard boqrdGame = new BoardGoose();
            IPrint print = new PrintInConsole();

            Game game = new Game(boqrdGame, players, dice, print) ;
            game.Play();
        }
    }
}
