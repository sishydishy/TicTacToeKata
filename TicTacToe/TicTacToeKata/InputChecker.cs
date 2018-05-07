using System;

namespace TicTacToeKata
{
    public class InputChecker
    {
        private readonly GameBoard _gameBoard;

        public InputChecker()
        {
            _gameBoard = new GameBoard();
        }


        private int ConvertUserInputToInt(string userInput)
        {
            
            var splitInput = userInput.Split(",");

            var coordinateX = int.Parse(splitInput[0]);
            var coordinateY = int.Parse(splitInput[1]);


            var positionOnBoard = coordinateX + _gameBoard._boardHeight * coordinateY;
            return positionOnBoard;

        }

        public void ValidateInputPositionOnBoard(string userInput)
        {
            var position = ConvertUserInputToInt(userInput);
            ValidatePosition(position);
            if (_gameBoard.Board[position] != Symbol.Empty)
            {
                throw new ArgumentException("Position is taken by token!");
            }

            
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
            return positionOnBoard < _gameBoard._positionOnBoardLowerBound || positionOnBoard > _gameBoard._positionOnBoardUpperBound;
        }

    }
}