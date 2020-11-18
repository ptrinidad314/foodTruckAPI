using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        public short CustomerId { get; set; }
        public byte StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public short AddressId { get; set; }
        public bool? Active { get; set; }

        public virtual Address Address { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
