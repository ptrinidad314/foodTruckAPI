using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class OrderDTO
    {
        public List<long> menuItems { get; set; }
        public string note { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string unitnumber { get; set; }
        public long stateid { get; set; }
        public string zipcode { get; set; }
        public long paymentmethodtype { get; set; }
        public string creditcardnumber { get; set; }
        public string expirationdate { get; set; }
        public string cvvcode { get; set; }
        public long creditcardtype { get; set; }
        public string paypalemail { get; set; }
        /*
        public long orderid { get; set; }
        public List<MenuItemDTO> menuItemDTOs { get; set; }
        public string note { get; set; }
        */
    }
}
