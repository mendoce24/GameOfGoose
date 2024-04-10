using GameOfGoose.Board;
using GameOfGoose.Dice;
using GameOfGoose.Print;

namespace GameOfGoose
{
    internal class Program
    {
        private static void Main()
        {
            Player[] players = {
                new Player("PIECE 1"),
                new Player("PIECE 2"),
                new Player("PIECE 3")/*,
                new Player("PIECE 4")*/
            };

            // All dependencies go here
            IDice dice = new Dice.Dice();
            BoardGoose boardGame = BoardGoose.Instance;//Singleton implementation
            IPrint print = new PrintInConsole();
            PrintFormat forrmat = new PrintFormat();

            Game game = new(players, dice, print, forrmat);
            game.Play();
        }
    }
}