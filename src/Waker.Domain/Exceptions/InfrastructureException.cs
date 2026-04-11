namespace Waker.Domain.Exceptions
{
    public class InfrastructureException : WakerException
    {
        public InfrastructureException(string? message = null) : base(message)
        {
        }

        public InfrastructureException(Exception innerException, string? message = null) : base(innerException, message)
        {
        }
    }
}
