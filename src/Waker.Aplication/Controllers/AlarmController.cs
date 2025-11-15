using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Aplication.Controllers
{
    public class AlarmController
    {
        private IAlarmRepository _alarmRepository;

        public AlarmController(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public void Set(AlarmEntity alarm)
        {
            _alarmRepository.Set(alarm);
        }

        public void Stop()
        {
            _alarmRepository.Stop();
        }
    }
}
