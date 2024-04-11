using GameOfGoose.Dice;
using GameOfGoose.Print;
using GameOfGoose.Rules;

namespace GameOfGoose
{
    public class Game
    {
        private readonly Player[] _players;
        private readonly IDice _dice;
        private readonly IPrint _print;
        private readonly PrintFormat _format;

        private int _turn;

        public Game(Player[] players, IDice dice, IPrint print, PrintFormat format)
        {
            _players = players;
            _dice = dice;
            _print = print;
            _format = format;
        }

        public void Play()
        {
            _turn = 0;
            _print.Print(_format.HeaderGame(_players));

            while (!IsGameFinished())
            {
                _turn++;
                RunPlayTurn();
                DisplayTurnInfo();
            }
        }

        private void RunPlayTurn()
        {
            foreach (Player player in _players)
            {
                int[] dices = RollTheDice();

                player.ValidateWellExit(_players);
                PlayTurn(player, dices);
            }
        }
       

        public void PlayTurn(Player player, int[] dices)
        {
            if (player.TurnsToSkip > 0 || player.InWell)
            {
                player.SkipTurn();
                player.TextTrun = _format.SkipedTurn();
            }
            else if (_turn == 1) // 1st turn game flow
            {
                HandleFirstTurn(player, dices);
                player.TextTrun = _format.NormalTurn(player, dices);
            }
            else // Normal game flow
            {
                player.Move(dices);
                player.TextTrun = _format.NormalTurn(player, dices);
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
            FirstThrow actionFirst = new FirstThrow(dices);
            actionFirst.ValidateRule(player);
        }

        private bool IsGameFinished() => _players.Any(p => p.Winner);

        private void DisplayTurnInfo()
        {
            string turnText = string.Join("", _players.Select(p => p.TextTrun));

            _print.Print($"TURN {_turn}");
            _print.Print(turnText);

            if (IsGameFinished())
            {
                string winnerTurnText = _format.WinnerGame(_players);
                _print.Print(winnerTurnText);
            }
        }
    }
}