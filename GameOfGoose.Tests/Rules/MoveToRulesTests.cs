using GameOfGoose.Business;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Rules;

namespace GameOfGoose.Tests.Rules;

public class MoveToRulesTests
{
    [Fact]
    public void IfPlayerLandsOnBridge_ThenHeShouldMoveToSquare12()
    {
        // Arrange
        Player player = TestHelper.GetMockPlayer();
        IRules ruleBridge = TestHelper.GetRuleFactory().CreateRule(6, RuleType.Bridge);

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
        Player player = TestHelper.GetMockPlayer();
        IRules ruleMaze = TestHelper.GetRuleFactory().CreateRule(42, RuleType.Maze);

        //Act
        ruleMaze.ValidateRule(player);

        //Assert
        Assert.Equal(39, player.Position);
    }

    [Fact]
    public void IfPlayerEnterDeath_ThenPlayerHasToMoveToSquare_0()
    {
        //Arrange
        Player player = TestHelper.GetMockPlayer();
        IRules ruleDeath = TestHelper.GetRuleFactory().CreateRule(58, RuleType.Death);

        //Act
        ruleDeath.ValidateRule(player);

        //Assert
        Assert.Equal(0, player.Position);
    }
}