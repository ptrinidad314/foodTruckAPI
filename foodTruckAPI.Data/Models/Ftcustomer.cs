using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Ftcustomer
    {
        public long Ftcustomerid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public long Ftaddressidbilling { get; set; }
        public long Ftaddressidshipping { get; set; }
    }
}
