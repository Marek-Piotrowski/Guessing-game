using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Guessing_Game.Models;

namespace Guessing_Game.Controllers
{
    public class GuessingGameController : Controller
    {
        [Route("/GuessingGame")]
        public IActionResult Index()
        {
            Random random = new Random();
            int num = random.Next(1, 100);

            HttpContext.Session.SetString("GuessSession", num.ToString());
            ViewBag.Number = "Start game";

            ViewBag.Message = "Session has been set";



            return View();
        }

        [HttpPost]
        [Route("/GuessingGame")]
        public IActionResult Index(int number)
        {
            ViewBag.Session = HttpContext.Session.GetString("GuessSession");
            ViewBag.Validation = Utility.CheckNumber(number, ViewBag.Session);
            
            ViewBag.Number = Utility.ConvertNumberToString(number);

            

            return View();
            
        }
    }
}
