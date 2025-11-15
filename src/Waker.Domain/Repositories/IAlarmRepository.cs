using Waker.Domain.Entities;

namespace Waker.Domain.Repositories
{
    public interface IAlarmRepository
    {
        public void Set(AlarmEntity alarm);
        public void Stop();
    }
}
