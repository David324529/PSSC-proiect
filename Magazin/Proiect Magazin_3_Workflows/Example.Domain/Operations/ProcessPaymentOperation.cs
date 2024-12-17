using ProjectMagazin_3_Workflows.Domain.Models;

namespace ProjectMagazin_3_Workflows.Domain.Operations
{
    public class ProcessPaymentOperation
    {
        public async Task<bool> ProcessAsync(Order order)
        {
            // Simulating payment processing
            await Task.Delay(500); // Adjust the delay for real-world scenarios
            return order.TotalAmount > 0;
        }
    }
}