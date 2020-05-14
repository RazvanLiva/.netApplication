using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Hospital
    {
        public Hospital()
        {
            BloodTypes = new List<BloodType>();
            Persons = new List<Person>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        #region [ Navigation Properties ]
        public City City { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<BloodType> BloodTypes { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Person> Persons { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only


        #endregion
    }
}
