using GameOfGoose.Business.Print;

namespace GameOfGoose.Business.Rules
{
    public class Goose : IRules
    {
        public int Position { get; set; }

        private readonly ILogger _logger;

        public Goose(ILogger logger, int position)
        {
            Position = position;
            _logger = logger;
        }

        public void ValidateRule(Player player)
        {
            _logger.Log($"\t{player.Name} hit a goose in square {Position}!");
            int valueToMove = player.ValueDice * (player.InReverse ? -1 : 1);
            
            player.Move([ valueToMove ]);
        }
    }
}