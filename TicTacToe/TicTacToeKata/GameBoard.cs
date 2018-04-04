using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class GameBoard
    {
        private readonly int _boardHeight;
        private readonly int _boardWidth;
        private readonly int _area;
        public List<Symbol> Board { get; set; }

        public GameBoard()
        {
            _boardHeight = 3;
            _boardWidth = 3;
            _area = _boardHeight * _boardWidth;
            Create();
        }

        private void Create()
        {
            Board = Enumerable.Repeat((Symbol) '.', _area).ToList();
            

        }

        public Tuple<int, int> Position(int positionOnBoard)
        {
            var x = positionOnBoard % _boardWidth;
            var y = positionOnBoard / _boardWidth;
            return new Tuple<int, int>(x,y);
        }

        public void AddSymbol(Symbol symbol, int x, int y)
        {
            var position = x + _boardHeight * y;
            Board[position] = symbol;
        }
    }
}