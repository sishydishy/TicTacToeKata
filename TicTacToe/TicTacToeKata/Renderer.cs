using System;
using System.Text;

namespace TicTacToeKata
{
    public class Renderer
    {
        public void ShouldRenderStartingBoard(GameBoard gameBoard)
        {
            
            var board = new StringBuilder();
           

            board.Append("        |        |        " + Environment.NewLine); //Environment.NewLine allows a new line to be formed cross platform ^.^ very scalable
            var line_one = " {0} | {1} | {2} ";
            board.Append(string.Format(line_one, gameBoard.Position(0), gameBoard.Position(1), gameBoard.Position(2)) + Environment.NewLine);

            board.Append("________|________|________" + Environment.NewLine);
            board.Append("        |        |        " + Environment.NewLine);
            var line_two = " {0} | {1} | {2} ";
            board.Append(string.Format(line_two, gameBoard.Position(3), gameBoard.Position(4), gameBoard.Position(5)) + Environment.NewLine);
            board.Append("________|________|________" + Environment.NewLine);
            board.Append("        |        |        " + Environment.NewLine);
            var line_three = " {0} | {1} | {2} ";
            board.Append(string.Format(line_three, gameBoard.Position(6), gameBoard.Position(7), gameBoard.Position(8)) + Environment.NewLine);
            board.Append("        |        |        " + Environment.NewLine);
            Console.WriteLine(board.ToString());
            
        }

        public void ShouldRenderSelectingBoard()
        {
            
        }

        public void ShouldRenderHumanPlayerMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}