using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    
    public class PeopleController : Controller
    {
        private readonly AppDbContext _appContext;
        public PeopleController(AppDbContext config)
        {
            _appContext = config;
        }

        [Route("/People")]
        public IActionResult Index(string searchQuery = null)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewModel = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            ViewBag.Cities = new SelectList(_appContext.Cities, "CityName", "CityName");

            viewModel.people = _appContext.People.ToList();

            string search = null;

            if(searchQuery != null)
            {
                search = searchQuery.ToLower();
            }
            

            if(search != null)
            {
                persons = _appContext.People.Where(p => p.Name.ToLower().Contains(searchQuery) || p.City.CityName.ToLower().Contains(searchQuery) || p.PhoneNumber.ToLower().Contains(searchQuery)).ToList();

                viewModel.people = persons;
                viewModel.person = newPerson;

                return View(viewModel);
            }
            
            
            return View(viewModel);
        }

        [HttpPost]
        [Route("/People")]
        public IActionResult Index(CreatePersonViewModel person,string CityName)
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            

            ViewBag.Cities = new SelectList(_appContext.Cities, "CityName", "CityName");

            City cityToAdd = _appContext.Cities.FirstOrDefault(c => c.CityName == CityName);


            if (ModelState.IsValid)
            {
                Person personModel = new Person()
                {
                    Name = person.NewName,
                    PhoneNumber = person.NewPhone,
                    CityId = cityToAdd.CityId,
                   
                };
              
                _appContext.People.Add(personModel);
                _appContext.SaveChanges();

                viewModel.person = person;
                viewModel.people = _appContext.People.ToList();

                return View(viewModel);
            }

            viewModel.people = _appContext.People.ToList();
            viewModel.person = person;

            // return View("Index",person)
            return View(viewModel);
        }
       

        public IActionResult Remove(Person person)
        {
            Person personToRemove = _appContext.People.Find(person.PersonId);


            _appContext.People.Remove(personToRemove);
            _appContext.SaveChanges();
            return RedirectToAction("Index");

        }



    }

    
    
}
