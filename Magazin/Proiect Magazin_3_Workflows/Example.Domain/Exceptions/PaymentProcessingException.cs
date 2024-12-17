namespace ProjectMagazin_3_Workflows.Exceptions
{
    public class PaymentProcessingException : Exception
    {
        public PaymentProcessingException() : base("Payment processing failed.")
        {
        }

        public PaymentProcessingException(string message) : base(message)
        {
        }

        public PaymentProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}