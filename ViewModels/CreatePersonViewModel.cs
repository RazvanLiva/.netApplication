using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Age is mandatory")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Required(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }
        public string InfectedWithCovid { get; set; }
        public string Recovery { get; set; }
        public Guid CityId { get; set; }
    }
}
