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

            Console.Write("Your Turn (X): ");
            string userInput1 = Console.ReadLine();
            board.ShouldMoveHumanPlayer(userInput1);
            Console.WriteLine(renderer.DrawTokenBoard(board));
            
            Console.Write("Your Turn (X): ");
            string userInput = Console.ReadLine();
            board.ShouldMoveHumanPlayer(userInput);
            Console.WriteLine(renderer.DrawTokenBoard(board));









        }
    }
}