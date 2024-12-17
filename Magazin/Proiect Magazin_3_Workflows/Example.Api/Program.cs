using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using ProjectMagazin_3_Workflows.Data;
using ProjectMagazin_3_Workflows.Data.Repositories;
using ProjectMagazin_3_Workflows.Events.ServiceBus;
using ProjectMagazin_3_Workflows.AzureMessageHandler;
using Example.Domain.Workflows;


var builder = WebApplication.CreateBuilder(args);

// Configure the database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configure Azure Service Bus client
string serviceBusConnectionString = builder.Configuration["ServiceBus:ConnectionString"];
var serviceBusClient = new ServiceBusClient(serviceBusConnectionString);
builder.Services.AddSingleton(serviceBusClient);

// Add repositories (Scoped)
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();

// Add event handlers (Scoped)
builder.Services.AddScoped<OrderEventHandler>();
builder.Services.AddScoped<DeliveryEventHandler>();
builder.Services.AddScoped<InvoiceEventHandler>();

// Add workflows (Scoped)
builder.Services.AddScoped<OrderWorkflow>();
builder.Services.AddScoped<InvoiceWorkflow>();
builder.Services.AddScoped<DeliveryWorkflow>();

// Add service bus event sender and listener
builder.Services.AddSingleton<ServiceBusTopicEventSender>(provider =>
    new ServiceBusTopicEventSender(serviceBusClient, "order-topic"));
builder.Services.AddSingleton<ServiceBusTopicEventListener>(provider =>
    new ServiceBusTopicEventListener(serviceBusClient, "order-topic", "order-subscription"));

// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Start the service bus listener after the app is built
var listener = app.Services.GetRequiredService<ServiceBusTopicEventListener>();
await listener.StartProcessingAsync(async (message) =>
{
    Console.WriteLine($"[Listener] Received: {message}");

    // Route messages to appropriate handlers
    if (message.Contains("Order"))
        await app.Services.GetRequiredService<OrderEventHandler>().HandleAsync(message);
    else if (message.Contains("AWB"))
        await app.Services.GetRequiredService<DeliveryEventHandler>().HandleAsync(message);
    else if (message.Contains("Invoice"))
        await app.Services.GetRequiredService<InvoiceEventHandler>().Handle(message);
});

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
