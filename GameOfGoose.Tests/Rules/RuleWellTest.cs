using GameOfGoose.Business;
using GameOfGoose.Business.Board;
using GameOfGoose.Business.Dice;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Print;
using GameOfGoose.Business.Rules;
using Moq;

namespace GameOfGoose.Tests.Rules;

public class RuleWellTest
{
    [Fact]
    public void IfPlayerEntersWell_ThenPlayerHasToSkip_Indefenitely()
    {
        //Arrange
        Player player = TestHelper.GetMockPlayer();
        IRules ruleWell = TestHelper.GetRuleFactory().CreateRule(39, RuleType.Well);

        //Act
        ruleWell.ValidateRule(player);

        //Assert
        Assert.True(player.InWell);
    }

    [Fact]
    public void IfPlayerIsStuckInWell_ThenPlayerCannotMove()
    {
        //Arrange
        Player player = TestHelper.GetMockPlayer();
        var mockDice = new Mock<IDice>();
        var mockPlayerFactory = new Mock<IPlayerFactory>();
        var board = new BoardGoose(TestHelper.GetRuleFactory());
        IPlayerFactory factory = new PlayerFactory(board);
        mockDice.Setup(x => x.Roll()).Returns(4);

        var mockPrint = new Mock<ILogger>();
        int lastPosition;
        int[] diceRoll = [1, 1];
        var game = new Game(mockDice.Object, mockPrint.Object, factory);

        // Act
        player.MoveTo(29);
        player.Move(diceRoll);
        lastPosition = player.Position;
        game.PlayTurn(player, diceRoll);

        // Assert
        Assert.True(player.InWell);
        Assert.Equal(lastPosition, player.Position);
    }

    [Fact]
    public void IfPlayerIsStuckInWell_ThenPlayerCannotMove_UntilAnotherPlayersEnters()
    {
        // Arrange
        Player[] players = [TestHelper.GetMockPlayer($"Player 1"), TestHelper.GetMockPlayer($"Player 2")];
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