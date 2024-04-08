using GameOfGoose.Board;
using GameOfGoose.Dice;
using GameOfGoose.Print;
using GameOfGoose.Rules;

namespace GameOfGoose
{
    public class Game
    {
        private readonly IBoard board;
        private readonly Player[] players;
        private readonly IDice dice;
        private readonly IPrint print;

        private int turn;
        private string headText;
        private string turnText;
        private string someoneInWell;

        public Game(IBoard board, Player[] players, IDice dice, IPrint print)
        {
            this.players = players;
            this.dice = dice;
            this.board = board;
            this.print = print;
            this.someoneInWell = string.Empty;
        }

        public void Play()
        {
            turn = 0;
            headText = string.Empty;

            print.Print("\t\tGAME OF GOOSE");

            while (true)
            {
                turn++;
                turnText = string.Empty;

                foreach (var player in players)
                {
                    if (turn == 1)
                        headText += $"\t{player.Name}\t";

                    //Well position  validation
                    if (player.InWell && ((this.someoneInWell != string.Empty) && (this.someoneInWell != player.Name)))
                    {
                        this.someoneInWell = player.Name;
                        player.SetTurnsToSkip(0);
                    }

                    Turn(player);

                    //Well position validation
                    if (player.InWell)
                        this.someoneInWell = player.Name;

                    if (player.Position == board.FinalPosition)
                    {
                        print.Print($"TURN {turn}");
                        print.Print($"{turnText}");
                        print.Print($"{player.Name} WINNER!!!");
                        return;
                    }
                }

                if (turn == 1)
                    print.Print($"{headText}");

                print.Print($"TURN {turn}");
                print.Print($"{turnText}");
            }
        }

        private int[] RollTheDice(int numberOfDie = 2)
        {
            int[] result = new int[numberOfDie];

            for (int i = 0; i < numberOfDie; i++)
            {
                result[i] = dice.Roll();
            }

            return result;
        }

        private void Turn(Player player)
        {
            int[] dices = RollTheDice();
            player.Move(dices);

            if (turn == 1)// Shift 1 game flow
            {
                HandleFirstTurn(player, dices);
            }
            else if (player.TurnsToSkip == 0) // Normal game flow
            {
                player.Move(dices);
                ValidateTurn(player);
                WriteMessage(player, dices);
            }
            else
            {
                player.SkipTurn();
            }
        }

        private void HandleFirstTurn(Player player, int[] dices)
        {
            var actionFirst = new FirstThrow(dices[0], dices[1]);
            actionFirst.ValidateRule(player);

            turnText += $"\t{dices[0]} + {dices[1]}: S{player.Position}";
        }

        private void WriteMessage(Player player, int[] dices)
        {
            //TODO: Printing should be in seperate class
            turnText += $"\t{dices[0]} + {dices[1]}: S{player.LastPosition} -> S{player.Position}";
        }

        private void ValidateTurn(Player player)
        {
            // TODO: Move into Player 
            print.Print($"entra a la validacion");
            IRules action = board.GetBoardAction(player.Position);
            action.ValidateRule(player);
        }
    }
}