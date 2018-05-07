using System;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class InputCheckerShould
    {
        private readonly GameBoard _gameBoard;
        private readonly HumanPlayer _humanPlayerOne;
        private readonly HumanPlayer _humanPlayerTwo;
        private readonly InputChecker _inputChecker;


        public InputCheckerShould()
        {
            _gameBoard = new GameBoard();
            _humanPlayerOne = new HumanPlayer(Symbol.Nought, new InputChecker());
            _humanPlayerTwo = new HumanPlayer(Symbol.Cross, new InputChecker());
            _inputChecker = new InputChecker();
        }

        [Fact]
        public void ThrowArgumentExceptionForLargeInputPositions()
        {
            var userInput = "3,3";


            Assert.Throws<ArgumentException>(() => _inputChecker.ValidateInputPositionOnBoard(userInput, _gameBoard));
        }
        
        [Fact]
        public void ThrowArgumentExceptionForNegativeInputPositions()
        {
            var userInput = "-3,-4";


            Assert.Throws<ArgumentException>(() => _inputChecker.ValidateInputPositionOnBoard( userInput, _gameBoard));
        }
        
        [Fact]
        public void GivenUserInputStringThenReturnIndexForBoardList()
        {
            string userInput = "0,1";

            var expected = 3;

            var result = _inputChecker.ConvertUserInputToInt(_gameBoard, userInput);
            
            Assert.Equal(expected,result);
        }
        
        [Fact]
        public void ThrowArgumentExceptionForPositionTakenByToken()
        {
            var userInput1 = "0,0";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard,userInput1);
            var userInput = "0,1";
            _humanPlayerTwo.ShouldMoveHumanPlayer(_gameBoard,userInput);
            
            Assert.Throws<ArgumentException>(() => _inputChecker.ValidateInputPositionOnBoard(userInput, _gameBoard));
        }
    }
}