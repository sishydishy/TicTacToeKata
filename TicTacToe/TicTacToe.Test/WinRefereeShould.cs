using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class WinRefereeShould
    {
        private readonly GameBoard _gameBoard;
        private readonly HumanPlayer _humanPlayerOne;
        private readonly HumanPlayer _humanPlayerTwo;

        public WinRefereeShould()
        {
            _gameBoard = new GameBoard();
            _humanPlayerOne = new HumanPlayer(Symbol.Nought, new InputChecker());
            _humanPlayerTwo = new HumanPlayer(Symbol.Cross, new InputChecker());
        }
        
        [Fact]
        public void GivenPlayerInputWhenNoWinConditionIsMetThenReturnAsEmpty()
        {
            var userInput1 = "2,0";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard,userInput1);
            var userInput = "1,1";
            _humanPlayerTwo.ShouldMoveHumanPlayer(_gameBoard, userInput);
            var userInput2 = "0,2";
            _humanPlayerTwo.ShouldMoveHumanPlayer(_gameBoard, userInput2);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Nought);

            Assert.Equal('.', (char) result);
        }
        
        [Fact]
        public void GivenPlayerXInputWhenWinConditionIsMetThenReturnAsXHasWon()
        {
            var userInput1 = "2,0";
            _humanPlayerTwo.ShouldMoveHumanPlayer(_gameBoard, userInput1);
            var userInput = "1,1";
            _humanPlayerTwo.ShouldMoveHumanPlayer( _gameBoard, userInput);
            var userInput2 = "0,2";
            _humanPlayerTwo.ShouldMoveHumanPlayer( _gameBoard, userInput2);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Cross);

            Assert.Equal('X', (char) result);
        }
        
        [Fact]
        public void GivenPlayerOInputWhenWinConditionIsMetThenReturnAsOHasWon()
        {
            var userInput1 = "2,0";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard, userInput1);
            var userInput = "1,1";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard, userInput);
            var userInput2 = "0,2";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard, userInput2);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Nought);

            Assert.Equal('O', (char) result);
        }
    }
}