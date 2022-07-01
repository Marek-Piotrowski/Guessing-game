using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    public class ReactPeopleController : Controller
    {

        private readonly AppDbContext _appContext;
        public ReactPeopleController(AppDbContext config)
        {
            _appContext = config;
        }

        [Route("/ReactPeople/cities")]
        public ActionResult GetCitiesData()
        {

            var cities = GetCities();
            return Json(cities);
        }

        [Route("/ReactPeople/countries")]
        public ActionResult GetCountriesData()
        {

            var countries = GetCountries();
            return Json(countries);
        }

        [Route("/ReactPeople/languages")]
        public ActionResult GetLanguagesData()
        {

            var languages = GetLanguages();
            return Json(languages);
        }




        [Route("/ReactPeople")]
        public ActionResult GetUsersData()
        {
            
            var users = GetUsers();
            return Json(users);
        }

        // using bind parameters in model class
        [HttpGet]
        [Route("/ReactPeople/addNewPerson")]
        public ActionResult CreatePerson(NewPersonModel newPersonData)
        {
            NewPersonModel personToAdd = new NewPersonModel()
            {
                Name = newPersonData.Name,
                City = newPersonData.City,
                Phone = newPersonData.Phone,
                Language = newPersonData.Language,
                Country = newPersonData.Country,
            };

            // convert first letter to Uppercase
            char[] a = personToAdd.City.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            string cityWithUpper = new string(a);

            char[] b = personToAdd.Language.ToCharArray();
            b[0] = char.ToUpper(b[0]);
            string languageWithUpper = new string(b);

            char[] c = personToAdd.Name.ToCharArray();
            c[0] = char.ToUpper(c[0]);
            string nameWithUpper = new string(c);

            var languages = _appContext.Languages.ToList();
            var cities = _appContext.Cities.ToList();
            var countries = _appContext.Countries.ToList();

            if (ModelState.IsValid)
            {
                Person personModel = new Person()
                {
                    Name = nameWithUpper,
                    PhoneNumber = personToAdd.Phone,
                    CityId = cities.Find(c =>c.CityName == cityWithUpper).CityId

                };

                _appContext.People.Add(personModel);
                _appContext.SaveChanges();

                PersonLanguage personlanguage = new PersonLanguage()
                {
                    PersonId = personModel.PersonId,
                    LanguageId = languages.Find(t => t.LanguageName == languageWithUpper).LanguageId,
                };

                _appContext.PersonLanguages.Add(personlanguage);
                _appContext.SaveChanges();


                return new StatusCodeResult(200);
            }

            return new StatusCodeResult(404);
        }



        [HttpGet]
        [Route("/ReactPeople/{personId?}")]
        public ActionResult PersonDetails(int personId)
        {

            PersonToEditModel model = new PersonToEditModel();
            //int userId = int.Parse(personId);
            int userId = personId;


            Person personToEdit = _appContext.People.Find(userId);

            if(personToEdit != null)
            {
                var listLanguages = _appContext.Languages.ToList();
                var personLanguages = _appContext.PersonLanguages.ToList();
                Language lant = listLanguages.Find(d => d.LanguageId == personLanguages.Find(c => c.PersonId == userId).LanguageId);
                City city = _appContext.Cities.FirstOrDefault(c => c.CityId == personToEdit.CityId);

                ViewBag.Cities = new SelectList(_appContext.Cities, "CityName", "CityName");
                ViewBag.Languages = new SelectList(_appContext.Languages, "LanguageName", "LanguageName");


                model.Person = personToEdit;
                model.LanguageName = lant.LanguageName;
                model.CityName = city.CityName;


                return Json(new { name = model.Person.Name, phone = model.Person.PhoneNumber, city = model.CityName, language = model.LanguageName });

            }

            return new StatusCodeResult(404) ;

               
        }

        // delete action
        [Route("/ReactPeople/delete/{personId?}")]
        public ActionResult PersonToDelete(int personId)
        {
            int userId = personId;

            Person personToRemove = _appContext.People.Find(userId);

            if (personToRemove != null)
            {
                var listLanguages = _appContext.Languages.ToList();
                var personLanguages = _appContext.PersonLanguages.ToList();

                Language lant = listLanguages.Find(d => d.LanguageId == personLanguages.Find(c => c.PersonId == userId).LanguageId);

                //PersonLanguage langToDelete = _appContext.PersonLanguages.Find(person.PersonId, null); 

                PersonLanguage personLangToRemove = new PersonLanguage()
                {
                    LanguageId = lant.LanguageId,
                    PersonId = personToRemove.PersonId,
                };


                _appContext.People.Remove(personToRemove);
                _appContext.PersonLanguages.Remove(personLangToRemove);
                _appContext.SaveChanges();

                return new StatusCodeResult(200);
            }

            return new StatusCodeResult(404);
        }




        // functions
        private List<Person> GetUsers()
        {
            var usersList = _appContext.People.ToList();


            return usersList;
        }

        private List<Country> GetCountries()
        {
            var countriesList = _appContext.Countries.ToList();


            return countriesList;
        }


        private List<City> GetCities()
        {
            var CitiesList = _appContext.Cities.ToList();


            return CitiesList;
        }

        private List<Language> GetLanguages()
        {
            var languagesList = _appContext.Languages.ToList();


            return languagesList;
        }


        
    }
}
