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
    public class OrderController : ControllerBase
    {
        IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult Get()
        {
            return null;

            //return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        // [HttpGet("{menuid}", Name ="GetMenu")]
        [HttpGet("{orderid}", Name = "GetOrder")]
        public string Get(long orderid)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderDTO orderDTO)
        {
            if (orderDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var createOrderResultDTO = _orderRepository.CreateOrder(orderDTO);
            
            return CreatedAtRoute("GetOrder", new { orderid = createOrderResultDTO.orderId }, createOrderResultDTO);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
