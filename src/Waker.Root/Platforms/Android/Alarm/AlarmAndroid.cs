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

        public AlarmAndroid()
        {
            _context = Android.App.Application.Context;
        }

        public void Set(AlarmEntity alarm)
        {
            var intent = new Intent(_context, typeof(AlarmReceiver));
            intent.PutExtra(RootConstant.SOUND_KEY, alarm.Sound.FileName);
            var pendingIntent = PendingIntent.GetBroadcast(_context, 0, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable)!;

            var triggerTime = new DateTimeOffset(alarm.DateTime.ToUniversalTime()).ToUnixTimeMilliseconds();

            var alarmManager = (AlarmManager)_context.GetSystemService(Context.AlarmService)!;
            alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, triggerTime, pendingIntent);
        }

        public void Stop()
        {
            var intent = new Intent(_context, typeof(AlarmService));
            _context.StopService(intent);
        }
    }
}
