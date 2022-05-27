using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    public class CountryController : Controller
    {
        private readonly AppDbContext _appContext;
        public CountryController(AppDbContext config)
        {
            _appContext = config;
        }
        public IActionResult Index()
        {
            List<Country> listOfCountries = _appContext.Countries.ToList();


            return View(listOfCountries);
        }
        public IActionResult AddCountry()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                _appContext.Countries.Add(country);
                _appContext.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }
        
        public IActionResult Remove(Country country)
        {
            Country countryToRemove = _appContext.Countries.Find(country.CountryId);

            
            _appContext.Countries.Remove(countryToRemove);
            _appContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
