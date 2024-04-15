using GameOfGoose.Business.Dice;

namespace GameOfGoose.Tests;

public class DiceTest
{
    [Fact]
    public void DiceMovesGenerateValuesBetween_1_6()
    {
        //Arrange
        int minValue = 1;
        int maxValue = 6;
        int rollValue;
        Dice dice = new();

        //Act
        rollValue = dice.Roll();

        //Assert
        Assert.InRange(rollValue, minValue, maxValue);
    }
}