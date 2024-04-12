using GameOfGoose.Board;
using GameOfGoose.Dice;
using GameOfGoose.Factories;
using GameOfGoose.Print;
using Moq;

namespace GameOfGoose.Tests.Rules
{
    public class RuleWellTest
    {
        [Fact]
        public void IfPlayerEntersWell_ThenPlayerHasToSkip_Indefenitely()
        {
            //Arrange
            Player player = new Player("N");
            IRules ruleWell = new RuleFactory().CreateRule(39, RuleType.Well);

            //Act
            ruleWell.ValidateRule(player);

            //Assert
            Assert.True(player.InWell);
        }

        [Fact]
        public void IfPlayerIsStuckInWell_ThenPlayerCannotMove()
        {
            //Arrange
            var players = new[]
             {
                new Player("TestPlayer 1"),
                new Player("TestPlayer 2")
            };
            var mockDice = new Mock<IDice>();
            var mockPrint = new Mock<IPrint>();
            BoardGoose board = BoardGoose.Instance;
            int lastPosition;
            int[] diceRoll = [1, 1];
            var game = new Game(players, mockDice.Object, mockPrint.Object, new PrintFormat());

            // Act
            players[0].MoveTo(29);
            players[0].Move(diceRoll);
            lastPosition = players[0].Position;
            game.PlayTurn(players[0], diceRoll);

            // Assert
            Assert.True(players[0].InWell);
            Assert.Equal(lastPosition, players[0].Position);
        }

        [Fact]
        public void IfPlayerIsStuckInWell_ThenPlayerCannotMove_UntilAnotherPlayersEnters()
        {
            // Arrange
            var players = new[]
            {
                new Player("TestPlayer 1"),
                new Player("TestPlayer 2")
            };
            int[] diceRoll = [1, 1];

            // Act
            players[0].MoveTo(29);
            players[0].Move(diceRoll);

            // Assert
            Assert.True(players[0].InWell);

            // Act
            players[1].MoveTo(29);
            players[1].Move(diceRoll);
            players[0].ValidateWellExit(players);

            // Assert
            Assert.True(players[1].InWell);
            Assert.False(players[0].InWell);
        }
    }
}