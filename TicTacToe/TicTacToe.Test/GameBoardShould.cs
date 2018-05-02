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
        public void AllowHumanPlayerMove()
        {
            string userInput = "0,0";
            
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Cross);
            
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
            var expected = 
                @"-----|-----|-----
(0,0)|(1,0)|(2,0)
-----|-----|-----
(0,1)|(1,1)|(2,1)
-----|-----|-----
(0,2)|(1,2)|(2,2)
-----|-----|-----
";   
            var render = new Renderer();
            var result = render.DrawStartingBoard(_gameBoard);
            
            Assert.Equal(expected,result);
        }


        [Fact]
        public void GivenTokenThenRenderCellWithToken()
        {
            var expected =
                @"-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
";
            var render = new Renderer();
            var result = render.DrawTokenBoard(_gameBoard);
            
            Assert.Equal(expected,result);
        }
        
        [Fact]
        public void GivenHumanMoveThenRenderCellWithToken()
        {
            var userInput = "0,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Cross);
            var expected =
                @"-----|-----|-----
  X  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
";
            var render = new Renderer();
            var result = render.DrawTokenBoard(_gameBoard);
            Assert.Equal(expected,result);
        }

        [Fact]
        public void ThrowArgumentExceptionForPositionTakenByToken()
        {
            var userInput1 = "0,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1,Symbol.Nought);
            var userInput = "0,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput,Symbol.Cross);
            
            Assert.Throws<ArgumentException>(() => _gameBoard.CheckInputPositionOnBoard(userInput));
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

        [Fact]
        public void GivenPlayerXInputWhenWinConditionIsMetThenReturnAsWon()
        {
            var userInput1 = "2,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput1, Symbol.Nought);
            var userInput = "1,1";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Nought);
            var userInput2 = "0,2";
            _gameBoard.ShouldMoveHumanPlayer(userInput2, Symbol.Nought);
            var winReferee = new WinReferee();
            var result = winReferee.WinChecker(_gameBoard, Symbol.Nought);

            Assert.Equal('X', result);
        }
        
    }
}