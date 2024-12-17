using ProjectMagazin_3_Workflows.Data.Repositories;

namespace ProjectMagazin_3_Workflows.AzureMessageHandler
{
    public class OrderEventHandler
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderEventHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task HandleAsync(string message)
        {
            Console.WriteLine($"[OrderEventHandler] Received: {message}");

            // Example: Extracting OrderId from the message
            var orderId = ExtractOrderId(message);

            if (!string.IsNullOrEmpty(orderId))
            {
                // Fetch the order from the repository
                var order = await _ordersRepository.GetByIdAsync(orderId);
                if (order != null)
                {
                    // Perform business logic (e.g., marking the order as processed)
                    order.Status = "Processed";
                    await _ordersRepository.SaveAsync(order);
                    Console.WriteLine($"[OrderEventHandler] Order {orderId} marked as processed.");
                }
                else
                {
                    Console.WriteLine($"[OrderEventHandler] Order {orderId} not found.");
                }
            }
        }

        private string ExtractOrderId(string message)
        {
            // Extract OrderId from the message, e.g., "Order 123 processed successfully"
            var parts = message.Split(' ');
            return parts.Length > 1 ? parts[1] : string.Empty;
        }
    }
}