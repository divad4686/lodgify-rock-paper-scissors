using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissor_API.Logic
{
    public class WebPlayLogic : IWebPlayLogic
    {
        IRobot _robot;
        IRPSLogic _logic;

        public WebPlayLogic()
        {
            var robot = new Robot();
            var logic = new RPSLogic();

            setup(robot, logic);
        }

        public WebPlayLogic(IRobot robot,IRPSLogic logic)
        {
            setup(robot, logic);
        }

        void setup(IRobot robot,IRPSLogic logic)
        {
            _robot = robot;
            _logic = logic;
        }

        public playResult playOneGame(playOption userOption)
        {
            var robotPlay = _robot.chooseRandomOption();
            var result = _logic.whoWin(userOption, robotPlay);

            return result;
        }
    }

    public interface IWebPlayLogic
    {
        /// <summary>
        /// PLay one game between the web user and a robot
        /// </summary>
        /// <param name="userOption">The option send by the user</param>
        /// <returns>the winner of the game, or a tie</returns>
        playResult playOneGame(playOption userOption);
    }
}