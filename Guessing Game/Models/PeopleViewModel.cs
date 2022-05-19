using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Models
{
    public class PeopleViewModel
    {
        
        public  List<Person> people = GetPersonList();
        
        public static List<Person> GetPersonList()
        {

            var persons = new List<Person>()
            {
                new Person() { Name = "Joe", City = "Liverpool", PhoneNumber = "700-309-341", Id = 1 },
                new Person() { Name = "Ben", City = "London", PhoneNumber = "702-307-348", Id = 2 },
                new Person() { Name = "Michael", City = "Manchaster", PhoneNumber = "707-395-383", Id = 3 },
                new Person() { Name = "Jeff", City = "Madrid", PhoneNumber = "710-383-374", Id = 4 },
                new Person() { Name = "Brad", City = "Barcelona", PhoneNumber = "775-346-312", Id = 5 },
                new Person() { Name = "Tony", City = "New York", PhoneNumber = "789-383-336", Id = 6 },
                new Person() { Name = "Luka", City = "Los Angeles", PhoneNumber = "775-314-347", Id = 7 },
                new Person() { Name = "Mariano", City = "Miami", PhoneNumber = "796-350-321", Id = 8 },
                new Person() { Name = "Josef", City = "Stockholm", PhoneNumber = "763-385-323", Id = 9 },
                new Person() { Name = "Gilbert", City = "Warszawa", PhoneNumber = "774-375-333", Id = 10 },
            };

            return persons;

        }

        public CreatePersonViewModel person  = new CreatePersonViewModel();
        
    }
}
