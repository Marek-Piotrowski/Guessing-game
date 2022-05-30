using Guessing_Game.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    
    public class AjaxController : Controller
    {
        [Route("/Ajax")]
        public IActionResult Index()
        {
            

            return View();
        }

        [Route("/Ajax/People")]
        public IActionResult People()
        {
            PeopleViewModel model = new PeopleViewModel();
            model.people = PeopleList._list;


            return PartialView("_PersonList",model.people);
        }

        [HttpPost]
        [Route("/Ajax/{personID?}")]
        public IActionResult Index(string personID)
        {
            //PeopleViewModel model = new PeopleViewModel();

            int number = int.Parse(personID);

            

            if (PeopleList._list.Find(x => x.Id == number) != null)
            {
                Person queryperson = PeopleList._list.Find(x => x.Id == number);

                return PartialView("_PersonItem",queryperson);
            }


            return PartialView("_IdNotFound");
        }

        [HttpPost]
        [Route("/Ajax/Delete/{personID?}")]
        public IActionResult Delete(string personID)
        {
            

            int number = int.Parse(personID);



            if (PeopleList._list.Find(x => x.Id == number) != null)
            {
                Person queryperson = PeopleList._list.Find(x => x.Id == number);

                PeopleList._list.Remove(queryperson);

                return PartialView("_onSuccessDelete", queryperson);
            }


            return PartialView("_DeleteMessage");
        }



    }
}
