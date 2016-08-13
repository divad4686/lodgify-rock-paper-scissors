using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissor_API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace RockPaperScissor_API.Logic.Tests
{
    [TestClass()]
    public class WebPlayLogicTests
    {
        IRobot mockRobot;
        IRPSLogic mockLogic;
        WebPlayLogic webLogic;

        [TestInitialize()]
        public void setUp()
        {
            mockRobot = Substitute.For<IRobot>();
            mockLogic = Substitute.For<IRPSLogic>();
            webLogic = new WebPlayLogic(mockRobot, mockLogic);
        }

        [TestMethod()]
        public void testTies()
        {
            // the logic returns tie
            mockLogic.whoWin(Arg.Any<playOption>(), Arg.Any<playOption>()).Returns(playResult.tie);

            // now test each possible play
            // first when the robot return paper
            mockRobot.chooseRandomOption().Returns(playOption.paper);
            // the human play paper
            var result = webLogic.playOneGame(playOption.paper);
            //the robot should receive a call to chooseRandomOption
            mockRobot.Received().chooseRandomOption();
            // the logic should receive a call to choose the winner
            mockLogic.Received().whoWin(playOption.paper, playOption.paper);
            Assert.AreEqual(playResult.tie, result);

            // repeat same logic with different parameters
            mockRobot.chooseRandomOption().Returns(playOption.scissors);
            result = webLogic.playOneGame(playOption.scissors);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.paper, playOption.paper);
            Assert.AreEqual(playResult.tie, result);

            mockRobot.chooseRandomOption().Returns(playOption.rock);
            result = webLogic.playOneGame(playOption.rock);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.paper, playOption.paper);
            Assert.AreEqual(playResult.tie, result);
        }

        [TestMethod()]
        public void userWin()
        {
            // Same logic as testTies
            mockLogic.whoWin(Arg.Any<playOption>(), Arg.Any<playOption>()).Returns(playResult.firstPlayer);

            mockRobot.chooseRandomOption().Returns(playOption.rock);
            var result = webLogic.playOneGame(playOption.paper);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.paper, playOption.rock);
            Assert.AreEqual(playResult.firstPlayer, result);

            mockRobot.chooseRandomOption().Returns(playOption.paper);
            result = webLogic.playOneGame(playOption.scissors);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.scissors, playOption.paper);
            Assert.AreEqual(playResult.firstPlayer, result);

            mockRobot.chooseRandomOption().Returns(playOption.scissors);
            result = webLogic.playOneGame(playOption.rock);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.rock, playOption.scissors);
            Assert.AreEqual(playResult.firstPlayer, result);
        }

        [TestMethod()]
        public void robotWin()
        {
            // Same logic as testTies
            mockLogic.whoWin(Arg.Any<playOption>(), Arg.Any<playOption>()).Returns(playResult.secondPlayer);

            mockRobot.chooseRandomOption().Returns(playOption.paper);
            var result = webLogic.playOneGame(playOption.rock);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.rock, playOption.paper);
            Assert.AreEqual(playResult.secondPlayer, result);

            mockRobot.chooseRandomOption().Returns(playOption.scissors);
            result = webLogic.playOneGame(playOption.paper);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.paper, playOption.scissors);
            Assert.AreEqual(playResult.secondPlayer, result);

            mockRobot.chooseRandomOption().Returns(playOption.rock);
            result = webLogic.playOneGame(playOption.scissors);
            mockRobot.Received().chooseRandomOption();
            mockLogic.Received().whoWin(playOption.scissors, playOption.rock);
            Assert.AreEqual(playResult.secondPlayer, result);
        }
    }
}