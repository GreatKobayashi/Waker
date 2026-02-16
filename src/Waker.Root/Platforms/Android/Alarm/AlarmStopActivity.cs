using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Waker.UI;

namespace Waker.Root.Platforms.Android.Alarm
{
    [Activity(Label = "AlarmStopActivity", Exported = true, LaunchMode = LaunchMode.SingleTop)]
    public class AlarmStopActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            NavigationService.SetRedirectUrl(Url.Stop);

            // アプリを起動
            var launchIntent = new Intent(this, typeof(MainActivity));
            launchIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

            StartActivity(launchIntent);

            Finish();
        }
    }
}
