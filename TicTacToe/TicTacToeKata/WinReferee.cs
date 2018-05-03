using System;
using System.Collections.Generic;
using System.Linq;


namespace TicTacToeKata
{
    public class WinReferee
    {
        private readonly List<List<int>> _listOfWinningConditions;
        
        public WinReferee()
        {
            _listOfWinningConditions = new WinnerConditions().ListOfWinnerConditions;
            
        }
         
        
        public Symbol WinChecker(GameBoard gameBoard, Symbol symbol)
        {
            var playerIndexesOfBoard = gameBoard.GetPlayerInputIndexes(symbol);
            var checkWinningConditionsAgainstInput =
                _listOfWinningConditions.Any(winCondition => !winCondition.Except(playerIndexesOfBoard).Any());
            return checkWinningConditionsAgainstInput ? symbol : Symbol.Empty;

        }

        public void AnnounceWinner(Symbol winner)
        {
            if (winner != Symbol.Empty)
            {
                Console.WriteLine($"{(char) winner} IS THE WINNER");
            }
        }

        public void AnnounceDraw(Symbol winner, IReadOnlyList<Symbol> board)
        {
            
            if (winner == Symbol.Empty && board.All(o => o != Symbol.Empty))
            {
                Console.WriteLine("IT'S A DRAW");
            }
        }
    }
}