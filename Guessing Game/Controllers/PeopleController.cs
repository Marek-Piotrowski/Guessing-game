using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    
    public class PeopleController : Controller
    {
        

        [Route("/People")]
        public IActionResult Index(string searchQuery = null)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewModel = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewModel.people = PeopleList._list;

            string search = null;

            if(searchQuery != null)
            {
                search = searchQuery.ToLower();
            }
            

            if(search != null)
            {
                persons = PeopleList._list.Where(p => p.Name.ToLower().Contains(searchQuery) || p.City.ToLower().Contains(searchQuery) || p.PhoneNumber.ToLower().Contains(searchQuery)).ToList();

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

            int number = PeopleList._list.Count + 1;

            if (ModelState.IsValid)
            {
                Person personModel = new Person()
                {
                    Name = person.NewName,
                    City = person.NewCity,
                    PhoneNumber = person.NewPhone,
                    PersonId = number,
                };

                PeopleList._list.Add(personModel);

                viewModel.person = person;
                viewModel.people = PeopleList._list;

                return View(viewModel);
                
            }

            viewModel.people = PeopleList._list;
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

            viewModel.people = PeopleList._list;

            int number = int.Parse(id);

            Person PersonToDelete = PeopleList._list.Find(x => x.PersonId == number);

            PeopleList._list.Remove(PersonToDelete);

            viewModel.people = PeopleList._list;


            //people = PeopleViewModel.GetPersonList().Where(p => p.Name != id).ToList();

            return View("Index",viewModel);
        }







    }

    
    
}
