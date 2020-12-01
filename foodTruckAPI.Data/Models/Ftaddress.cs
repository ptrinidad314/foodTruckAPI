using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Ftaddress
    {
        public long Ftaddressid { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Unitnumber { get; set; }
        public string City { get; set; }
        public long Stateid { get; set; }
        public string Zipcode { get; set; }
    }
}
