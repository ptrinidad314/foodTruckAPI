using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Model
{
    public class CategorizedMenuDTO
    {
        public string categoryTitle { get; set; }
        public List<MenuItemDTO> categoryMenuItemDTOs { get; set; }
    }
}
