using Waker.Domain.Entities;

namespace Waker.Domain.Repositories
{
    public interface IAlarmRepository
    {
        public void Set(AlarmEntity alarm);
        public void Stop();
        public void Cancel(AlarmEntity alarm);
        public AlarmEntity[] GetAllEntities();
        public AlarmEntity[] GetEntities(DateTime? from, DateTime? to);
    }
}
