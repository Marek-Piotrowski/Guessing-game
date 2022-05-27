using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guessing_Game.Models
{
    public class Person
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //navigation property
        public int CityId { get; set; }
        public City City { get; set; }


    }
}
