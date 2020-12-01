using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Ftcreditcard
    {
        public long Ftcreditcardid { get; set; }
        public string Cardnumber { get; set; }
        public string CvvCode { get; set; }
        public long Ftcreditcardtypeid { get; set; }
        public string Zipcode { get; set; }
    }
}
