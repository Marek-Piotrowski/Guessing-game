using Microsoft.AspNetCore.Mvc;
using Guessing_Game.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Guessing_Game.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        [Route("/FeverCheck")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route ("/FeverCheck")]
        public IActionResult TempCheck(int temp)
        {
            string result = Utility.CheckTemp(temp);
            ViewBag.Result = result;
            ViewBag.Temp = temp;


            return View();
        }
    }
}
