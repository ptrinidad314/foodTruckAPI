using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class MenuItemToUpdateDTO
    {
        [Required(ErrorMessage = "menuid is required")]
        public long menuid { get; set; }
        [Required(ErrorMessage = "title is required")]
        [MaxLength(255)]
        public string title { get; set; }
        [Required(ErrorMessage = "description is required")]
        [MaxLength(5000)]
        public string description { get; set; }
        [Required(ErrorMessage = "price is required")]
        [Range(0.01,100)]
        public decimal price { get; set; }
        [Required(ErrorMessage ="menu type is required")]
        public long menutype { get; set; }
        public long? imageid { get; set; }
    }
}
