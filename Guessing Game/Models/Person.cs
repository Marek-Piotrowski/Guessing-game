using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Guessing_Game.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }


    }
}
