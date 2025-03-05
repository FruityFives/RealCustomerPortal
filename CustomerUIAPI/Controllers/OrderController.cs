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

        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("getorders")]
        public List<Order> GetOrders()
        {
            return orders;
        }

        [HttpPost]
        [Route("postorder")]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return NotFound("Fejl i ordren");
            }

            // Opret HTTP-klient
            var client = _httpClientFactory.CreateClient("MyApiClient");

            // Send POST-anmodning med ordren til ekstern service
            var response = await client.PostAsJsonAsync("orders", order);

            if (response.IsSuccessStatusCode)
            {
                // Ordren blev gemt korrekt i den eksterne service
                return Ok();
            }
            else
            {
                // Håndter fejl fra den eksterne service
                return StatusCode((int)response.StatusCode, "Fejl ved oprettelse af ordre");
            }
        }
    }
}
