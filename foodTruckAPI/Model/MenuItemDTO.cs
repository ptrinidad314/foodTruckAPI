using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace foodTruckAPI.Model
{
    public class MenuItemDTO
    {
        public long menuId { get; set; }
      
        public string title { get; set; }
     
        public string description { get; set; }
       
        public decimal price { get; set; }
       
        public string imageUrl { get; set; }

    }
}
