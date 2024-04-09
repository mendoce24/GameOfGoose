using GameOfGoose.Board;
using GameOfGoose.Dice;
using GameOfGoose.Print;
using GameOfGoose.Rules;
using System.Security.Cryptography.X509Certificates;

namespace GameOfGoose
{
    public class Game
    {
        private readonly IBoard _board;
        private readonly Player[] _players;
        private readonly IDice _dice;
        private readonly IPrint _print;

        private int _turn;
        private string _headText;
        private string _turnText;
        private string _playerInWell;

        public Game(Player[] players, IDice dice, IPrint print)
        {
            _players = players;
            _dice = dice;
            _board = BoardGoose.Instance;
            _print = print;
            _headText = string.Empty;
            _turnText = string.Empty;
            _playerInWell = string.Empty;
        }

        public void Play()
        {
            //TODO
            _turn = 0;
            _headText = string.Empty;

            _print.Print("\t\tGAME OF GOOSE");

            while (true)
            {
                _turn++;
                _turnText = string.Empty;

                foreach (var player in _players)
                {
                    if (_turn == 1)
                    {
                        _headText += $"\t{player.Name}\t";
                    }

                    ValidateWellExit(player);

                    PlayTurn(player);

                    ValidateWellEntry(player);

                    if (player.Winner)
                    {
                        _print.Print($"TURN {_turn}");
                        _print.Print($"{_turnText}");
                        _print.Print($"{player.Name} WINNER!!!");
                        return;
                    }
                }

                if (_turn == 1)
                {
                    _print.Print($"{_headText}");
                }

                _print.Print($"TURN {_turn}");
                _print.Print($"{_turnText}");
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

        private void PlayTurn(Player player)
        {
            int[] dices = RollTheDice();

            if (player.TurnsToSkip == 0)// Normal game flow
            {
                player.Move(dices);
                WriteMessage(player, dices);
            }
            else if (_turn == 1) // 1st turn game flow
            {
                HandleFirstTurn(player, dices);
            }
            else
            {
                player.SkipTurn();
                WriteMessage(player, dices, "\t/\t");
            }
        }

        private void HandleFirstTurn(Player player, int[] dices)
        {
            var actionFirst = new FirstThrow(dices);
            actionFirst.ValidateRule(player);

            _turnText += $"\t{dices[0]} + {dices[1]}:\tS{player.Position}\t";
        }

        private void WriteMessage(Player player, int[] dices, string msg = "")
        {
            //TODO: Printing should be in seperate class
            if (msg.Length > 0)
            {
                _turnText += msg;
            }
            else
            { 
                _turnText += $"\t{dices[0]} + {dices[1]}: S{player.LastPosition} -> S{player.Position}"; 
            }            
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