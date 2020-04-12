using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGameEngine
{
    [TestClass]
    public class GameCompletion
    {
        [TestMethod]
        public void Game_Not_Finished_Condition()
        {
            var player = new Player { PlayerType = PlayerType.Blue, Score = 0 };
            var secondPlayer = new Player { PlayerType = PlayerType.Green, Score = 1 };
            var game = new Game()
                .New()
                .AddPlayer(player)
                .AddPlayer(secondPlayer)
                .Build();

            var expectedResult = false;

            Assert.AreEqual(expectedResult, game.Finished());
        }

        [TestMethod]
        public void Game_Finished_Condition()
        {
            var player = new Player { PlayerType = PlayerType.Blue, Score = 4 };
            var secondPlayer = new Player { PlayerType = PlayerType.Green, Score = 2 };
            var game = new Game()
                .New()
                .AddPlayer(player)
                .AddPlayer(secondPlayer)
                .Build();

            var expectedResult = true;

            Assert.AreEqual(expectedResult, game.Finished());
        }
    }
}
