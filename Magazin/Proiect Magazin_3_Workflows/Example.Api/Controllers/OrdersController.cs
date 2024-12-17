
using Example.Domain.Workflows;
using Microsoft.AspNetCore.Mvc;
using ProjectMagazin_3_Workflows.Data.Models;
using ProjectMagazin_3_Workflows.Domain.Models;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderWorkflow _orderWorkflow;

        public OrdersController(OrderWorkflow orderWorkflow)
        {
            _orderWorkflow = orderWorkflow;
        }

        // Get all orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderWorkflow.GetAllOrdersAsync();
            return Ok(orders);
        }

        // Create a new order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Invalid order details.");

            await _orderWorkflow.ExecuteAsync(order);
            return Ok("Order processed successfully.");
        }
    }
}