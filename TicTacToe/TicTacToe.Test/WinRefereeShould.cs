using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class WinRefereeShould
    {
        private readonly GameBoard _gameBoard;

        public WinRefereeShould()
        {
            _gameBoard = new GameBoard();
        }
        
        [Fact]
        public void GivenPlayerInputWhenNoWinConditionIsMetThenReturnAsEmpty()
        {
            var userInput1 = "2,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1, Symbol.Cross);
            var userInput = "1,1";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Nought);
            var userInput2 = "0,2";
            _gameBoard.ShouldMoveHumanPlayer(userInput2, Symbol.Nought);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Nought);

            Assert.Equal('.', (char) result);
        }
        
        [Fact]
        public void GivenPlayerXInputWhenWinConditionIsMetThenReturnAsXHasWon()
        {
            var userInput1 = "2,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1, Symbol.Cross);
            var userInput = "1,1";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Cross);
            var userInput2 = "0,2";
            _gameBoard.ShouldMoveHumanPlayer(userInput2, Symbol.Cross);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Cross);

            Assert.Equal('X', (char) result);
        }
        
        [Fact]
        public void GivenPlayerOInputWhenWinConditionIsMetThenReturnAsOHasWon()
        {
            var userInput1 = "2,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1, Symbol.Nought);
            var userInput = "1,1";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Nought);
            var userInput2 = "0,2";
            _gameBoard.ShouldMoveHumanPlayer(userInput2, Symbol.Nought);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Nought);

            Assert.Equal('O', (char) result);
        }
    }
}