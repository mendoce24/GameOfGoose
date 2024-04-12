using GameOfGoose.Factories;
using GameOfGoose.Rules;

namespace GameOfGoose.Tests.Rules
{
    public class MoveToRulesTests
    {
        [Fact]
        public void IfPlayerLandsOnBridge_ThenHeShouldMoveToSquare12()
        {
            // Arrange
            Player player = new Player("N");
            IRules ruleBridge = new RuleFactory().CreateRule(6, RuleType.Bridge);

            // Act
            ruleBridge.ValidateRule(player);

            // Assert
            Assert.Equal(12, player.Position);
            Assert.NotEqual(6, player.Position); // Tip: Unhappy path is also worth testing
        }

        [Fact]
        public void IfPlayerEnterMaze_ThenPlayerHasToMoveToSquare_39()
        {
            //Arrange
            Player player = new Player("N");
            IRules ruleMaze = new Maze(42);

            //Act
            ruleMaze.ValidateRule(player);

            //Assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void IfPlayerEnterDeath_ThenPlayerHasToMoveToSquare_0()
        {
            //Arrange
            Player player = new Player("N");
            IRules ruleDeath = new Death(58);

            //Act
            ruleDeath.ValidateRule(player);

            //Assert
            Assert.Equal(0, player.Position);
        }
    }
}