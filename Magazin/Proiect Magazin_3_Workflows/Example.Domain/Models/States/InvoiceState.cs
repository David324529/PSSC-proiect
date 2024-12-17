namespace ProjectMagazin_3_Workflows.Domain.Models.States
{
    public enum InvoiceState
    {
        Pending,  // Invoice is pending and not yet paid
        Generated, // Invoice has been generated
        Paid       // Invoice has been paid
    }
}