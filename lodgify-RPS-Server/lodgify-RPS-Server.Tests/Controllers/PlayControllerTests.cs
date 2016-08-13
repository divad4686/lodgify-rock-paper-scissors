using Microsoft.VisualStudio.TestTools.UnitTesting;
using lodgify_RPS_Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lodgify_RPS_Server.Logic;
using NSubstitute;
using System.Web.Script.Serialization;

namespace lodgify_RPS_Server.Controllers.Tests
{
    [TestClass()]
    public class PlayControllerTests
    {
        IWebPlayLogic logic;
        PlayController controller;

        [TestInitialize()]
        public void setUp()
        {
            // create mock logic
            logic = Substitute.For<IWebPlayLogic>();
            controller = new PlayController(logic);
        }

        [TestMethod()]
        public void testWrongParameter()
        {
            // call the controller with wrong parameter
            var result = controller.playOneGame("casa");
            
            // json expected
            string expected = "{\"result\":\"error\",\"message\":\"wrong parameter\"}";

            // the logic should not receive any call
            logic.DidNotReceive().playOneGame(Arg.Any<playOption>());
            var stringResult = new JavaScriptSerializer().Serialize(result.Data);
            Assert.AreEqual(expected, stringResult);
        }

        [TestMethod()]
        public void testTie()
        {
            testWinnerResult("tie", playResult.tie);
        }

        [TestMethod()]
        public void testUserWinAndReceiveRock()
        {
            testWinnerResult("user", playResult.firstPlayer);
        }

        [TestMethod()]
        public void tesRobotWin()
        {
            testWinnerResult("robot", playResult.secondPlayer);
        }

        void testWinnerResult(string winner,playResult playWinner)
        {
            // We don't care about the argument here
            logic.playOneGame(Arg.Any<playOption>()).Returns(playWinner);

            var result = controller.playOneGame("paper");
            // the formated JSon
            string expected = "{\"result\":\"success\",\"winner\":\"" + winner + "\"}";

            var stringResult = new JavaScriptSerializer().Serialize(result.Data);
            Assert.AreEqual(expected, stringResult);
        }

        [TestMethod()]
        public void testLogicReceivePaperCall()
        {
            controller.playOneGame("paper");
            // logic should receive a call with the paper parameter we send to the server
            logic.Received().playOneGame(playOption.paper);
        }

        [TestMethod()]
        public void testLogicReceiveRockCall()
        {
            controller.playOneGame("rock");
            // logic should receive a call with the paper parameter we send to the server
            logic.Received().playOneGame(playOption.rock);
        }

        [TestMethod()]
        public void testLogicScissorsPaperCall()
        {
            controller.playOneGame("scissors");
            // logic should receive a call with the paper parameter we send to the server
            logic.Received().playOneGame(playOption.scissors);
        }
    }
}