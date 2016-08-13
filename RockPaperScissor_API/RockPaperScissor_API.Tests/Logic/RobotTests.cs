using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissor_API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor_API.Logic.Tests
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