namespace GameOfGoose.Rules
{
    public class Goose : IRules
    {
        public int Position { get; set; }

        public Goose(int position)
        {
            Position = position;
        }

        public void ValidateRule(Player player)
        {
            int valueToMove = player.ValueDice * (player.InReverse ? -1 : 1);
            /*if (player.InReverse)
            {
                valueToMove = Position - player.ValueDice;
            }
            else
            {
                valueToMove = (player.Position - player.LastPosition) + Position;
            }
            player.MoveTo(valueToMove);*/
            player.Move(new int[] { valueToMove });
        }
    }
}