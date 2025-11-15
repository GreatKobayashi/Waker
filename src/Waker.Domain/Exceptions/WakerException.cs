namespace Waker.Domain.Exceptions
{
    public class WakerException : Exception
    {
        protected WakerException(string? message) : base(message)
        {
        }

        protected WakerException(Exception innerException, string? message) : base(message, innerException)
        {
        }
    }
}
