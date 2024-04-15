using GameOfGoose.Business;
using GameOfGoose.Business.Board;
using GameOfGoose.Business.Dice;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Print;
using GameOfGoose.Print;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfGoose;

public class Configuration
{
    private ServiceProvider ConfigureServices()
    {
        // All dependencies go here
        var serviceProvider = new ServiceCollection()
            .AddTransient<ILogger, PrintInConsole>()
            .AddTransient<IDice, Dice>()
            .AddTransient<IRuleFactory, RuleFactory>()
            .AddTransient<IPlayerFactory, PlayerFactory>()
            .AddSingleton<IBoard, BoardGoose>()
            .AddSingleton<Game>()
            .BuildServiceProvider();

        return serviceProvider;
    }

    public Game StartGame()
    {
        Game game = ConfigureServices().GetRequiredService<Game>();
        return game;
    }
}
