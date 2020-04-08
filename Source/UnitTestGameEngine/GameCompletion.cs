using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGameEngine
{
    [TestClass]
    public class GameCompletion
    {
        [TestMethod]
        public void GameNotFinishedCondition()
        {
            var player = new Player { Score = 0 };
            var game = new Game()
                .New()
                .Build()
                .AddPlayer(player);

            var expectedResult = false;

            Assert.AreEqual(expectedResult, game.Finished());
        }

        [TestMethod]
        public void GameFinishedCondition()
        {
            var player = new Player { Score = 4 };
            var game = new Game()
                .New()
                .Build()
                .AddPlayer(player);

            var expectedResult = true;

            Assert.AreEqual(expectedResult, game.Finished());
        }
    }
}
