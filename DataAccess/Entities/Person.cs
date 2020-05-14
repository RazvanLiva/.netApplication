using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Person
    {
        public Person()
        {
            BloodTypes = new List<BloodType>();
        }

        public Guid Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string InfectedWithCovid { get; set; }
        public string Recovery { get; set; }

        #region [ Navigation Properties ]
        public City City { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<BloodType> BloodTypes { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        public Hospital Hospital { get; set; }
        #endregion
    }
}
