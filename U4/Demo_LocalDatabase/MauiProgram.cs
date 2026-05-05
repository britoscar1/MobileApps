using Demo_LocalDatabase.Services;
using Demo_LocalDatabase.ViewModels;
using Demo_LocalDatabase.Views;
using Microsoft.Extensions.Logging;

namespace Demo_LocalDatabase;

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

        builder.Services.AddSingleton<INotaService, SqliteNotaService>();

        builder.Services.AddTransient<NotasViewModel>();
        builder.Services.AddTransient<AgregarNotaViewModel>();
        builder.Services.AddTransient<EditarNotaViewModel>();

        builder.Services.AddTransient<NotasPage>();
        builder.Services.AddTransient<AgregarNotaPage>();
        builder.Services.AddTransient<EditarNotaPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
