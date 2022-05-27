using System.Collections.Generic;

namespace Guessing_Game.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        //navigation property
        
        public List<City> Cities { get; set;}

        
    }
}
