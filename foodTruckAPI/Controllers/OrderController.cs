﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodTruckAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foodTruckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {

        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
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

            return null;

            /*
            var orderResultDTO = _OrderRepository.CreateOrder(orderDTO);


            return CreatedAtRoute("GetOrder", new { orderId:orderResultDTO.orderId }, orderResultDTO);*/
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
