using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class MenuItemToCreateDTO
    {
        //public long menuid { get; set; }
        [Required(ErrorMessage = "title is required")]
        [MaxLength(255)]
        public string title { get; set; }
        [Required(ErrorMessage = "description is required")]
        [MaxLength(5000)]
        public string description { get; set; }
        [Required(ErrorMessage = "price is required")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "menutype is required")]
        public long menutype { get; set; }
        public long? imageid { get; set; }
    }
}
