using Microsoft.AspNetCore.Identity;
using System;

namespace Guessing_Game.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}
