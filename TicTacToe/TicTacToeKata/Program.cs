using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TicTacToeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            
            Console.WriteLine("Here's the current board:");
            Console.WriteLine();
            
            var board = new GameBoard();
            var renderer = new Renderer();




            Console.WriteLine(renderer.DrawStartingBoard(board) + Environment.NewLine);

            
            Console.WriteLine(renderer.DrawTokenBoard(board));
            


            




        }
    }
}