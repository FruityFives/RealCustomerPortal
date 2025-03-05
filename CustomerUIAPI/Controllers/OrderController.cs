using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;

namespace CustomerUIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> orders = new List<Order>();


        [HttpGet]
        [Route("getorders")]
        public List<Order> GetOrders()
        {
            return orders;
        }

        [HttpPost]
        [Route("postorder")]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return NotFound("Fejl i ordren");
            }
            // Gem ordren i databasen
            else {
                orders.Add(order);
                return Ok();
            }
            
        }
    }
}
