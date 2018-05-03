﻿using System;
using System.Linq;

namespace TicTacToeKata
{
    public static class GameEngine
    {
        static void Main()
        {
            Execute();
        }

        private static void Execute()
        {
            BoardSetUp(out var board, out var humanPlayer1Symbol, out var humanPlayer2Symbol);
            EngineSetUp(out var renderer, out var winReferee);
            InitialWelcomeAndBoard(renderer, board);
            var winner = PlayTicTacToe(board, humanPlayer1Symbol, renderer, winReferee, humanPlayer2Symbol);
            winReferee.AnnounceDraw(winner, board.Board);
            ReplayGame();
        }

        
        
        
        
        
        
        
        private static void ReplayGame()
        {
            Console.WriteLine("Would you like to play again? Y or N: ");
            var inputReply = Console.ReadLine();
            if (inputReply?.ToUpper() == "Y")
            {
                Execute();
            }
            Console.WriteLine("See ya later!");
        }

        
        private static Symbol PlayTicTacToe(GameBoard board, Symbol humanPlayer1Symbol, Renderer renderer,
            WinReferee winReferee,
            Symbol humanPlayer2Symbol)
        {
            var winner = Symbol.Empty;
            while (AnyBoardElementsIsEqualToEmpty(board))
            {
                PlayerOneMove(board, humanPlayer1Symbol, renderer);
                winner = winReferee.WinChecker(board, humanPlayer1Symbol);
                winReferee.AnnounceWinner(winner);
                if (winner != Symbol.Empty) break;
                if (BoardElementsNotEqualToEmptyThenBreak(board)) break;


                PlayerTwoMove(board, renderer, humanPlayer2Symbol);
                winner = winReferee.WinChecker(board, humanPlayer1Symbol);
                winReferee.AnnounceWinner(winner);
                if (winner != Symbol.Empty) break;
                if (BoardElementsNotEqualToEmptyThenBreak(board)) break;
            }
            return winner;
        }

        
        private static bool AnyBoardElementsIsEqualToEmpty(GameBoard board)
        {
            return board.Board.Any(x => x == Symbol.Empty);
        }

        
        private static bool BoardElementsNotEqualToEmptyThenBreak(GameBoard board)
        {
            return board.Board.All(x => x != Symbol.Empty);
        }

        
        private static void PlayerTwoMove(GameBoard board, Renderer renderer, Symbol humanPlayer2Symbol)
        {
            Console.Write("Your Turn: ");
            var playerTwoInput = Console.ReadLine();
            board.ShouldMoveHumanPlayer(playerTwoInput, humanPlayer2Symbol);
            Console.WriteLine(renderer.DrawTokenBoard(board));
        }

        
        private static void PlayerOneMove(GameBoard board, Symbol humanPlayer1Symbol, Renderer renderer)
        {
            Console.Write("Your Turn: ");
            var playerOneInput = Console.ReadLine();
            board.ShouldMoveHumanPlayer(playerOneInput, humanPlayer1Symbol);
            Console.WriteLine(renderer.DrawTokenBoard(board));
        }

        
        private static void InitialWelcomeAndBoard(Renderer renderer, GameBoard board)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.WriteLine("Here's the current board:\n");

            Console.WriteLine(renderer.DrawStartingBoard(board));
        }

        
        private static void EngineSetUp(out Renderer renderer, out WinReferee winReferee)
        {
            renderer = new Renderer();
            winReferee = new WinReferee();
        }

        
        private static void BoardSetUp(out GameBoard board, out Symbol humanPlayer1Symbol,
            out Symbol humanPlayer2Symbol)
        {
            board = new GameBoard();
            humanPlayer2Symbol = Symbol.Nought;
            humanPlayer1Symbol = Symbol.Cross;
        }
    }
}