namespace ProjectMagazin_3_Workflows.Data.Models
{
    public class DeliveryDto
    {
        public string DeliveryId { get; set; } // Primary Key
        public string OrderId { get; set; }
        public string AWB { get; set; }
        public bool IsDelivered { get; set; }
    }
}