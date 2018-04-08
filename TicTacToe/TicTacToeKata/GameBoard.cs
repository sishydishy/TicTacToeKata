using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeKata
{
    public class GameBoard
    {
        private readonly int _boardHeight;
        private readonly int _boardWidth;
        private readonly int _area;
        private readonly int _positionOnBoardUpperBound;
        private const int _positionOnBoardLowerBound = 0;

        //private List<Symbol> _board;

        public List<Symbol> Board;

        public GameBoard()
        {
            _boardHeight = 3;
            _boardWidth = 3;
            _area = _boardHeight * _boardWidth;
            _positionOnBoardUpperBound = _area - 1;
            Create();
        }

        private void Create()
        {
            Board = Enumerable.Repeat((Symbol) '.', _area).ToList();
        }

        public Tuple<int, int> Position(int positionOnBoard)
        {
            ValidatePosition(positionOnBoard);
            var x = positionOnBoard % _boardWidth;
            var y = positionOnBoard / _boardWidth;



            return new Tuple<int, int>(x, y);
        }

        private void ValidatePosition(int positionOnBoard)
        {
            if (IsPositionOutOfBounds(positionOnBoard))
            {
                throw new ArgumentException();
            }
        }

        private bool IsPositionOutOfBounds(int positionOnBoard)
        {
            return positionOnBoard < _positionOnBoardLowerBound || positionOnBoard > _positionOnBoardUpperBound;
        }

        public void AddSymbol(Symbol symbol, int x, int y)
        {
            var position = x + _boardHeight * y;
            Board[position] = symbol;
        }



        public void ShouldRender()
        {
            var board = new StringBuilder();

            //board.Append("    |    |    " + Environment.NewLine); //Environment.NewLine allows a new line to be formed cross platform ^.^ very scalable
            var line_one = " {0}  | {1}  |  {2}  ";
            board.Append(string.Format(line_one, Position(Convert.ToInt32(Board[0])), (char) Board[1], (char) Board[2]) + Environment.NewLine);

            board.Append("____|____|____" + Environment.NewLine);
            var line_two = " {0}  | {1}  |  {2}  ";
            board.Append(string.Format(line_two, (char) Board[3], (char) Board[4], (char) Board[5]) + Environment.NewLine);
            board.Append("____|____|____" + Environment.NewLine);
            var line_three = " {0}  | {1}  |  {2}  ";
            board.Append(string.Format(line_three, (char) Board[6], (char) Board[7], (char) Board[8]) + Environment.NewLine);
            //board.Append("    |    |    " + Environment.NewLine);
            Console.WriteLine(board.ToString());
            
        }


}
}