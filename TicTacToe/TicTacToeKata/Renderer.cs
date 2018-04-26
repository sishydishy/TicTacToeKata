using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TicTacToeKata
{
    public class Renderer
    {
        public string DrawStartingBoard(GameBoard gameBoard)
        {
            var row = new StringBuilder();
            row.Append("-----|-----|-----" + Environment.NewLine);

            for (var index = 0; index < gameBoard.Board.Count; index++)
            {
                var nextIndex = index + 1;
                if (nextIndex % gameBoard._boardWidth == 0)
                {
                    row.Append(drawCellCoordinate(gameBoard.Position(index)) + Environment.NewLine);
                    row.Append("-----|-----|-----" + Environment.NewLine);
                }
                else
                {
                    row.Append(drawCellCoordinate(gameBoard.Position(index)) + "|");
                }
            }
            return row.ToString();
        }

        private string drawCellCoordinate(Point coordinate)
        {
            var cell = $"({coordinate.X},{coordinate.Y})";

            return cell;
        }

        public string DrawTokenBoard(GameBoard gameBoard)
        {
            var row = new StringBuilder();
            row.Append("-----|-----|-----" + Environment.NewLine);

            for (var index = 0; index < gameBoard.Board.Count; index++)
            {
                var nextIndex = index + 1;
                if (nextIndex % gameBoard._boardWidth == 0)
                {
                    row.Append("  " + (char) gameBoard.Board[index] + "  " + Environment.NewLine);
                    row.Append("-----|-----|-----" + Environment.NewLine);
                }
                else
                {
                    row.Append("  " + (char) gameBoard.Board[index] + "  " + "|");
                }
            }
            return row.ToString();
        }



    }
}