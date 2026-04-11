using Waker.Domain.Entities;
using Waker.Domain.Handlers;
using Waker.Domain.Repositories;

namespace Waker.Aplication.Controllers
{
    public class AlarmController : IAlarmEventHandler
    {
        private IAlarmRepository _alarmRepositoryDevice;
        private IAlarmRepository _alarmRepositoryRec;
        private ISoundRepository _soundRepository;
        private int _ringingAlarmId;

        public AlarmController(IAlarmRepository alarmRepositoryDevice, IAlarmRepository alarmRepositoryDb, ISoundRepository soundRepository)
        {
            _alarmRepositoryDevice = alarmRepositoryDevice;
            _alarmRepositoryRec = alarmRepositoryDb;
            _soundRepository = soundRepository;
        }

        public void Set(AlarmEntity alarm)
        {
            _alarmRepositoryRec.Set(alarm);
            _alarmRepositoryDevice.Set(alarm);
        }

        public void OnAlarmStarted(int alarmId)
        {
            _ringingAlarmId = alarmId;
            var alarm = _alarmRepositoryRec.GetById(alarmId);
            _alarmRepositoryRec.OnAlarmStarted(alarm);
        }

        public void Stop()
        {
            var alarm = _alarmRepositoryRec.GetById(_ringingAlarmId);
            _alarmRepositoryDevice.Stop(alarm);
            _alarmRepositoryRec.Stop(alarm);
        }

        public void Cancel(AlarmEntity alarm)
        {
            _alarmRepositoryDevice.Cancel(alarm);
            _alarmRepositoryRec.Cancel(alarm);
        }

        public AlarmEntity[] GetAllEntities()
        {
            var alarms = _alarmRepositoryRec.GetAllEntities();
            SetAlarmDispName(alarms);

            return alarms;
        }

        public AlarmEntity[] GetHistories()
        {
            var alarms = _alarmRepositoryRec.GetEntities(null, DateTime.Now);
            SetAlarmDispName(alarms);

            return alarms;
        }

        public AlarmEntity[] GetSchedules()
        {
            var alarms = _alarmRepositoryRec.GetEntities(DateTime.Now, null);
            SetAlarmDispName(alarms);

            return alarms;
        }

        private void SetAlarmDispName(AlarmEntity[] alarms)
        {
            var sounds = _soundRepository.GetEntities();
            foreach (var alarm in alarms)
            {
                alarm.Sound.DisplayName = sounds.First(x => x.FileName == alarm.Sound.FileName).DisplayName;
            }
        }
    }
}
