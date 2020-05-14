using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CreateCityViewModel
    {

        
        public string Name { get; set; }
        public Guid CountyId { get; set; }
    }
}
