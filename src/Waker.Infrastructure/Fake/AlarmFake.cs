using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Infrastructure.Fake
{
    public class AlarmFake : IAlarmRepository
    {
        public AlarmEntity[] GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public AlarmEntity[] GetEntities(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }

        public void Set(AlarmEntity alarm)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
        public void Cancel(AlarmEntity alarm)
        {
            throw new NotImplementedException();
        }

        public void Update(AlarmEntity alarm)
        {
            throw new NotImplementedException();
        }

        public AlarmEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void OnAlarmStarted(AlarmEntity alarm)
        {
            throw new NotImplementedException();
        }

        public void Stop(AlarmEntity alarm)
        {
            throw new NotImplementedException();
        }
    }
}
