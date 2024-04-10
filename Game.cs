using GameOfGoose.Board;
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
        private string _playerInWell;

        public Game(Player[] players, IDice dice, IPrint print, PrintFormat format)
        {
            _players = players;
            _dice = dice;
            _print = print;
            _playerInWell = string.Empty;
            _format = format;
        }

        public void Play()
        {
            _turn = 0;
            string turnText;
            bool gameFinishes = false;

            _print.Print(_format.HeaderGame(_players));

            while (!gameFinishes)
            {
                _turn++;
                turnText = string.Empty;
                foreach (Player player in _players)
                {
                    ValidateWellExit(player);
                    turnText += PlayTurn(player);
                    ValidateWellEntry(player);
                }

                _print.Print($"TURN {_turn}");
                _print.Print(turnText);

                if (_players.FirstOrDefault(p => p.Winner) != null)
                {
                    turnText = _format.WinnerGame(_players);
                    _print.Print(turnText);
                    gameFinishes = true;
                }
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

        private string PlayTurn(Player player)
        {
            string turnText;
            int[] dices = RollTheDice();

            if (player.TurnsToSkip > 0 || player.InWell)
            {
                player.SkipTurn();
                turnText = _format.SkipedTurn();
            }
            else if (_turn == 1) // 1st turn game flow
            {
                HandleFirstTurn(player, dices);
                turnText = _format.NormalTurn(player, dices);
            }
            else // Normal game flow
            {
                player.Move(dices);
                turnText = _format.NormalTurn(player, dices);
            }
            return turnText;
        }

        private void HandleFirstTurn(Player player, int[] dices)
        {
            FirstThrow actionFirst = new FirstThrow(dices);
            actionFirst.ValidateRule(player);
        }

        private void ValidateWellEntry(Player player)
        {
            if (player.InWell)
            {
                _playerInWell = player.Name;
            }
        }

        private void ValidateWellExit(Player player)
        {
            if (player.InWell && _playerInWell != string.Empty && _playerInWell != player.Name)
            {
                player.InWell = false;
            }
        }
    }
}