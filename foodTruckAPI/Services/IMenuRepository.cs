using foodTruckAPI.Data.Models;
using foodTruckAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Services
{
    public interface IMenuRepository
    {
        List<Menu> GetMenu();
        List<CategorizedMenuDTO> GetCategorizedMenuDTOs();
        List<MenuItemDTO> GetMenuItemDTOs();
        MenuItemDTO GetMenuItemDTO(long menuId);
        MenuItemDTO CreateMenuItem(MenuItemToCreateDTO menuItemToCreateDTO);
        bool UpdateMenuItem(MenuItemToUpdateDTO menuItemToUpdateDTO);
        bool DeleteMenuItem(long menuid);
        bool MenuItemExists(long menuid);
        
    }
}
