namespace ProjectMagazin_3_Workflows.Data.Models
{
    public class InvoiceDto
    {
        public string InvoiceId { get; set; }  // Primary Key
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
