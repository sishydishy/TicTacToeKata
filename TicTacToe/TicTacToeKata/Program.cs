using System;
using System.Runtime.InteropServices;

namespace TicTacToeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            
            Console.WriteLine("Here's the current board:");
            
            var board = new GameBoard();
            Console.WriteLine((char)board.Board[0]);
            
            //board.ShouldRender();

        }
    }
}