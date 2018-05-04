namespace TicTacToeKata
{
    public class HumanPlayer
    {
        private readonly GameBoard _gameBoard;

        public HumanPlayer()
        {
            _gameBoard = new GameBoard();
        }
        public void ShouldMoveHumanPlayer(string userInput,Symbol symbol)
        {
            _gameBoard.CheckInputPositionOnBoard(userInput);
            var position = _gameBoard.ConvertUserInputToInt(userInput);
            _gameBoard.Board[position] = symbol;
            
        }
    }
}