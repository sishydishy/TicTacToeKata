namespace TicTacToeKata
{
    public interface IInputChecker
    {
        int ConvertUserInputToInt(GameBoard gameBoard, string userInput);
        void ValidateInputPositionOnBoard(string userInput, GameBoard gameBoard);
    }
}