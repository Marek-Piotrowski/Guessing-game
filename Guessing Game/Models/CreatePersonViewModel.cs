using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Guessing_Game.Models
{
    public  class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [StringLength(15)]
        public string NewName { get; set; }

        public string CityId { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string NewPhone { get; set; }

        public List<PersonLanguage> lang { get; set; }

        
        
        
    }
}
