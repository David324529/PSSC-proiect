using Azure.Messaging.ServiceBus;

namespace ProjectMagazin_3_Workflows.Events.ServiceBus
{
    public class ServiceBusTopicEventListener
    {
        private readonly ServiceBusProcessor _processor;

        public ServiceBusTopicEventListener(ServiceBusClient client, string topicName, string subscriptionName)
        {
            _processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());
        }

        public async Task StartProcessingAsync(Func<string, Task> messageHandler)
        {
            _processor.ProcessMessageAsync += async args =>
            {
                var body = args.Message.Body.ToString();
                Console.WriteLine($"Received message: {body}");
                await messageHandler(body);
                await args.CompleteMessageAsync(args.Message);
            };

            _processor.ProcessErrorAsync += args =>
            {
                Console.WriteLine($"Message handler encountered an error: {args.Exception.Message}");
                return Task.CompletedTask;
            };

            await _processor.StartProcessingAsync();
            Console.WriteLine("Event listener started...");
        }

        public async Task StopProcessingAsync()
        {
            await _processor.StopProcessingAsync();
            Console.WriteLine("Event listener stopped.");
        }
    }
}