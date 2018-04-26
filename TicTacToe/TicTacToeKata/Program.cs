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
            
            var board = new GameBoard();
            var renderer = new Renderer();




            Console.WriteLine(renderer.DrawStartingBoard(board));

            Console.WriteLine(renderer.DrawTokenBoard(board));
            


            




        }
    }
}