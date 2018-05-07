using System;
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
            EngineSetUp(out var renderer, out var winReferee, humanPlayer1Symbol, humanPlayer2Symbol, out var humanPlayerOne, out var humanPlayerTwo);
            InitialWelcomeAndBoard(renderer, board);
            var winner = PlayTicTacToe(board, humanPlayer1Symbol, renderer, winReferee, humanPlayer2Symbol, humanPlayerOne, humanPlayerTwo);
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
            Symbol humanPlayer2Symbol, HumanPlayer humanPlayerOne, HumanPlayer humanPlayerTwo)
        {
            var winner = Symbol.Empty;
            while (AnyBoardElementsIsEqualToEmpty(board))
            {
                PlayerOneMove(board, renderer, humanPlayerOne);
                if (CheckIfPlayerIsWinner(board, humanPlayer1Symbol, winReferee, out winner)) break;
                PlayerTwoMove(board, renderer, humanPlayerTwo);
                if (CheckIfPlayerIsWinner(board, humanPlayer2Symbol, winReferee, out winner)) break;
            }
            return winner;
        }

        private static bool CheckIfPlayerIsWinner(GameBoard board, Symbol symbol, WinReferee winReferee, out Symbol winner)
        {
            winner = winReferee.WinChecker(board, symbol);
            winReferee.AnnounceWinner(winner);
            if (winner != Symbol.Empty) return true;
            if (BoardElementsNotEqualToEmptyThenBreak(board)) return true;
            return false;
        }


        private static bool AnyBoardElementsIsEqualToEmpty(GameBoard board)
        {
            return board.Board.Any(x => x == Symbol.Empty);
        }

        
        private static bool BoardElementsNotEqualToEmptyThenBreak(GameBoard board)
        {
            return board.Board.All(x => x != Symbol.Empty);
        }

        
        private static void PlayerTwoMove(GameBoard board, Renderer renderer, HumanPlayer humanPlayerTwo)
        {
            Console.Write("Your Turn: ");
            var playerTwoInput = Console.ReadLine();
            humanPlayerTwo.ShouldMoveHumanPlayer(board, playerTwoInput);
            Console.WriteLine(renderer.DrawTokenBoard(board));
        }

        
        private static void PlayerOneMove(GameBoard board, Renderer renderer, HumanPlayer humanPlayerOne)
        {
            Console.Write("Your Turn: ");
            var playerOneInput = Console.ReadLine();
            humanPlayerOne.ShouldMoveHumanPlayer(board, playerOneInput);
            Console.WriteLine(renderer.DrawTokenBoard(board));
        }

        
        private static void InitialWelcomeAndBoard(Renderer renderer, GameBoard board)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.WriteLine("Here's the current board:\n");

            Console.WriteLine(renderer.DrawStartingBoard(board));
        }

        
        private static void EngineSetUp(out Renderer renderer, out WinReferee winReferee, Symbol humanPlayer1Symbol, Symbol humanPlayer2Symbol, out HumanPlayer humanPlayerOne, out HumanPlayer humanPlayerTwo)
        {
            renderer = new Renderer();
            winReferee = new WinReferee();
            humanPlayerOne = new HumanPlayer(humanPlayer1Symbol, new InputChecker());
            humanPlayerTwo = new HumanPlayer(humanPlayer2Symbol, new InputChecker());
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