using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodTruckAPI.Model;
using foodTruckAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult Get()
        {
            //var model = _menuRepository.GetMenuItemDTOs();
            var model = _menuRepository.GetCategorizedMenuDTOs();

            if (model == null) 
            {
                return NotFound();
            }

            return Ok(model);

            //return new string[] { "somefood", "value2" };
        }

        // GET api/<MenuController>/5
        [HttpGet("{menuid}", Name ="GetMenu")]
        public ActionResult Get(long menuid)
        {
            var model = _menuRepository.GetMenuItemDTO(menuid);

            if (model == null) 
            {
                return NotFound();
            }

            return Ok(model);
            //return "value";
        }

        // POST api/<MenuController>
        [HttpPost]
        public ActionResult Post([FromBody] MenuItemToCreateDTO menuItemToCreateDTO)
        {
            if (menuItemToCreateDTO == null) 
            {
                return BadRequest();
            }

            if (menuItemToCreateDTO.title == menuItemToCreateDTO.description) 
            {
                ModelState.AddModelError("Title","The title must be different than the description");
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }


            MenuItemDTO createdMenuItemDTO = _menuRepository.CreateMenuItem(menuItemToCreateDTO);
            return CreatedAtRoute("GetMenu", new { menuId = createdMenuItemDTO.menuId }, createdMenuItemDTO);
        }

        // PUT api/<MenuController>/5
        [HttpPut]
        public ActionResult Put( [FromBody] MenuItemToUpdateDTO menuItemToUpdateDTO)
        {
            if (menuItemToUpdateDTO == null)
                return BadRequest();

            if (menuItemToUpdateDTO.title == menuItemToUpdateDTO.description)
                ModelState.AddModelError("Title", "The title must be different than the description");

            if(menuItemToUpdateDTO.price == 0)
                ModelState.AddModelError("Price", "The price is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_menuRepository.MenuItemExists(menuItemToUpdateDTO.menuid))
                return NotFound();

            if (_menuRepository.UpdateMenuItem(menuItemToUpdateDTO))
                return NoContent();
            else
                return BadRequest();

        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{menuid}")]
        public ActionResult Delete(long menuid)
        {
            if (!_menuRepository.MenuItemExists(menuid))
                return NotFound();

            if (_menuRepository.DeleteMenuItem(menuid))
                return NoContent();
            else
                return BadRequest();

        }
    }
}
