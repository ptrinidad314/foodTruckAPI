using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public short CountryId { get; set; }
        public string Country1 { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
