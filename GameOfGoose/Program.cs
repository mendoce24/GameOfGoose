using GameOfGoose.Business;

namespace GameOfGoose;

public class Program
{
    private static void Main()
    {
        var config = new Configuration();
        Game game = config.StartGame();

        Console.WriteLine("Game starting");

        game.Play();

        if (game.IsGameFinished())
        {
            Player? winner = game.GetWinner();
            if (winner != null)
            {
                Console.WriteLine($"Player {winner.Name} Won!");
            }                
        }

        Console.WriteLine("Game over!");
        Console.ReadLine();
    }
}