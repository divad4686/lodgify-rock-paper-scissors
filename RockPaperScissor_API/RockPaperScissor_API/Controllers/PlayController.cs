using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RockPaperScissor_API.Logic;
using System.Web.Mvc;

namespace RockPaperScissor_API.Controllers
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

                var result = new { result = "success", gameResult = gameResult.ToString() };
                return Json(result);
            }
            catch (ArgumentException)
            {
                var result = new { result = "error", message = "wrong parameter" };
                return Json(result);
            }
            catch (Exception)
            {
                var result = new { result = "error", message = "unknown error" };
                return Json(result);
            }
        }
    }
}
