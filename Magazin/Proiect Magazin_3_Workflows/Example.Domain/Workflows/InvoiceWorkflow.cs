using ProjectMagazin_3_Workflows.Data.Repositories;
using ProjectMagazin_3_Workflows.Data.Models;
using ProjectMagazin_3_Workflows.Domain.Models;
using ProjectMagazin_3_Workflows.Domain.Operations;
using ProjectMagazin_3_Workflows.Events.ServiceBus;

namespace Example.Domain.Workflows
{
    public class InvoiceWorkflow
    {
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly ServiceBusTopicEventSender _eventSender;

        public InvoiceWorkflow(IInvoicesRepository invoicesRepository, ServiceBusTopicEventSender eventSender)
        {
            _invoicesRepository = invoicesRepository;
            _eventSender = eventSender;
        }

        // Method to retrieve all invoices
        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            return await _invoicesRepository.GetAllAsync(); // Assuming you have a GetAll method in the repository
        }

        public async Task ExecuteAsync(Order order)
        {
            var invoiceGenerator = new GenerateInvoiceOperation();
            var invoice = invoiceGenerator.Generate(order);

            Console.WriteLine($"Invoice generated for Order {order.OrderId}: {invoice.Amount}");

            // Send event for the generated invoice
            string message = $"Invoice {invoice.InvoiceId} generated for Order {order.OrderId}";
            await _eventSender.SendEventAsync(message);

            Console.WriteLine($"Invoice event sent for Invoice ID {invoice.InvoiceId}");
        }
    }
}