using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using View = Android.Views.View;

namespace Waker.Root
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            if (!OperatingSystem.IsAndroidVersionAtLeast(35))
            {
                Window!.SetStatusBarColor(Android.Graphics.Color.Transparent);
            }
            var controller = new WindowInsetsControllerCompat(Window, Window?.DecorView);
            controller.AppearanceLightStatusBars = true;
            Window?.DecorView?.SetOnApplyWindowInsetsListener(new InsetsListener());

            base.OnCreate(savedInstanceState);
        }

        private class InsetsListener : Java.Lang.Object, View.IOnApplyWindowInsetsListener
        {
            private static int _bottomPadding => OperatingSystem.IsAndroidVersionAtLeast(35) ? 0 : 48;

            public WindowInsets OnApplyWindowInsets(View view, WindowInsets insets)
            {
                var mauiWindow = Microsoft.Maui.Controls.Application.Current?.Windows?.FirstOrDefault();
                if (mauiWindow?.Page != null)
                {
                    // フッターの隠れ防止
                    mauiWindow.Page.Padding = new Thickness(0, 0, 0, _bottomPadding);
                }

                return view.OnApplyWindowInsets(insets)!;
            }
        }
    }
}
