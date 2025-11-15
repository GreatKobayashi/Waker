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

            context.StartForegroundService(serviceIntent);
        }
    }
}
