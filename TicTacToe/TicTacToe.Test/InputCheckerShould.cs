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

        public InputCheckerShould()
        {
            _gameBoard = new GameBoard();
            _humanPlayerOne = new HumanPlayer(Symbol.Nought);
            _humanPlayerTwo = new HumanPlayer(Symbol.Cross);
        }

        [Fact]
        public void ThrowArgumentExceptionForLargeInputPositions()
        {
            var userInput = 9;


            Assert.Throws<ArgumentException>(() => _gameBoard.Position(userInput));
        }
        
        [Fact]
        public void ThrowArgumentExceptionForNegativeInputPositions()
        {
            var userInput = -1;


            Assert.Throws<ArgumentException>(() => _gameBoard.Position(userInput));
        }
        
        [Fact]
        public void GivenUserInputStringThenReturnIndexForBoardList()
        {
            string userInput = "0,1";

            var expected = 3;

            var result = _gameBoard.ConvertUserInputToInt(userInput);
            
            Assert.Equal(expected,result);
        }
        
        [Fact]
        public void ThrowArgumentExceptionForPositionTakenByToken()
        {
            var userInput1 = "0,0";
            _humanPlayerOne.ShouldMoveHumanPlayer(_gameBoard,userInput1);
            var userInput = "0,1";
            _humanPlayerTwo.ShouldMoveHumanPlayer(_gameBoard,userInput);
            
            Assert.Throws<ArgumentException>(() => _gameBoard.CheckInputPositionOnBoard(userInput1));
        }
    }
}