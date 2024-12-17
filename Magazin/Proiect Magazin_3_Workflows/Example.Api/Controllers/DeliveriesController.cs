
using Example.Domain.Workflows;
using Microsoft.AspNetCore.Mvc;

using ProjectMagazin_3_Workflows.Domain.Models;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveryWorkflow _deliveryWorkflow;

        public DeliveriesController(DeliveryWorkflow deliveryWorkflow)
        {
            _deliveryWorkflow = deliveryWorkflow;
        }

        // Get all deliveries
        [HttpGet]
        public async Task<IActionResult> GetDeliveries()
        {
            var deliveries = await _deliveryWorkflow.GetAllDeliveriesAsync();
            return Ok(deliveries);
        }

        // Create a new delivery
        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Invalid order details.");

            await _deliveryWorkflow.ExecuteAsync(order);
            return Ok("Delivery processed successfully.");
        }
    }
}