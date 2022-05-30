using System.Collections.Generic;

namespace Guessing_Game.Models
{
    public class Language
    {
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}
