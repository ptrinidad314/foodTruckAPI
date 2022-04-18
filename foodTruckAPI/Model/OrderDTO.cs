using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;

namespace foodTruckAPI.Model
{
    public class OrderDTO
    {
        public List<long> menuItems { get; set; }
        public string note { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }
        public AddressDTO billing_address { get; set; }

        public AddressDTO shipping_address { get; set; }
        public bool billing_address_sameAs_shipping_address { get; set; }

        public long paymentmethodtype { get; set; }
        [CreditCard]
        public string creditcardnumber { get; set; }
        public string expirationdate { get; set; }
        public string cvvcode { get; set; }
        
        public long creditcardtype { get; set; }
        [EmailAddress]
        public string paypalemail { get; set; }
        /*
        public long orderid { get; set; }
        public List<MenuItemDTO> menuItemDTOs { get; set; }
        public string note { get; set; }
        */
    }
}
