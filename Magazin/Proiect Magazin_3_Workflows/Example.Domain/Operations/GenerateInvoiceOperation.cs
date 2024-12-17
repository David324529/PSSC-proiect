
using ProjectMagazin_3_Workflows.Domain.Models;

namespace ProjectMagazin_3_Workflows.Domain.Operations
{
    public class GenerateInvoiceOperation
    {
        public Invoice Generate(Order order)
        {
            return new Invoice
            {
                InvoiceId = Guid.NewGuid().ToString(),
                OrderId = order.OrderId,
                Amount = order.TotalAmount,
                IsPaid = false
            };
        }
    }
}