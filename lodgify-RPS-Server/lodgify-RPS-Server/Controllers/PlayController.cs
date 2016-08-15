using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using lodgify_RPS_Server.Logic;
using System.Web.Mvc;

namespace lodgify_RPS_Server.Controllers
{
    public class PlayController : Controller
    {
        IWebPlayLogic _logic;
        public PlayController(IWebPlayLogic logic)
        {
            _logic = logic;
        }

        public JsonResult playOneGame(string playOptionString)
        {
            try
            {
                playOption option = (playOption)Enum.Parse(typeof(playOption), playOptionString, true);
                var gameResult = _logic.playOneGame(option);

                string gameResultString = "";

                if (gameResult == playResult.tie)
                    gameResultString = "tie";
                else if (gameResult == playResult.firstPlayer)
                    gameResultString = "user";
                else if (gameResult == playResult.secondPlayer)
                    gameResultString = "robot";


                var result = new { result = "success", winner = gameResultString };

                return new JsonpResult
                {
                    Data = result
                };
            }
            catch (ArgumentException)
            {
                var result = new { result = "error", message = "wrong parameter" };
                return new JsonpResult
                {
                    Data = result
                };               
            }
            catch (Exception)
            {
                var result = new { result = "error", message = "unknown error" };
                return new JsonpResult
                {
                    Data = result
                };
            }
        }
    }
}
