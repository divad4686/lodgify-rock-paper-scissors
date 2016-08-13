using Microsoft.VisualStudio.TestTools.UnitTesting;
using lodgify_RPS_Server.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lodgify_RPS_Server.Logic.Tests
{
    [TestClass()]
    public class RobotTests
    {
        [TestMethod()]
        public void chooseRandomOptionTest()
        {
            Robot robot = new Robot();

            var result = robot.chooseRandomOption();

            if (result != playOption.paper && result != playOption.rock && result != playOption.scissors)
                Assert.Fail();
        }
    }
}