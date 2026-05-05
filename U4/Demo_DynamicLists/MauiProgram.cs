using Demo_DynamicLists.Services;
using Demo_DynamicLists.ViewModels;
using Demo_DynamicLists.Views;
using Microsoft.Extensions.Logging;

namespace Demo_DynamicLists;

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

        builder.Services.AddSingleton<IMateriaDataService, MockDataService>();
        builder.Services.AddTransient<MateriasViewModel>();
        builder.Services.AddTransient<MateriasPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
