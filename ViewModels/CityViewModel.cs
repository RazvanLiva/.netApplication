using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class CityViewModel
    {
        public CityViewModel()
        {
            Hospitals = new List<HospitalViewModel>();
            Persons = new List<PersonViewModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public CountyViewModel County { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public List<HospitalViewModel> Hospitals { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning disable CA2227 // Collection properties should be read only
        public List<PersonViewModel> Persons { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
