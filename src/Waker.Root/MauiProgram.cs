using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Waker.Infrastructure.SQLite;
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
            builder.Services.AddSingleton(Factories.GetAlarmController());
            builder.Services.AddSingleton(Factories.GetSoundController());

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
