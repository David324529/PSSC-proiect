namespace ProjectMagazin_3_Workflows.Domain.Models.States
{
    public enum OrderState
    {
        Unvalidated, // Order has not been validated yet
        Validated,   // Order is validated and ready for processing
        Paid,        // Payment has been processed
        Processed    // Order has been fully processed
    }
}