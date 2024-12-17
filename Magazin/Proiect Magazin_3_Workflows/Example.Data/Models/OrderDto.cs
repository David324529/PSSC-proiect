namespace ProjectMagazin_3_Workflows.Data.Models
{
    public class OrderDto
    {
        public string OrderId { get; set; }  // Primary Key
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}