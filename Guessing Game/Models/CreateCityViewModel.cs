using System.ComponentModel.DataAnnotations;

namespace Guessing_Game.Models
{
    public class CreateCityViewModel
    {
        [Required(ErrorMessage = "Enter city name")]
        [StringLength(15)]
        public string NewCityName { get; set; }


    }
}
