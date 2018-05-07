using System.Collections.Generic;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class BoardSolverShould
    {
        private readonly GameBoard _gameBoard;
        private readonly HumanPlayer _humanPlayer;

        public BoardSolverShould()
        {
            _gameBoard = new GameBoard();
            _humanPlayer = new HumanPlayer(Symbol.Cross, new InputChecker());
        }
        
        [Fact]
        public void GivenWinningColoumnConditionReturnWonCondition()
        {
            var expected = new List<int>{0,3,6};
            var userInput1 = "0,0";
            _humanPlayer.ShouldMoveHumanPlayer(_gameBoard,userInput1);
            var userInput = "0,1";
            _humanPlayer.ShouldMoveHumanPlayer(_gameBoard,userInput);
            var userInput2 = "0,2";
            _humanPlayer.ShouldMoveHumanPlayer(_gameBoard,userInput2);
            
            var result = _gameBoard.GetPlayerInputIndexes(Symbol.Cross);
            
            Assert.Equal(expected,result);
        }
    }
}