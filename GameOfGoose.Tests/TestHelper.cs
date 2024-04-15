using GameOfGoose.Business;
using GameOfGoose.Business.Board;
using GameOfGoose.Business.Factories;
using GameOfGoose.Business.Print;
using Moq;

namespace GameOfGoose.Tests;

public static class TestHelper
{
    public static Player GetMockPlayer(string name = "N")
    {
        var board = new BoardGoose(GetRuleFactory());
        IPlayerFactory factory = new PlayerFactory(board);

        return factory.Create(name);
    }

    public static RuleFactory GetRuleFactory()
    {
        Mock<ILogger> mockLogger = new();
        return new RuleFactory(mockLogger.Object);
    }
}