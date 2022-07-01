using Microsoft.AspNetCore.Mvc;

namespace Guessing_Game.Models
{
    [BindProperties]
    public class NewPersonModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
    }
}
