using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lodgify_RPS_Server.Logic;

namespace lodgify_RPS_Server.Tests
{
    [TestClass]
    public class RPSLogicTest
    {
        [TestMethod]
        public void TestWhoWin()
        {            
            RPSLogic logic = new RPSLogic();

            // Test all posible plays   

            // first test the ties
            var result = logic.whoWin(playOption.paper, playOption.paper);
            Assert.AreEqual(playResult.tie, result);

            result = logic.whoWin(playOption.rock, playOption.rock);
            Assert.AreEqual(playResult.tie, result);

            result = logic.whoWin(playOption.scissors, playOption.scissors);
            Assert.AreEqual(playResult.tie, result);

            // Player one wins
            result = logic.whoWin(playOption.paper, playOption.rock);
            Assert.AreEqual(playResult.firstPlayer, result);

            result = logic.whoWin(playOption.rock, playOption.scissors);
            Assert.AreEqual(playResult.firstPlayer, result);

            result = logic.whoWin(playOption.scissors, playOption.paper);
            Assert.AreEqual(playResult.firstPlayer, result);

            // Player two wins
            result = logic.whoWin(playOption.paper, playOption.scissors);
            Assert.AreEqual(playResult.secondPlayer, result);

            result = logic.whoWin(playOption.rock, playOption.paper);
            Assert.AreEqual(playResult.secondPlayer, result);

            result = logic.whoWin(playOption.scissors, playOption.rock);
            Assert.AreEqual(playResult.secondPlayer, result);
        }
    }
}
