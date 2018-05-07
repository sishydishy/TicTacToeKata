using System.Collections.Generic;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class HumanPlayerShould
    {
        private readonly GameBoard _gameBoard;
        private readonly HumanPlayer _humanPlayer;

        public HumanPlayerShould()
        {
            _gameBoard = new GameBoard();
            _humanPlayer = new HumanPlayer(Symbol.Cross);
        }
        
        
                
        [Fact]
        public void AllowHumanPlayerMove()
        {
            string userInput = "0,0";
            
            _humanPlayer.ShouldMoveHumanPlayer(_gameBoard, userInput);

            var expected = _gameBoard.Board = new List<Symbol>
            {
                Symbol.Cross,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty,
                Symbol.Empty
            };

            Assert.Equal(expected, _gameBoard.Board);
        }
    }
}