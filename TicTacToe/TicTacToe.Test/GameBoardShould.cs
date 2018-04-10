using System;
using System.Collections.Generic;
using System.Drawing;
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
            var expected = new Point
            {
                X = 0,
                Y = 0
            };


            var resultPosition = gameBoard.Position(0);

            Assert.Equal(expected, resultPosition);
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
            gameBoard.AddSymbol(Symbol.Cross, new Point
            {
                X = 0,
                Y = 0
            });

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

        [Fact]
        public void AllowHumanPlayerMove()
        {
            int userInput = 4;

            var expected = new[]
            {
                Symbol.Cross, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty
            };

            var gameBoard = new GameBoard();
            gameBoard.ShouldMoveHumanPlayer(userInput);

            Assert.Equal(expected, gameBoard.Board);
        }
    }
}