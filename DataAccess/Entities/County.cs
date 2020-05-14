using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class County
    {
        public County()
        {
            Cities = new List<City>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        #region [ Navigation Properties ] 
        public Address Address { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<City> Cities { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        #endregion
    }
}
