using ProjectMagazin_3_Workflows.Data.Repositories;
using ProjectMagazin_3_Workflows.Data.Models;
using ProjectMagazin_3_Workflows.Domain.Models;
using ProjectMagazin_3_Workflows.Domain.Operations;
using ProjectMagazin_3_Workflows.Events.ServiceBus;

namespace Example.Domain.Workflows
{
    public class DeliveryWorkflow
    {
        private readonly IDeliveriesRepository _deliveriesRepository;
        private readonly ServiceBusTopicEventSender _eventSender;

        public DeliveryWorkflow(IDeliveriesRepository deliveriesRepository, ServiceBusTopicEventSender eventSender)
        {
            _deliveriesRepository = deliveriesRepository;
            _eventSender = eventSender;
        }

        // Method to retrieve all deliveries
        public async Task<IEnumerable<DeliveryDto>> GetAllDeliveriesAsync()
        {
            return await _deliveriesRepository.GetAllAsync(); // Assuming you have a GetAll method in the repository
        }

        public async Task ExecuteAsync(Order order)
        {
            var awbOperation = new GenerateAWBOperation();
            var awb = awbOperation.Generate(order);

            Console.WriteLine($"AWB {awb} generated for Order {order.OrderId}");

            // Send event for the generated AWB
            string message = $"AWB {awb} generated for Order {order.OrderId}";
            await _eventSender.SendEventAsync(message);

            Console.WriteLine($"AWB event sent for Order {order.OrderId}");
        }
    }
}