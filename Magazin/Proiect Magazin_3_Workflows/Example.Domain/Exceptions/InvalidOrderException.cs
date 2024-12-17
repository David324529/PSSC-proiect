
namespace ProjectMagazin_3_Workflows.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException() : base("The order is invalid.")
        {
        }

        public InvalidOrderException(string message) : base(message)
        {
        }

        public InvalidOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
