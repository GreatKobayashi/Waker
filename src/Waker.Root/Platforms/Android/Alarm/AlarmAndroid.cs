using Android.App;
using Android.Content;
using Waker.Domain.Entities;
using Waker.Domain.Repositories;
using Waker.Root.Platforms.Android.Alarm;


namespace Waker.Root
{
    public class AlarmAndroid : IAlarmRepository
    {
        private Context _context;
        private AlarmManager _alarmManager;

        public AlarmAndroid()
        {
            _context = Android.App.Application.Context;
            _alarmManager = (AlarmManager)_context.GetSystemService(Context.AlarmService)!;
        }

        public void Set(AlarmEntity alarm)
        {
            var intent = new Intent(_context, typeof(AlarmReceiver));
            intent.PutExtra(RootConstant.SOUND_KEY, alarm.Sound.FileName);
            var pendingIntent = PendingIntent.GetBroadcast(_context, alarm.Id, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable)!;

            var triggerTime = new DateTimeOffset(alarm.DateTime.ToUniversalTime()).ToUnixTimeMilliseconds();

            _alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, triggerTime, pendingIntent);
        }

        public void Stop()
        {
            var intent = new Intent(_context, typeof(AlarmService));
            _context.StopService(intent);
        }

        public void Cancel(AlarmEntity alarm)
        {
            var intent = new Intent(_context, typeof(AlarmReceiver));

            var pendingIntent = PendingIntent.GetBroadcast(_context, alarm.Id, intent, PendingIntentFlags.Immutable | PendingIntentFlags.NoCreate)!;

            _alarmManager.Cancel(pendingIntent);
            pendingIntent.Cancel();
        }

        public AlarmEntity[] GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public AlarmEntity[] GetEntities(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }
    }
}
