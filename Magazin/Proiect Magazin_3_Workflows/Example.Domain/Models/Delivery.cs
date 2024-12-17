namespace ProjectMagazin_3_Workflows.Domain.Models
{
    public record Delivery(string DeliveryId, string OrderId, string AWB, bool IsDelivered)
    {
        public string Status { get; set; } = "Pending"; // Initial status can be "Pending"
    }
}