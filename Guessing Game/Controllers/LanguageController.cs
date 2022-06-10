using Guessing_Game.Data;
using Guessing_Game.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        private readonly AppDbContext _appContext;
        public LanguageController(AppDbContext config)
        {
            _appContext = config;
        }
        public IActionResult Index()
        {
            List<Language> listOfLanguages = _appContext.Languages.ToList();

            //ViewBag.Countries = _appContext.Countries.ToList();


            return View(listOfLanguages);
            
        }

        public IActionResult AddLanguage()
        {
            ViewBag.Languages = new SelectList(_appContext.Languages, "LanguageName", "LanguageName");

            return View();
        }

        [HttpPost]
        public IActionResult AddLanguage(string LanguageName)
        {

            Language language = new Language()
            {
                LanguageName = LanguageName,
                
            };

            _appContext.Languages.Add(language);
            _appContext.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Remove(Language language)
        {

            Language languageToRemove = _appContext.Languages.Find(language.LanguageId);

            _appContext.Languages.Remove(languageToRemove);
            _appContext.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
