using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class BloodType
    {
        public BloodType()
        {
            Persons = new List<Person>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        #region [ Navigation Properties ]
        public Hospital Hospital { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Person> Persons { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        #endregion
    }
}
