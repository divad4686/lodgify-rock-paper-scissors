using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lodgify_RPS_Server.Logic
{
    public enum playOption
    {
        rock,
        paper,
        scissors
    }

    public enum playResult
    {
        firstPlayer,
        secondPlayer,
        tie
    }

    public class RPSLogic : IRPSLogic
    {
        public playResult whoWin(playOption optionPlayerOne, playOption optionPlayerTwo)
        {
            if (optionPlayerOne == optionPlayerTwo)
                return playResult.tie;
            else if (optionPlayerOne == playOption.paper && optionPlayerTwo == playOption.rock)
                return playResult.firstPlayer;
            else if (optionPlayerOne == playOption.rock && optionPlayerTwo == playOption.scissors)
                return playResult.firstPlayer;
            else if (optionPlayerOne == playOption.scissors && optionPlayerTwo == playOption.paper)
                return playResult.firstPlayer;
            else // If the player one doesn't win on the first 3 options, then player two wins
                return playResult.secondPlayer;
        }
    }

    public interface IRPSLogic
    {
        /// <summary>
        /// Returs the result of a game between two options
        /// </summary>
        /// <param name="optionPlayerOne"></param>
        /// <param name="optionPlayerTwo"></param>
        /// <returns>The result of the game</returns>
        playResult whoWin(playOption optionPlayerOne, playOption optionPlayerTwo);
    }
}