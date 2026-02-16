namespace Waker.Domain
{
    public static class Shared
    {
        public static bool IsFake { get; } = false;
        public static bool ResetDbOnStartUp { get; } = false;
    }
}
