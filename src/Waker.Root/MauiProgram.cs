using Microsoft.Extensions.Logging;
using Waker.Domain.Handlers;
using Waker.UI;

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
            builder.Services.AddScoped<JSInterop>();

            var alarmController = Factories.GetAlarmController();
            builder.Services.AddSingleton(alarmController);
            builder.Services.AddSingleton<IAlarmEventHandler>(alarmController);
            builder.Services.AddSingleton(Factories.GetNavigationHandler());
            builder.Services.AddSingleton(Factories.GetSoundController());

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
