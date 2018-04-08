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
            var gameBoard = new GameBoard();
            var expected = Convert.ToInt32(gameBoard.oard[0]);

            
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

        [Fact]
        public void ThrowArgumentExceptionForLargeInputPositions()
        {
            var userInput = 9;
            
            var gameBoard = new GameBoard();

            Assert.Throws<ArgumentException>(() => gameBoard.Position(userInput));
        }
        
        [Fact]
        public void ThrowArgumentExceptionForNegativeInputPositions()
        {
            var userInput = -1;
            
            var gameBoard = new GameBoard();

            Assert.Throws<ArgumentException>(() => gameBoard.Position(userInput));
        }
    }
}