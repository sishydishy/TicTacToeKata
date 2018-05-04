using TicTacToeKata;
using Xunit;

namespace TicTacToe.Test
{
    public class RendererShould
    {
        private readonly GameBoard _gameBoard;

        public RendererShould()
        {
            _gameBoard = new GameBoard();
        }
        
        [Fact]
        public void RenderStartingCoordinateBoard()
        {
            var expected = 
                @"-----|-----|-----
(0,0)|(1,0)|(2,0)
-----|-----|-----
(0,1)|(1,1)|(2,1)
-----|-----|-----
(0,2)|(1,2)|(2,2)
-----|-----|-----
";   
            var render = new Renderer();
            var result = render.DrawStartingBoard(_gameBoard);
            
            Assert.Equal(expected,result);
        }


        [Fact]
        public void GivenTokenThenRenderCellWithToken()
        {
            var expected =
                @"-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
";
            var render = new Renderer();
            var result = render.DrawTokenBoard(_gameBoard);
            
            Assert.Equal(expected,result);
        }
        
        [Fact]
        public void GivenHumanMoveThenRenderCellWithToken()
        {
            var userInput = "0,0";
            _gameBoard.ShouldMoveHumanPlayer(userInput, Symbol.Cross);
            var expected =
                @"-----|-----|-----
  X  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
  .  |  .  |  .  
-----|-----|-----
";
            var render = new Renderer();
            var result = render.DrawTokenBoard(_gameBoard);
            Assert.Equal(expected,result);
        }

    }
}