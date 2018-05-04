using System;
using System.Collections.Generic;
using System.Drawing;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class GameBoardShould
    {
        private readonly GameBoard _gameBoard;

        public GameBoardShould()
        {
            _gameBoard = new GameBoard();
        }

        [Fact]
        public void CreateEmptyGameBoard()
        {
            var expected = new[]
            {
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty
            };

            Assert.Equal(expected, _gameBoard.Board);
        }

        [Fact]
        public void ReturnPosition()
        {
            var expected = new Point
            {
                X = 0,
                Y = 0
            };


            var resultPosition = _gameBoard.Position(0);

            Assert.Equal(expected, resultPosition);
        }
    }
}