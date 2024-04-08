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
        private String someoneInWelling;

        public Game(IBoard board, Player[] players, IDice dice, IPrint print)
        {
            this.players = players;
            this.dice = dice;
            this.board = board;
            this.print = print;
            this.someoneInWelling = string.Empty;
        }

        public void Play()
        {
            shift = 0;
            headText = string.Empty;

            print.Print("\t\tGAME OF GOOSE");

            while (true)
            {
                shift++;
                shiftText = string.Empty;

                foreach (var player in players)
                {
                    if (shift == 1)
                        headText += $"\t{player.Name}\t";

                    //Well position  validation
                    if (player.InWell && ((this.someoneInWelling != string.Empty) && (this.someoneInWelling != player.Name)))
                    {
                        this.someoneInWelling = player.Name;
                        player.SetTurnsToSkip(0);
                    }

                    Turn(player);

                    //Well position validation
                    if (player.InWell)
                        this.someoneInWelling = player.Name;

                    if (player.Position == board.FinalPosition())
                    {
                        print.Print($"TURN {shift}");
                        print.Print($"{shiftText}");
                        print.Print($"{player.Name} WINNER!!!");
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

            if (shift == 1)// Shift 1 game flow
            {
                player.MoveTo(newPosicion);

                IRules actionFirst = new FirstThrow(roll, roll2);
                actionFirst.ValidateRule(player);
                shiftText += $"\t{roll} + {roll2}: S{player.Position}";
            }
            else if (player.TurnsToSkip == 0) // Normal game flow
            {
                //checking that the position is not bigger than 63
                newPosicion = CheckPosition(newPosicion);
                //moving the position of the player
                player.MoveTo(newPosicion);

                //Getting the rule of the box position
                IRules action = this.board.GetBoardAction(newPosicion);

                //trigger the action in the box position
                action.ValidateRule(player);//TODO Validate 63 position

                //Printing
                if (player.Position != newPosicion)
                {
                    shiftText += $"\t{roll} + {roll2}: S{player.LastPosition} -> S{player.Position}";

                    //validating if the position change with the validation of the box
                    if (player.TurnsToSkip != 0)
                        //Validating the new position
                        validateTurn(player, newPosicion);
                }
                else
                    shiftText += $"\t{roll} + {roll2}: S{player.Position}";
            }
            else// Flow with Turn Skiped
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