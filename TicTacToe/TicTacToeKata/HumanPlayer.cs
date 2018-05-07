namespace TicTacToeKata
{
    public class HumanPlayer
    {
        
        private readonly Symbol _symbol;
        private readonly IInputChecker _inputChecker;

        public HumanPlayer(Symbol symbol, IInputChecker inputChecker)
        {
            _inputChecker = inputChecker;
            _symbol = symbol;
        }


        public void ShouldMoveHumanPlayer(GameBoard gameBoard, string userInput)
        {
            _inputChecker.ValidateInputPositionOnBoard(userInput, gameBoard);
            var position = _inputChecker.ConvertUserInputToInt(gameBoard, userInput);
            gameBoard.Board[position] = _symbol;
        }
    }
}