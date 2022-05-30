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

            viewModel.people = _appContext.People.ToList();

            ViewBag.Cities = new SelectList(_appContext.Cities, "CityName", "CityName");
            ViewBag.Languages = new SelectList(_appContext.Languages, "LanguageName", "LanguageName");

            //languages for ViewBag
            var langs = _appContext.Languages.ToList();
            ViewBag.langs = langs;

            //personlangs for ViewBag
            var personlangs = _appContext.PersonLanguages.ToList();
            ViewBag.personlangs = personlangs;

            //cities for ViewBag
            var personCities = _appContext.Cities.ToList();
            ViewBag.personCities = personCities; 

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
        public IActionResult Index([Bind("NewName,NewPhone")] CreatePersonViewModel person,string CityName,string LanguageName)
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            viewModel.people = _appContext.People.ToList();

            City cityToAdd = _appContext.Cities.FirstOrDefault(c => c.CityName == CityName);
            Language languageToAdd = _appContext.Languages.FirstOrDefault(c => c.LanguageName == LanguageName);


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

                PersonLanguage personlanguage = new PersonLanguage()
                {
                     PersonId = personModel.PersonId,
                     LanguageId = languageToAdd.LanguageId,
                };

                _appContext.PersonLanguages.Add(personlanguage);
                _appContext.SaveChanges();

                viewModel.person = person;
                viewModel.people = _appContext.People.ToList();

                //person languages for ViewBag
                var langs = _appContext.Languages.ToList();
                ViewBag.langs = langs;

                //personlangs for ViewBag
                var personlangs = _appContext.PersonLanguages.ToList();
                ViewBag.personlangs = personlangs;
                //cities for ViewBag
                var personCities = _appContext.Cities.ToList();
                ViewBag.personCities = personCities;

                //return View(viewModel);
                return RedirectToAction("Index");
            }

            ViewBag.Cities = new SelectList(_appContext.Cities, "CityName", "CityName");
            ViewBag.Languages = new SelectList(_appContext.Languages, "LanguageName", "LanguageName");

            //person languages for ViewBag
            ViewBag.langs = _appContext.Languages.ToList();

            //personlangs for ViewBag
            ViewBag.personlangs = _appContext.PersonLanguages.ToList();
            //cities for ViewBag
            ViewBag.personCities = _appContext.Cities.ToList();

            //viewModel.person = person;

            //return RedirectToAction("Index",viewModel);
            return View(viewModel);
        }
       

        public IActionResult Remove(Person person)
        {
            Person personToRemove = _appContext.People.Find(person.PersonId);

            var listLanguages = _appContext.Languages.ToList();
            var personLanguages = _appContext.PersonLanguages.ToList();

            Language lant = listLanguages.Find(d => d.LanguageId == personLanguages.Find(c => c.PersonId == person.PersonId).LanguageId);

            //PersonLanguage langToDelete = _appContext.PersonLanguages.Find(person.PersonId, null); 

            PersonLanguage personLangToRemove = new PersonLanguage()
            {
                LanguageId = lant.LanguageId,
                PersonId = personToRemove.PersonId,
            };


            _appContext.People.Remove(personToRemove);
            _appContext.PersonLanguages.Remove(personLangToRemove);
            _appContext.SaveChanges();
            return RedirectToAction("Index");

        }



    }

    
    
}
