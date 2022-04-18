using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class CreateOrderResultDTO
    {
        public long orderId { get; set; }
        public List<string> errorMessages { get; set; } = new List<string>();
        public bool orderComplete { get; set; } = false;
    }
}
