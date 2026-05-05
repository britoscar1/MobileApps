using Demo_PersistentData.Services;
using Demo_PersistentData.ViewModels;
using Demo_PersistentData.Views;
using Microsoft.Extensions.Logging;

namespace Demo_PersistentData;

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

        builder.Services.AddSingleton<ISesionService, SqliteSesionService>();

        builder.Services.AddTransient<SesionesViewModel>();
        builder.Services.AddTransient<NuevaSesionViewModel>();
        builder.Services.AddTransient<DetalleSesionViewModel>();

        builder.Services.AddTransient<SesionesPage>();
        builder.Services.AddTransient<NuevaSesionPage>();
        builder.Services.AddTransient<DetalleSesionPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
