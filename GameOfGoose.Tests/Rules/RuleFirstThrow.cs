using GameOfGoose.Business;
using GameOfGoose.Business.Print;
using GameOfGoose.Business.Rules;
using Moq;

namespace GameOfGoose.Tests.Rules;

public class RuleFirstThrowTest
{
    [Theory]
    [InlineData(5, 4)]
    [InlineData(4, 5)]
    public void IfFirstThrowAndDiceContain4And5_ThenPlayerHaveToMoveTo26(int dice1, int dice2)
    {
        //Arrange
        int[] dices = [dice1, dice2];
        Player player = TestHelper.GetMockPlayer();
        var mockPrint = new Mock<ILogger>();
        var ruleFirstThrow = new FirstThrow(mockPrint.Object, dices);

        //Act
        player.MoveTo(dices.Sum());
        ruleFirstThrow.ValidateRule(player);

        //Assert
        Assert.Equal(26, player.Position);
    }

    [Theory]
    [InlineData(6, 3)]
    [InlineData(3, 6)]
    public void IfFirstThrowAndDiceContain3And6_ThenPlayerHaveToMoveTo53(int dice1, int dice2)
    {
        //Arrange
        int[] dices = [dice1, dice2];
        Player player = TestHelper.GetMockPlayer();
        var mockPrint = new Mock<ILogger>();
        var ruleFirstThrow = new FirstThrow(mockPrint.Object, dices);

        //Act
        player.MoveTo(dices.Sum());
        ruleFirstThrow.ValidateRule(player);

        //Assert
        Assert.Equal(53, player.Position);
    }
}