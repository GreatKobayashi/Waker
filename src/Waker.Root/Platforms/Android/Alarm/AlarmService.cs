using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Waker.Aplication.Handlers;
using Waker.Domain.Handlers;

namespace Waker.Root.Platforms.Android.Alarm
{
    [Service(ForegroundServiceType = ForegroundService.TypeMediaPlayback)]
    public class AlarmService : Service
    {
        private static readonly string _channelId = "alarm";
        private static readonly string _channelName = "Alarm Channel";
        private static readonly string _defType = "raw";
        private static readonly int _requestCode = 0;
        private static readonly int _serviceId = 1;

        private MediaPlayer? _player;

        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            // 通知チャンネルを作成
            var channel = new NotificationChannel(_channelId, _channelName, NotificationImportance.Low);
            (GetSystemService(NotificationService) as NotificationManager)!.CreateNotificationChannel(channel);

            var pendingIntent = PendingIntent.GetActivity(
                this, _requestCode, new Intent(this, typeof(AlarmStopActivity)), PendingIntentFlags.Immutable);

            var notification = new Notification.Builder(this, _channelId)
                .SetContentTitle("アラームが鳴っています")
                .SetContentText("タップしてアプリを開く")
                .SetSmallIcon(Resource.Drawable.ic_clock_black_24dp)
                .SetContentIntent(pendingIntent)
                .Build();

            StartForeground(_serviceId, notification);

            // サウンド
            int resourceId = Resources!.GetIdentifier(intent!.GetStringExtra(RootConstant.SOUND_KEY), _defType, PackageName);
            _player = MediaPlayer.Create(this, resourceId)!;
            _player.Looping = true;
            _player.Start();

            var services = IPlatformApplication.Current!.Services;
            var alarmId = intent!.GetIntExtra(RootConstant.ALARM_ID_KEY, -1);
            services.GetRequiredService<IAlarmEventHandler>().OnAlarmStarted(alarmId);
            services.GetRequiredService<INavigationHandler>().NavigateToStop();

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _player?.Stop();
            _player?.Release();
            _player = null;
            base.OnDestroy();
        }

        public override IBinder? OnBind(Intent? intent) => null;
    }
}
