using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    public class CityController : Controller
    {
        private readonly AppDbContext _appContext;
        public CityController(AppDbContext config)
        {
            _appContext = config;
        }
        public IActionResult Index()
        {
            List<City> listOfCities = _appContext.Cities.ToList();

            var countries  = _appContext.Countries.ToList();

            ViewBag.countries = countries;


            return View(listOfCities);


        }

        public IActionResult AddCity()
        {
            ViewBag.Countries = new SelectList(_appContext.Countries, "CountryName", "CountryName");

            return View();
        }


        [HttpPost]
        public IActionResult AddCity(string CityName, string CountryName)
        {
            Country countryToAdd = _appContext.Countries.FirstOrDefault(c => c.CountryName == CountryName);

           
            
                City city = new City()
                {
                    CityName = CityName,
                    CountryId = countryToAdd.CountryId, 
                    //Country = new Country() { CountryName = CountryName }
                };

                _appContext.Cities.Add(city);
                _appContext.SaveChanges();
                return RedirectToAction("Index");
         


            
        }


        public IActionResult Remove(City city)
        {
            City cityToRemove = _appContext.Cities.Find(city.CityId);


            _appContext.Cities.Remove(cityToRemove);
            _appContext.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
