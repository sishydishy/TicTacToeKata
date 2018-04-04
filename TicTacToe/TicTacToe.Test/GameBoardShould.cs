using System;
using System.Collections.Generic;
using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class GameBoardShould
    {
        [Fact]
        public void CreateEmptyGameBoard()
        {
            var expected = new[]
            {
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty
            };

            var gameBoard = new GameBoard();
            Assert.Equal(expected, gameBoard.Board);
        }

        [Fact]
        public void ReturnPosiiton()
        {
            var expected = 0;

            var gameBoard = new GameBoard();
            var position = gameBoard.Position(expected);

            Assert.Equal(new Tuple<int, int>(0, 0), position);
        }

        [Fact]
        public void AddSymbol()
        {
            var expected = new[]
            {
                Symbol.Cross, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty
            };

            var gameBoard = new GameBoard();
            gameBoard.AddSymbol(Symbol.Cross, 0, 0);

            Assert.Equal(expected, gameBoard.Board);
        }
    }
}