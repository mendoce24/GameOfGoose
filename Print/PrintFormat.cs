namespace GameOfGoose.Print
{
    public class PrintFormat
    {
        public string NormalTurn(Player player, int[] dices)
        {
            return $" \t{dices[0]} + {dices[1]}:S{player.LastPosition}->S{player.Position}";
        }

        public string SkipedTurn()
        {
            return $"\t / \t";
        }

        public string HeaderGame(Player[] players)
        {
            string text = "\t\tGAME OF GOOSE\n";
            foreach (Player player in players)
            {
                text += $"\t{player.Name}\t";
            }
            return text;
        }

        public string WinnerGame(Player[] players)
        {
            string text = string.Empty;
            foreach (Player player in players)
            {
                if (player.Winner)
                {
                    text += $"\tWINNER!!! \t";
                }
                else
                {
                    text += $"\t\t";
                }
            }
            return text;
        }
    }
}