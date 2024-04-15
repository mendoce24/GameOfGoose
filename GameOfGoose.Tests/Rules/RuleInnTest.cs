using GameOfGoose.Business;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Rules;

namespace GameOfGoose.Tests.Rules;

public class RuleInnTest
{
    [Fact]
    public void IfSquareIs_19_ThenPlayerHaveToSkip_1_turn()
    {
        //Arrange
        int destination = 19;
        Player player = TestHelper.GetMockPlayer();
        IRules ruleInn = TestHelper.GetRuleFactory().CreateRule(destination, RuleType.Inn);

        //Act
        player.MoveTo(destination);
        ruleInn.ValidateRule(player);

        //Assert
        Assert.Equal(1, player.TurnsToSkip);
    }
}