using ProjectMagazin_3_Workflows.Data.Repositories;

namespace ProjectMagazin_3_Workflows.AzureMessageHandler
{
    public class DeliveryEventHandler
    {
        private readonly IDeliveriesRepository _deliveriesRepository;

        public DeliveryEventHandler(IDeliveriesRepository deliveriesRepository)
        {
            _deliveriesRepository = deliveriesRepository;
        }

        public async Task HandleAsync(string message)
        {
            Console.WriteLine($"[DeliveryEventHandler] Received: {message}");

            // Example: Extracting AWB and OrderId from the message
            var (awb, orderId) = ExtractAWBAndOrderId(message);

            if (!string.IsNullOrEmpty(awb) && !string.IsNullOrEmpty(orderId))
            {
                // Fetch delivery from repository
                var delivery = await _deliveriesRepository.GetByOrderIdAsync(orderId);
                if (delivery != null)
                {
                    // Update delivery details
                    delivery.AWB = awb;
                    delivery.IsDelivered = true;
                    await _deliveriesRepository.SaveAsync(delivery);
                    Console.WriteLine($"[DeliveryEventHandler] Delivery for Order {orderId} updated with AWB: {awb}");
                }
                else
                {
                    Console.WriteLine($"[DeliveryEventHandler] Delivery for Order {orderId} not found.");
                }
            }
        }

        private (string AWB, string OrderId) ExtractAWBAndOrderId(string message)
        {
            // Extract AWB and OrderId from the message, e.g., "AWB 12345 generated for Order 6789"
            var parts = message.Split(' ');
            string awb = parts.Length > 1 ? parts[1] : string.Empty;
            string orderId = parts.Length > 5 ? parts[5] : string.Empty;
            return (awb, orderId);
        }
    }
}