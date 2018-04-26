using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TicTacToeKata
{
    public class GameBoard
    {
        private readonly int _boardHeight;
        public readonly int _boardWidth;
        private readonly int _area;
        private readonly int _positionOnBoardUpperBound;
        private const int _positionOnBoardLowerBound = 0;

        private List<Symbol> _board;

        public IReadOnlyList<Symbol> Board => _board;

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
            _board = Enumerable.Repeat((Symbol) '.', _area).ToList();
        }

        public Point Position(int positionOnBoard)
        {
            ValidatePosition(positionOnBoard);
            var x = positionOnBoard % _boardWidth;
            var y = positionOnBoard / _boardWidth;


            return new Point
            {
                X = x,
                Y = y
            };
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

        public void AddSymbol(Symbol symbol, Point coordinates)
        {
            var position = coordinates.X + _boardHeight * coordinates.Y;
            _board[position] = symbol;
        }


        public void ShouldMoveHumanPlayer(int userInput)
        {
            AddSymbol(Symbol.Cross, Position(userInput) );
            
        }
    }
}