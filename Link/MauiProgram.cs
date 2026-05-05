using Link.Services;
using Link.ViewModels;
using Link.Views;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace Link;

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
        builder.Services.AddSingleton<IAuthService, MockAuthService>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddSingleton<SqliteAsistenciaRepository>();
        builder.Services.AddSingleton<IAsistenciaRepository>(sp =>
            sp.GetRequiredService<SqliteAsistenciaRepository>());

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<MateriasViewModel>();
        builder.Services.AddTransient<PerfilViewModel>();
        builder.Services.AddTransient<EscanerViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<MateriasPage>();
        builder.Services.AddTransient<PerfilPage>();
        builder.Services.AddTransient<EscanerPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
