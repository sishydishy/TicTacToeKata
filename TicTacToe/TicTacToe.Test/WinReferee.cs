using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeKata;

namespace TicTacToe.Test
{
    public class WinReferee
    {
        private readonly List<List<int>> _listOfWinningConditions;
        
        public WinReferee()
        {
            _listOfWinningConditions = new WinnerConditions().ListOfWinnerConditions;
            
        }
         
        
        public string WinChecker(GameBoard gameBoard, char symbol)
        {
            var playerIndexesOfBoard = gameBoard.GetPlayerInputIndexes('X');
            var checkWinningConditionsAgainstInput =
                _listOfWinningConditions.Any(winCondition => !winCondition.Except(playerIndexesOfBoard).Any());
            return checkWinningConditionsAgainstInput ? symbol.ToString() : "";

        }
    }
}