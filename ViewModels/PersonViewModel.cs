using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            BloodTypes = new List<BloodTypeViewModel>();
        }

        public Guid Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string InfectedWithCovid { get; set; }
        public string Recovery { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
#pragma warning disable CA2227 // Collection properties should be read only
        public List<BloodTypeViewModel> BloodTypes { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
