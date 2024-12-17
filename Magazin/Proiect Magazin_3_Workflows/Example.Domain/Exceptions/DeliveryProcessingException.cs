namespace ProjectMagazin_3_Workflows.Exceptions
{
    public class DeliveryProcessingException : Exception
    {
        public DeliveryProcessingException() : base("Delivery processing failed.")
        {
        }

        public DeliveryProcessingException(string message) : base(message)
        {
        }

        public DeliveryProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}