
using Example.Domain.Workflows;
using Microsoft.AspNetCore.Mvc;
using ProjectMagazin_3_Workflows.Data.Models;
using ProjectMagazin_3_Workflows.Domain.Models;

namespace Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceWorkflow _invoiceWorkflow;

        public InvoicesController(InvoiceWorkflow invoiceWorkflow)
        {
            _invoiceWorkflow = invoiceWorkflow;
        }

        // Get all invoices
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceWorkflow.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        // Generate a new invoice
        [HttpPost]
        public async Task<IActionResult> GenerateInvoice([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Invalid order details.");

            await _invoiceWorkflow.ExecuteAsync(order);
            return Ok("Invoice generated successfully.");
        }
    }
}