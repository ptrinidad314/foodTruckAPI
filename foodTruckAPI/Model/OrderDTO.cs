using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class OrderDTO
    {
        public List<int> menuItems { get; set; }
        public string note { get; set; }

        /*
        public long orderid { get; set; }
        public List<MenuItemDTO> menuItemDTOs { get; set; }
        public string note { get; set; }
        */
    }
}
