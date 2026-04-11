using Android.Content;
using Waker.Domain.Exceptions;

namespace Waker.Root.Platforms.Android.Alarm
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context? context, Intent? intent)
        {
            if (context == null || intent == null)
            {
                throw new DeviceException(new ArgumentNullException());
            }

            var serviceIntent = new Intent(context, typeof(AlarmService));
            serviceIntent.PutExtra(RootConstant.SOUND_KEY, intent.GetStringExtra(RootConstant.SOUND_KEY));
            serviceIntent.PutExtra(RootConstant.ALARM_ID_KEY, intent.GetIntExtra(RootConstant.ALARM_ID_KEY, -1));

            context.StartForegroundService(serviceIntent);
        }
    }
}
