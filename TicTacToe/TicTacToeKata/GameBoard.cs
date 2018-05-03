using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToeKata
{
    public class GameBoard
    {
        private readonly int _boardHeight;
        public readonly int _boardWidth;
      
        private readonly int _positionOnBoardUpperBound;
        private const int POSITION_ON_BOARD_LOWER_BOUND = 0;

        private List<Symbol> _board;

        public IReadOnlyList<Symbol> Board => _board;

        public GameBoard()
        {
            _boardHeight = 3;
            _boardWidth = 3;
            var area = _boardHeight * _boardWidth;
            _positionOnBoardUpperBound = area - 1;
            
            Create(area);
        }

        private void Create(int area)
        { 
            
            _board = Enumerable.Repeat((Symbol) '.', area).ToList();
        }

        public Point Position(int positionOnBoard)
        {
            ValidatePosition(positionOnBoard);
            var x = positionOnBoard % _boardWidth;
            var y = positionOnBoard / _boardWidth;


            return new Point
            {
                X = x,
                Y = y
            };
        }

        private void ValidatePosition(int positionOnBoard)
        {
            if (IsPositionOutOfBounds(positionOnBoard))
            {
                throw new ArgumentException();
            }
        }

        private bool IsPositionOutOfBounds(int positionOnBoard)
        {
            return positionOnBoard < POSITION_ON_BOARD_LOWER_BOUND || positionOnBoard > _positionOnBoardUpperBound;
        }




        public void ShouldMoveHumanPlayer(string userInput,Symbol symbol)
        {
            CheckInputPositionOnBoard(userInput);
            var position = ConvertUserInputToInt(userInput);
            _board[position] = symbol;
            
        }

        public int ConvertUserInputToInt(string userInput)
        {
            
            var splitInput = userInput.Split(",");

            var coordinateX = Int32.Parse(splitInput[0]);
            var coordinateY = Int32.Parse(splitInput[1]);


            var positionOnBoard = coordinateX + _boardHeight * coordinateY;
            return positionOnBoard;

        }

        public void CheckInputPositionOnBoard(string userInput)
        {
            var position = ConvertUserInputToInt(userInput);
            if (Board[position] != Symbol.Empty)
            {
                throw new ArgumentException("Position is taken by token!");
            }

            
        }

        public List<int> GetPlayerInputIndexes(Symbol symbol)
        {
            var playerInputIndexes = new List<int>();
            for (int index = 0; index < Board.Count; index++)
            {
                if (Board[index] == symbol)
                {
                    playerInputIndexes.Add(index);                    
                }
                
            }

            return playerInputIndexes;
        }
    }
}