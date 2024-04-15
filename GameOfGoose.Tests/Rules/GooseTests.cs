using GameOfGoose.Business;

namespace GameOfGoose.Tests.Rules;

public class GooseTests
{
    [Fact]
    public void IfPlayerLandsOnGoose_ThenHeShouldMoveTheDiceX2()
    {
        //Arrange
        Player player = TestHelper.GetMockPlayer();
        int[] diceRoll = [1, 5];

        //Act
        player.Move(diceRoll);

        //Assert
        Assert.Equal(12, player.Position);
        Assert.Equal(6, player.LastPosition);
        Assert.Equal(0, player.TurnsToSkip);
    }

    [Fact]
    public void IfPlayerLandsOnGooseInReverse_ThenHeShouldMoveTheValueDiceButInReverse()
    {
        //Arrange
        Player player = TestHelper.GetMockPlayer();
        int[] diceRoll = [5, 5];

        //Act
        player.MoveTo(57);
        player.Move(diceRoll);

        //Assert
        Assert.Equal(49, player.Position);
        Assert.Equal(0, player.TurnsToSkip);
    }

    [Theory]
    [InlineData(new[] { 2, 2 }, 1, 13)]
    [InlineData(new[] { 3, 2 }, 40, 55)]
    public void PlayerCanHitAGooseMultipleTimes(int[] diceRoll, int startPosition, int expectedPosition)
    {
        // Arrange
        Player player = TestHelper.GetMockPlayer();
        player.MoveTo(startPosition);

        // Act
        player.Move(diceRoll);

        // Assert
        Assert.Equal(expectedPosition, player.Position);
    }

    [Theory]
    [InlineData(new[] { 3, 2 }, 62, 49)]
    public void IfPlayerIsMovingBackwards_AndHitsAGooseMultipleTimes_HeMustKeepMovingBackwards_UntilANonGooseIsHit(int[] diceRoll, int startPosition, int expectedPosition)
    {
        // Arrange
        Player player = TestHelper.GetMockPlayer();
        player.MoveTo(startPosition);

        // Act
        player.Move(diceRoll);

        // Assert
        Assert.Equal(expectedPosition, player.Position);
        Assert.False(player.InReverse);
    }
}