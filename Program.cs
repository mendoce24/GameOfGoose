using GameOfGoose.Board;
using GameOfGoose.Dice;
using GameOfGoose.Factories;
using GameOfGoose.Print;

namespace GameOfGoose
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = {
                new Player("PIECE 1"),
                new Player("PIECE 2")/*,
                new Player("PIECE 3"),
                new Player("PIECE 4")*/
            };

            IDice dice = new Dice.Dice();
            IRuleFactory factory = new RuleFactory();   
            IBoard boardGame = new BoardGoose(factory);
            IPrint print = new PrintInConsole();

            Game game = new Game(boardGame, players, dice, print) ;
            game.Play();
        }
    }
}
