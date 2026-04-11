using Waker.Domain.Entities;

namespace Waker.Domain.Repositories
{
    public interface IAlarmRepository
    {
        public void OnAlarmStarted(AlarmEntity alarm);
        public void Set(AlarmEntity alarm);
        public void Stop(AlarmEntity alarm);
        public void Cancel(AlarmEntity alarm);
        public AlarmEntity GetById(int id);
        public AlarmEntity[] GetAllEntities();
        public AlarmEntity[] GetEntities(DateTime? from, DateTime? to);
    }
}
