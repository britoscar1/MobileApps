using Demo_FinalProject.Services;
using Demo_FinalProject.ViewModels;
using Demo_FinalProject.Views;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace Demo_FinalProject;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Servicios
        builder.Services.AddSingleton<IMateriaService, SqliteMateriaService>();
        builder.Services.AddSingleton<IAsistenciaService, SqliteAsistenciaService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<InicioViewModel>();
        builder.Services.AddTransient<MateriasViewModel>();
        builder.Services.AddTransient<DetalleViewModel>();
        builder.Services.AddTransient<EscanerViewModel>();
        builder.Services.AddTransient<PerfilViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<InicioPage>();
        builder.Services.AddTransient<MateriasPage>();
        builder.Services.AddTransient<DetallePage>();
        builder.Services.AddTransient<EscanerPage>();
        builder.Services.AddTransient<PerfilPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
