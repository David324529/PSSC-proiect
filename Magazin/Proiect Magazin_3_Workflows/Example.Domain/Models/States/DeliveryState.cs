namespace ProjectMagazin_3_Workflows.Domain.Models.States
{
    public enum DeliveryState
    {
        Pending,    // Delivery is pending
        InTransit,  // Delivery is in transit
        Delivered,  // Delivery has been completed
        Failed      // Delivery failed or could not be completed
    }
}