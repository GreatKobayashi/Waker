namespace Waker.Domain.Exceptions
{
    public class DeviceException : WakerException
    {
        public DeviceException(string? message = null) : base(message)
        {
        }

        public DeviceException(Exception innerException, string? message = null) : base(innerException, message)
        {
        }
    }
}
