using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class Menu
    {
        public long Menuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Menutype { get; set; }
        public long Imageid { get; set; }
    }
}
