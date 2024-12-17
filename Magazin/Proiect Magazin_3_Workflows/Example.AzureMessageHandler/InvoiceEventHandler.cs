namespace ProjectMagazin_3_Workflows.AzureMessageHandler
{
    public class InvoiceEventHandler
    {
        // Change void to Task to make this awaitable
        public async Task Handle(string message)
        {
            Console.WriteLine($"[Invoice Event Handler] Processing: {message}");
            // Add your specific logic for handling invoice-related messages here.
            await Task.CompletedTask; // Simulate async operation
        }
    }
}