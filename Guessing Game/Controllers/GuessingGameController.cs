using Microsoft.AspNetCore.Mvc;
using System;

namespace Guessing_Game.Controllers
{
    public class GuessingGameController : Controller
    {
        [Route("/GuessingGame")]
        public IActionResult Index()
        {
            Random random = new Random();
            int num = random.Next(1, 100);

            // save num it in a session

            

            return View();
        }

        [HttpPost]
        [Route("/GuessingGame")]
        public IActionResult Index(int number)
        {
            
            
            ViewBag.Number = number;

            

            return View();
        }
    }
}
