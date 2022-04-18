using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class AddressDTO
    {
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string unitnumber { get; set; }
        public string city { get; set; }
        public long stateid { get; set; }
        public string zipcode { get; set; }
    }
}
