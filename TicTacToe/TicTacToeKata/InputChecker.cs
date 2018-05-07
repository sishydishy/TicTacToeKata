using System;

namespace TicTacToeKata
{
    public class InputChecker : IInputChecker
    {


        public int ConvertUserInputToInt(GameBoard gameBoard, string userInput)
        {
            
            var splitInput = userInput.Split(",");

            var coordinateX = int.Parse(splitInput[0]);
            var coordinateY = int.Parse(splitInput[1]);


            var positionOnBoard = coordinateX + gameBoard._boardHeight * coordinateY;
            return positionOnBoard;

        }

        public void ValidateInputPositionOnBoard(string userInput, GameBoard gameBoard)
        {
            var position = ConvertUserInputToInt(gameBoard,userInput);
            ValidatePosition(position, gameBoard);
            
            
        }

        private bool IsTokenAtPositionOnBoardNotEmpty(GameBoard gameBoard,int position)
        {
            return gameBoard.Board[position] != Symbol.Empty;
        }

        private void ValidatePosition(int positionOnBoard, GameBoard gameBoard)
        {
            if (IsPositionOutOfBounds(positionOnBoard, gameBoard))
            {
                throw new ArgumentException("Index is out of bounds");
            }
            
            if (IsTokenAtPositionOnBoardNotEmpty(gameBoard,positionOnBoard))
            {
                throw new ArgumentException("Position is taken by token!");
            }

        }

        private bool IsPositionOutOfBounds(int positionOnBoard, GameBoard gameBoard)
        {
            return positionOnBoard < gameBoard._positionOnBoardLowerBound || positionOnBoard > gameBoard._positionOnBoardUpperBound;
        }
        
        

    }
}