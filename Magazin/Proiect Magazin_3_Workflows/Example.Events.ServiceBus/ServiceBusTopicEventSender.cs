using Azure.Messaging.ServiceBus;

namespace ProjectMagazin_3_Workflows.Events.ServiceBus
{
    public class ServiceBusTopicEventSender
    {
        private readonly ServiceBusSender _sender;

        public ServiceBusTopicEventSender(ServiceBusClient client, string topicName)
        {
            _sender = client.CreateSender(topicName);
        }

        public async Task SendEventAsync(string messageBody)
        {
            var message = new ServiceBusMessage(messageBody);
            await _sender.SendMessageAsync(message);
            Console.WriteLine($"Event sent: {messageBody}");
        }
    }
}