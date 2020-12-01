using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Ftpayment
    {
        public long Ftpaymentid { get; set; }
        public long Ftcustomerid { get; set; }
        public decimal Ftpaymentamount { get; set; }
        public long? Ftpaymenttypeid { get; set; }
        public byte Ftpaymentcomplete { get; set; }
    }
}
