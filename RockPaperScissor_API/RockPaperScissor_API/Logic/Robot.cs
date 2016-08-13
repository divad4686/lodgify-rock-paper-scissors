using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissor_API.Logic
{


    public class Robot : IRobot
    {
        public playOption chooseRandomOption()
        {
            Array values = Enum.GetValues(typeof(playOption));
            Random random = new Random();
            playOption randomOption = (playOption)values.GetValue(random.Next(values.Length));

            return randomOption;
        }
    }

    public interface IRobot
    {
        /// <summary>
        /// Choose a random option to play
        /// </summary>
        /// <returns></returns>
        playOption chooseRandomOption();                
    }
}