using System.Collections.Generic;
using System.Linq;

namespace Guessing_Game.Models
{
    public class PeopleViewModel
    {
        
        public  List<Person> people;

        //public static List<Person> GetPersonList()
        //{

        //    var persons = new List<Person>()
        //    {
        //        new Person() { Name = "Joe", City = "Liverpool", PhoneNumber = "700-309-341", PersonId = 1 },
        //        new Person() { Name = "Ben", City = "London", PhoneNumber = "702-307-348", PersonId = 2 },
        //        new Person() { Name = "Michael", City = "Manchaster", PhoneNumber = "707-395-383", PersonId = 3 },
        //        new Person() { Name = "Jeff", City = "Madrid", PhoneNumber = "710-383-374", PersonId = 4 },
        //        new Person() { Name = "Brad", City = "Barcelona", PhoneNumber = "775-346-312", PersonId = 5 },
        //        new Person() { Name = "Tony", City = "New York", PhoneNumber = "789-383-336", PersonId = 6 },
        //        new Person() { Name = "Luka", City = "Los Angeles", PhoneNumber = "775-314-347", PersonId = 7 },
        //        new Person() { Name = "Mariano", City = "Miami", PhoneNumber = "796-350-321", PersonId = 8 },
        //        new Person() { Name = "Josef", City = "Stockholm", PhoneNumber = "763-385-323", PersonId = 9 },
        //        new Person() { Name = "Gilbert", City = "Warszawa", PhoneNumber = "774-375-333", PersonId = 10 },
        //    };

        //    return persons;

        //}

        //public CreatePersonViewModel person  = new CreatePersonViewModel();
        public CreatePersonViewModel person;
        
    }
}
