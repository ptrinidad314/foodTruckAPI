using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Order
    {
        public long OrderId { get; set; }
        public long PaymentInfoId { get; set; }
        public string Note { get; set; }
    }
}
