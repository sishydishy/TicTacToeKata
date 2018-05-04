using System.Collections.Generic;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class BoardSolverShould
    {
        private readonly GameBoard _gameBoard;

        public BoardSolverShould()
        {
            _gameBoard = new GameBoard();
        }
        
        [Fact]
        public void GivenWinningColoumnConditionReturnWonCondition()
        {
            var expected = new List<int>{0,3,6};
            var userInput1 = "0,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1,Symbol.Cross);
            var userInput = "0,1";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Cross);
            var userInput2 = "0,2";
            _gameBoard.ShouldMoveHumanPlayer(userInput2, Symbol.Cross);
            
            var result = _gameBoard.GetPlayerInputIndexes(Symbol.Cross);
            
            Assert.Equal(expected,result);
        }
    }
}