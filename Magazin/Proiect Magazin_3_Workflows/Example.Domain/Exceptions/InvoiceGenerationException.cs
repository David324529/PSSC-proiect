namespace ProjectMagazin_3_Workflows.Exceptions
{
    public class InvoiceGenerationException : Exception
    {
        public InvoiceGenerationException() : base("Error occurred while generating the invoice.")
        {
        }

        public InvoiceGenerationException(string message) : base(message)
        {
        }

        public InvoiceGenerationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}