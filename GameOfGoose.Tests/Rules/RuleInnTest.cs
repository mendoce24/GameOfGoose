using GameOfGoose.Rules;

namespace GameOfGoose.Tests.Rules
{
    public class RuleInnTest
    {
        [Fact]
        public void IfSquareIs_19_ThenPlayerHaveToSkip_1_turn()
        {
            //Arrange
            int destination = 19;
            Player player = new Player("N");
            IRules ruleInn = new Inn(destination);

            //Act
            player.MoveTo(destination);
            ruleInn.ValidateRule(player);

            //Assert
            Assert.Equal(1, player.TurnsToSkip);
        }
    }
}