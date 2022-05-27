using System.Collections.Generic;

namespace Guessing_Game.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        //navigation property
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; }

    }
}
