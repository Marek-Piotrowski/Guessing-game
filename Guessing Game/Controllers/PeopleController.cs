using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
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

            string search = null;

            if(searchQuery != null)
            {
                search = searchQuery.ToLower();
            }
            

            if(search != null)
            {
                persons = _appContext.People.Where(p => p.Name.ToLower().Contains(searchQuery) || p.City.ToLower().Contains(searchQuery) || p.PhoneNumber.ToLower().Contains(searchQuery)).ToList();

                viewModel.people = persons;
                viewModel.person = newPerson;

                return View(viewModel);
            }
            
            
            return View(viewModel);
        }

        [HttpPost]
        [Route("/People")]
        public IActionResult Index(CreatePersonViewModel person )
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            int number = _appContext.People.Count() + 1;

            if (ModelState.IsValid)
            {
                Person personModel = new Person()
                {
                    Name = person.NewName,
                    City = person.NewCity,
                    PhoneNumber = person.NewPhone,
                    PersonId = number,
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

        
        [Route("/People/{id?}")]
        public IActionResult RemoveUser(string id)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewModel = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewModel.people = _appContext.People.ToList();

            int number = int.Parse(id);

            Person PersonToDelete = _appContext.People.FirstOrDefault(x => x.PersonId == number); //Find(x => x.PersonId == number);  //(x => x.PersonId == number);

             _appContext.People.Remove(PersonToDelete);
            _appContext.SaveChanges();

            viewModel.people = _appContext.People.ToList();


            //people = PeopleViewModel.GetPersonList().Where(p => p.Name != id).ToList();

            return View("Index",viewModel);
        }







    }

    
    
}
