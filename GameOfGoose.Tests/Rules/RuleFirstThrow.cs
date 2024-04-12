using GameOfGoose.Rules;

namespace GameOfGoose.Tests.Rules
{
    public class RuleFirstThrowTest
    {
        [Fact]
        public void IfIsTheFirstTrowAndDice1Is_5_and_Dice2Is_4_ThenPlayerHaveToMoveTo_26()
        {
            //Arrange
            int[] dices = { 5, 4 };
            Player player = new Player("N");
            var ruleFirstThrow = new FirstThrow(dices);

            //Act
            player.MoveTo(dices.Sum());
            ruleFirstThrow.ValidateRule(player);

            //Assert
            Assert.Equal(26, player.Position);
        }

        [Fact]
        public void IfIsTheFirstTrowAndDice1Is_4_and_Dice2Is_5_ThenPlayerHaveToMoveTo_26()
        {
            //Arrange
            int[] dices = { 4, 5 };
            Player player = new Player("N");
            var ruleFirstThrow = new FirstThrow(dices);

            //Act
            player.MoveTo(dices.Sum());
            ruleFirstThrow.ValidateRule(player);

            //Assert
            Assert.Equal(26, player.Position);
        }

        [Fact]
        public void IfIsTheFirstTrowAndDice1Is_6_and_Dice2Is_3_ThenPlayerHaveToMoveTo_53()
        {
            //Arrange
            int[] dices = { 6, 3 };
            Player player = new Player("N");
            var ruleFirstThrow = new FirstThrow(dices);

            //Act
            player.MoveTo(dices.Sum());
            ruleFirstThrow.ValidateRule(player);

            //Assert
            Assert.Equal(53, player.Position);
        }

        [Fact]
        public void IfIsTheFirstTrowAndDice1Is_3_and_Dice2Is_6_ThenPlayerHaveToMoveTo_53()
        {
            //Arrange
            int[] dices = { 3, 6 };
            Player player = new Player("N");
            var ruleFirstThrow = new FirstThrow(dices);

            //Act
            player.MoveTo(dices.Sum());
            ruleFirstThrow.ValidateRule(player);

            //Assert
            Assert.Equal(53, player.Position);
        }
    }
}