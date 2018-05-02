using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TicTacToeKata
{
    public static class GameEngine
    {

        static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.WriteLine("Here's the current board:\n");

            SymbolSetup();



            


        }

//        Console.WriteLine(renderer.DrawStartingBoard(board) + Environment.NewLine);
//
//            
//            Console.WriteLine(renderer.DrawTokenBoard(board));
//
//            Console.Write("Your Turn (X): ");
//            string userInput1 = Console.ReadLine();
//            board.ShouldMoveHumanPlayer(userInput1);
//            Console.WriteLine(renderer.DrawTokenBoard(board));
//            
//            Console.Write("Your Turn (X): ");
//            string userInput = Console.ReadLine();
//            board.ShouldMoveHumanPlayer(userInput);
//            Console.WriteLine(renderer.DrawTokenBoard(board));
        

        private static void SymbolSetup()
        {
            var board = new GameBoard();
            var humanPlayer1Symbol = Symbol.Cross;
            var humanPlayer2Symbol = Symbol.Nought;
            
            

        }
    }
}