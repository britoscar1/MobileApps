using Demo_SensorImpl.ViewModels;
using Demo_SensorImpl.Views;
using Microsoft.Extensions.Logging;

namespace Demo_SensorImpl;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<CameraViewModel>();
        builder.Services.AddTransient<GpsViewModel>();
        builder.Services.AddTransient<AccelerometerViewModel>();

        builder.Services.AddTransient<CameraPage>();
        builder.Services.AddTransient<GpsPage>();
        builder.Services.AddTransient<AccelerometerPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
