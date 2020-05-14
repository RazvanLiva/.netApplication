using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Address
    {
        [ForeignKey("County")]
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }

        #region [ Navigation Properties ]
        public County County { get; set; }
        #endregion
    }
}
