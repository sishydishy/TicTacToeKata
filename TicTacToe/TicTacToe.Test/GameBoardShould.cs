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
        public void ReturnPosiiton()
        {
            var expected = new Point
            {
                X = 0,
                Y = 0
            };


            var resultPosition = _gameBoard.Position(0);

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

            _gameBoard.AddSymbol(Symbol.Cross, new Point
            {
                X = 0,
                Y = 0
            });

            Assert.Equal(expected, _gameBoard.Board);
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
        public void AllowHumanPlayerMove()
        {
            const int userInput = 0;
            
            _gameBoard.ShouldMoveHumanPlayer(userInput);
            
            var expected = new[]
            {
                Symbol.Cross, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty,
                Symbol.Empty, Symbol.Empty, Symbol.Empty
            };

            Assert.Equal(expected, _gameBoard.Board);
        }



        [Fact]
        public void RenderStartingCoordinateBoard()
        {
            var expected = "(0,0)|(1,0)|(2,0)|";
            
            var render = new Renderer();
            var firstRow = render.DrawRow(_gameBoard);
            
            Assert.Equal(expected,firstRow);
        }
    }
}