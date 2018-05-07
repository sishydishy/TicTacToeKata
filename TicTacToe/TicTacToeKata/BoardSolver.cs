using System.Collections.Generic;
using TicTacToeKata;

namespace TicTacToeKata
{
    public class BoardSolver
    {
        public List<int> GetPlayerInputIndexes(GameBoard gameBoard, Symbol symbol)
        {
            var playerInputIndexes = new List<int>();
            for (int index = 0; index < gameBoard.Board.Count; index++)
            {
                if (gameBoard.Board[index] == symbol)
                {
                    playerInputIndexes.Add(index);                    
                }
                
            }

            return playerInputIndexes;
        }
    }
}