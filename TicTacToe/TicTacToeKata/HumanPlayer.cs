namespace TicTacToeKata
{
    public class HumanPlayer
    {
        private readonly GameBoard _gameBoard;
        private readonly Symbol _symbol;

        public HumanPlayer(Symbol symbol)
        {
            _gameBoard = new GameBoard();
            _symbol = symbol;
        }
        public void ShouldMoveHumanPlayer1(string userInput,Symbol symbol)
        {
            _gameBoard.CheckInputPositionOnBoard(userInput);
            var position = _gameBoard.ConvertUserInputToInt(userInput);
            _gameBoard.Board[position] = symbol;
            
        }

        public void ShouldMoveHumanPlayer(GameBoard gameBoard, string userInput)
        {
            gameBoard.CheckInputPositionOnBoard(userInput);
            var position = gameBoard.ConvertUserInputToInt(userInput);
            gameBoard.Board[position] = _symbol;
        }
    }
}