namespace Waker.Domain.Handlers
{
    public interface IAlarmEventHandler
    {
        void OnAlarmStarted(int alarmId);
    }
}
