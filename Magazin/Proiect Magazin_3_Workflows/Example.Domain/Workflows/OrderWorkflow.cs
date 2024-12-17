using ProjectMagazin_3_Workflows.Data.Repositories;
using ProjectMagazin_3_Workflows.Data.Models;
using ProjectMagazin_3_Workflows.Domain.Models;
using ProjectMagazin_3_Workflows.Events.ServiceBus;

namespace Example.Domain.Workflows
{
    public class OrderWorkflow
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ServiceBusTopicEventSender _eventSender;

        public OrderWorkflow(IOrdersRepository ordersRepository, ServiceBusTopicEventSender eventSender)
        {
            _ordersRepository = ordersRepository;
            _eventSender = eventSender;
        }

        // Method to retrieve all orders
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await _ordersRepository.GetAllAsync(); // Assuming you have a GetAll method in the repository
        }

        public async Task ExecuteAsync(Order order)
        {
            // Example logic for processing orders, like validating and processing payments
            string message = $"Order {order.OrderId} has been successfully processed.";
            await _eventSender.SendEventAsync(message);

            Console.WriteLine($"Order {order.OrderId} processed and event sent.");
        }
    }
}