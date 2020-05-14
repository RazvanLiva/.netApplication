using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class City
    {
        public City()
        {
            Hospitals = new List<Hospital>();
            Persons = new List<Person>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        #region [ Navigation Properties ]
        public County County { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Hospital> Hospitals { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Person> Persons { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        #endregion
    }
}
