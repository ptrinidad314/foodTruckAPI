using foodTruckAPI.Data.Models;
using foodTruckAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Services
{
    public class MenuRepository : IMenuRepository
    {
        public List<Menu> GetMenu()
        {
            using (var db = new sakilaContext()) 
            {
                return db.Menu.ToList();
            }
        }

        public List<CategorizedMenuDTO> GetCategorizedMenuDTOs() 
        {
            try
            {
                using (var db = new sakilaContext())
                {
                    var menuTypes = db.Menutype.ToList();
                    List<CategorizedMenuDTO> categorizedMenuDTOs = new List<CategorizedMenuDTO>();

                    foreach (Menutype mt in menuTypes)
                    {
                        CategorizedMenuDTO categorizedMenuDTO = new CategorizedMenuDTO();

                        categorizedMenuDTO.categoryTitle = mt.Description;
                        categorizedMenuDTO.categoryMenuItemDTOs = (from row in db.Menu
                                                                   join image in db.Image on row.Imageid equals image.Imageid
                                                                   where row.Menutype == mt.Menutypeid
                                                                   select new MenuItemDTO
                                                                   {
                                                                       menuId = row.Menuid,
                                                                       title = row.Title,
                                                                       description = row.Description,
                                                                       price = row.Price,
                                                                       imageUrl = image.ImageUrl
                                                                   }).ToList();

                        categorizedMenuDTOs.Add(categorizedMenuDTO);                        
                    }

                    return categorizedMenuDTOs;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public List<MenuItemDTO> GetMenuItemDTOs()
        {
            try
            {
                using (var db = new sakilaContext())
                {
                    var menuItemDTOs = (from row in db.Menu
                                        join image in db.Image on row.Imageid equals image.Imageid
                                        select new MenuItemDTO
                                        {
                                            menuId = row.Menuid,
                                            title = row.Title,
                                            description = row.Description,
                                            price = row.Price,
                                            imageUrl = image.ImageUrl
                                        }).ToList();

                    return menuItemDTOs;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public MenuItemDTO GetMenuItemDTO(long menuId) 
        {
            try
            {
                using (var db = new sakilaContext())
                {
                    var menuItemDTO = (from row in db.Menu
                                       join image in db.Image on row.Imageid equals image.Imageid
                                       where row.Menuid == menuId
                                       select new MenuItemDTO
                                       {
                                           menuId = row.Menuid,
                                           title = row.Title,
                                           description = row.Description,
                                           price = row.Price,
                                           imageUrl = image.ImageUrl
                                       }).FirstOrDefault();

                    return menuItemDTO;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public MenuItemDTO CreateMenuItem(MenuItemToCreateDTO menuItemToCreateDTO)
        {

            using (var db = new sakilaContext())
            {
                Menu menuToCreate = new Menu();

                menuToCreate.Description = menuItemToCreateDTO.description;
                menuToCreate.Menutype = menuItemToCreateDTO.menutype;
                menuToCreate.Price = menuItemToCreateDTO.price;
                menuToCreate.Title = menuItemToCreateDTO.title;

                if (menuItemToCreateDTO.imageid != null)
                    menuToCreate.Imageid = (long)menuItemToCreateDTO.imageid;
                else
                    menuToCreate.Imageid = 1;

                db.Menu.Add(menuToCreate);

                db.SaveChanges();

                MenuItemDTO menuItemDTOToReturn = new MenuItemDTO();
                menuItemDTOToReturn.description = menuToCreate.Description;
                menuItemDTOToReturn.imageUrl = db.Image.Where(i => i.Imageid == menuToCreate.Imageid).FirstOrDefault().ImageUrl;
                menuItemDTOToReturn.menuId = menuToCreate.Menuid;
                menuItemDTOToReturn.price = menuToCreate.Price;
                menuItemDTOToReturn.title = menuToCreate.Title;

                return menuItemDTOToReturn;
            }
        }

        public bool UpdateMenuItem(MenuItemToUpdateDTO menuItemToUpdateDTO) 
        {
            try
            {
                using (var db = new sakilaContext())
                {
                    Menu menuToUpdate = db.Menu.Where(m => m.Menuid == menuItemToUpdateDTO.menuid).FirstOrDefault();

                    menuToUpdate.Description = menuItemToUpdateDTO.description;
                    if (menuItemToUpdateDTO.imageid != null)
                        menuToUpdate.Imageid = (long)menuItemToUpdateDTO.imageid;

                    menuToUpdate.Menutype = menuItemToUpdateDTO.menutype;
                    menuToUpdate.Price = menuItemToUpdateDTO.price;
                    menuToUpdate.Title = menuItemToUpdateDTO.title;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool DeleteMenuItem(long menuid) 
        {
            try
            {
                using (var db = new sakilaContext()) 
                {
                    Menu menuItemToDelete = db.Menu.Where(m => m.Menuid == menuid).FirstOrDefault();

                    if (menuItemToDelete == null)
                        return false;

                    db.Menu.Remove(menuItemToDelete);
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool MenuItemExists(long menuid) 
        {
            try
            {
                using (var db = new sakilaContext())
                {
                    Menu menuItem = db.Menu.Where(m => m.Menuid == menuid).FirstOrDefault();

                    if (menuItem != null)
                        return true;

                    return false;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

    }
}
