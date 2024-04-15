using GameOfGoose.Business.Dice;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Print;
using GameOfGoose.Business.Rules;

namespace GameOfGoose.Business;

public class Game
{
    private Player[]? _players;
    private readonly IDice _dice;
    private readonly ILogger _print;
    private readonly IPlayerFactory _playerFactory;

    private int _turn;

    public Game(IDice dice, ILogger print, IPlayerFactory playerFactory)
    {
        _dice = dice;
        _print = print;
        _playerFactory = playerFactory;
        _players = null;
    }

    public void Play(int amountOfPlayers = 2)
    {
        _turn = 0;
        _players = CreatePlayers(amountOfPlayers);

        while (!IsGameFinished())
        {
            _turn++;
            RunPlayTurn(_players);
        }
    }

    private Player[] CreatePlayers(int amountOfPlayers)
    {
        Player[] players = new Player[amountOfPlayers];

        for (int i = 0; i < amountOfPlayers; i++)
        {
            players[i] = _playerFactory.Create($"Player {i}");
        }

        return players;
    }

    private void RunPlayTurn(Player[] players)
    {
        _print.Log($"TRUN {_turn}");
        foreach (Player player in players)
        {
            int[] dices = RollTheDice();

            player.ValidateWellExit(players);
            PlayTurn(player, dices);
        }
    }

    public void PlayTurn(Player player, int[] dices)
    {
        if (player.TurnsToSkip > 0 || player.InWell)
        {
            player.SkipTurn();
        }
        else if (_turn == 1) // 1st turn game flow
        {
            HandleFirstTurn(player, dices);
        }
        else // Normal game flow
        {
            player.Move(dices);
        }
    }

    private int[] RollTheDice(int numberOfDie = 2)
    {
        int[] result = new int[numberOfDie];

        for (int i = 0; i < numberOfDie; i++)
        {
            result[i] = _dice.Roll();
        }

        return result;
    }

    private void HandleFirstTurn(Player player, int[] dices)
    {
        FirstThrow actionFirst = new(_print, dices);
        actionFirst.ValidateRule(player);
    }

    public bool IsGameFinished()
    {
        if (_players != null)
        {
            return _players.Any(p => p.Winner);
        }
        return false;
    }

    public Player? GetWinner()
    {
        if (!IsGameFinished()) return null;

        if (_players != null)
        {
            return _players.Where(x => x.Winner == true).Single();
        }
        return null;
    }
}