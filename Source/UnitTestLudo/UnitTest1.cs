using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLudo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DiceBetweenOneAndSix()
        {
            int result = Dice.Roll();
            Assert.IsTrue(result >= 1 && result <= 6);
        }
    }
}
