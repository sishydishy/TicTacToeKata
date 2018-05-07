using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToeKata
{
    public class GameBoard
    {
        public readonly int _boardHeight;
        public readonly int _boardWidth;
      
        public readonly int _positionOnBoardUpperBound;
        public readonly int _positionOnBoardLowerBound = 0;



        public List<Symbol> Board; 


        public GameBoard()
        {
            _boardHeight = 3;
            _boardWidth = 3;
            var area = _boardHeight * _boardWidth;
            _positionOnBoardUpperBound = area - 1;
            
            Create(area);
        }

        private void Create(int area)
        { 
            
            Board = Enumerable.Repeat((Symbol) '.', area).ToList();
        }

        public Point Position(int positionOnBoard)
        {
            
            var x = positionOnBoard % _boardWidth;
            var y = positionOnBoard / _boardWidth;


            return new Point
            {
                X = x,
                Y = y
            };
        }


    }
}