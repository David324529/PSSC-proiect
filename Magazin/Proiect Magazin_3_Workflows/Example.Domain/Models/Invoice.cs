namespace ProjectMagazin_3_Workflows.Domain.Models
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending"; // Default status is "Pending"
    }
}