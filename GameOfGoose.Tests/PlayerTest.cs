using GameOfGoose.Board;

namespace GameOfGoose.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void IfPlayerMoveToWith_6_ThenPlayerPossitionHaveToBe_6()
        {
            //Arrange
            int valueToMove = 6;
            Player player = new Player("N");

            //Act
            player.MoveTo(valueToMove);

            //Assert
            Assert.Equal(6, player.Position);
        }

        [Fact]
        public void IfPlayerSkipTurnGet_6_ThenTurnsToSkipHaveToBe_6()
        {
            //Arrange
            int valueToMove = 6;
            Player player = new Player("N");

            //Act
            player.SetTurnsToSkip(valueToMove);

            //Assert
            Assert.Equal(6, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerLandsOnBridge_ThenHeShouldMoveToSquare12()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            BoardGoose board = BoardGoose.Instance;
            int[] diceRoll = { 3, 3 };

            //Act
            player.Move(diceRoll);

            //Assert
            Assert.Equal(12, player.Position);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerLandsOnGoose_ThenHeShouldMoveTheDiceX2()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 5 };

            //Act
            player.Move(diceRoll);

            //Assert
            Assert.Equal(12, player.Position);
            Assert.Equal(6, player.LastPosition);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerMakesTheFirstTurnLandsOnGoose_ThenHeShouldMoveTheDiceX2()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 4 };

            //Act
            player.Move(diceRoll);

            //Assert
            Assert.Equal(10, player.Position);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerLandsOnGooseInReverse_ThenHeShouldMoveTheValueDiceButInReverse()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 5, 5 };

            //Act
            player.MoveTo(57);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(49, player.Position);
            Assert.Equal(0, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerLandsOnInn_ThenHeShouldSkip1Trun()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 8 };

            //Act
            player.MoveTo(10);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(19, player.Position);
            Assert.Equal(1, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerLandsOnPrison_ThenHeShouldSkip3Turns()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 1 };

            //Act
            player.MoveTo(50);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(52, player.Position);
            Assert.Equal(3, player.TurnsToSkip);
        }

        [Fact]
        public void IfPlayerEnterMaze_ThenPlayerHasToMoveToSquare_39()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 1 };

            //Act
            player.MoveTo(40);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void IfPlayerEnterInDeath_ThenPlayerHasToMoveToSquare_0()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 4, 4 };

            //Act
            player.MoveTo(50);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(0, player.Position);
        }

        [Fact]
        public void IfPlayerEnterInEnd_ThenPlayerWinsTheGame()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 2 };

            //Act
            player.MoveTo(60);
            player.Move(diceRoll);

            //Assert
            Assert.True(player.Winner);
        }

        [Fact]
        public void IfPlayerLandsOnGoose_ThenHeShouldMoveTheDiceX2_AndCheckTheNewPosition()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 1, 3 };

            //Act
            player.MoveTo(1);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(13, player.Position);
        }

        [Fact]
        public void IfPlayerOverStepTheLastPositionAndInReverseGotADeath_ThenHeShouldMoveToTheStart()
        {
            //Arrange
            BoardGoose boardGame = BoardGoose.Instance;
            Player player = new Player("TestPlayer");
            int[] diceRoll = { 6, 5 };

            //Act
            player.MoveTo(57);
            player.Move(diceRoll);

            //Assert
            Assert.Equal(0, player.Position);
        }
    }
}