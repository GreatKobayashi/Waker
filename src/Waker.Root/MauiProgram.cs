namespace Waker.Root
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<JsInterop>();

#if __ANDROID__
            builder.Services.AddSingleton<IAlarmRepository>(_ => new AlarmAndroid());
            builder.Services.AddSingleton<ISoundRepository>(_ => new SoundAndroid());
#elif __IOS__
            // TODO
#endif

            builder.Services.AddSingleton<AlarmController>();
            builder.Services.AddSingleton<SoundController>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
