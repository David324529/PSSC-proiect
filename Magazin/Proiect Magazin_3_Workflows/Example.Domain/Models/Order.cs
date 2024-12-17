namespace ProjectMagazin_3_Workflows.Domain.Models
{
    public record Order(string OrderId, List<OrderItem> Items, decimal TotalAmount)
    {
        public string Status { get; set; } = "Unvalidated"; // Initial status can be "Unvalidated"
    }

    public record OrderItem(string ProductId, int Quantity, decimal Price)
    {
        public decimal Subtotal => Quantity * Price;
    }
}