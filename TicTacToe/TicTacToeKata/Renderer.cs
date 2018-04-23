using System;
using System.Collections.Generic;
using System.Drawing;
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
            Console.WriteLine(board);
            
        }

        public string DrawRow(GameBoard gameBoard)
        {
            
            var coordinatefirst = gameBoard.Position(1);
            var coordinatetwo = gameBoard.Position(2);

            var coordinatezero = gameBoard.Position(0);
            var row = $"{drawCell(coordinatezero)}{drawCell(coordinatefirst)}{drawCell(coordinatetwo)}";

            return row;
        }

        private string drawCell(Point coordinate)
        {
            var cell = $"({coordinate.X},{coordinate.Y})|";

            return cell;
        }
    }
}