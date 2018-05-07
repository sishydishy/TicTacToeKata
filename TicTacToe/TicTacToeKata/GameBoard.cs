using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToeKata
{
    public class GameBoard
    {
        public readonly int _boardHeight;
        public readonly int _boardWidth;
      
        public readonly int _positionOnBoardUpperBound;
        public readonly int _positionOnBoardLowerBound = 0;



        public List<Symbol> Board; 


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
            
            Board = Enumerable.Repeat((Symbol) '.', area).ToList();
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
                throw new ArgumentException("Index is out of bounds");
            }
        }

        private bool IsPositionOutOfBounds(int positionOnBoard)
        {
            return positionOnBoard < _positionOnBoardLowerBound || positionOnBoard > _positionOnBoardUpperBound;
        }





        public void ShouldMoveHumanPlayer(string userInput,Symbol symbol)
        {
            CheckInputPositionOnBoard(userInput);
            var position = ConvertUserInputToInt(userInput);
            Board[position] = symbol;
            
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
             ValidatePosition(position);
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