using GameOfGoose.Board;
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
        private int shift;
        private string headText;
        private string shiftText;
        private String someoneInPrision;

        public Game(IBoard board, Player[] players, IDice dice, IPrint print)
        {
            this.players = players;
            this.dice = dice;
            this.board = board;
            this.print = print;
            this.someoneInPrision = string.Empty;
        }

        public void Play()
        {
            shift = 0;
            headText = string.Empty;

            print.Print("Game of Goose!");

            while (true)
            {
                shift++;
                shiftText = string.Empty;

                foreach (var player in players)
                {
                    if (shift == 1)
                        headText += $"\t{player.Name}\t";

                    Turn(player);

                    if (player.Position == board.FinalPosition())
                    {
                        print.Print($"TURN {shift}");
                        print.Print($"{shiftText}");
                        print.Print($"{player.Name} wins!");
                        return;
                    }
                }

                if (shift == 1)
                    print.Print($"{headText}");

                print.Print($"TURN {shift}");
                print.Print($"{shiftText}");
            }
        }

        private void Turn(Player player)
        {
            int roll = dice.Roll();
            int roll2 = dice.Roll();
            int newPosicion = player.Position + (roll + roll2);

            if (shift == 1)
            {
                player.MoveTo(newPosicion);

                IRules actionFirst = new FirstThrow(roll, roll2);
                actionFirst.ValidateRule(player);
                shiftText += $"\t{roll} + {roll2}: S{player.Position}";
            }
            else if (player.TurnsToSkip == 0)
            {
                newPosicion = CheckPosition(newPosicion);
                player.MoveTo(newPosicion);

                IRules action = this.board.GetBoardAction(newPosicion);

                action.ValidateRule(player);//TODO Validate 63 position

                if (player.Position != newPosicion)
                {
                    shiftText += $"\t{roll} + {roll2}: S{player.LastPosition} -> S{player.Position}";

                    if (player.TurnsToSkip != 0)
                        validateTurn(player, newPosicion);
                }
                else
                    shiftText += $"\t{roll} + {roll2}: S{player.Position}";
            }
            else
            {
                newPosicion = player.Position;
                IRules action = this.board.GetBoardAction(newPosicion);
                action.ValidateRule(player);
                shiftText += $"\t/ : S{player.Position}\t";
            }
        }

        private void validateTurn(Player player, int newPosicion)
        {
            while (player.Position != newPosicion)
            {
                print.Print($"entra a la validacion");
                newPosicion = player.Position;
                IRules action = this.board.GetBoardAction(player.Position);
                action.ValidateRule(player);
                if (player.Position != newPosicion)
                {
                    shiftText += $" -> S{player.Position}";
                    newPosicion = player.Position;
                }
            }
        }

        public int CheckPosition(int position)
        {
            return (position > board.FinalPosition()) ? board.FinalPosition() - (position - board.FinalPosition()) : position;
        }
    }
}