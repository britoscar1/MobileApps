using Link.Services;
using Link.ViewModels;
using Link.Views;
using Microsoft.Extensions.Logging;

namespace Link;

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

        // Servicios
        builder.Services.AddSingleton<IAuthService, MockAuthService>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<MateriasViewModel>();
        builder.Services.AddTransient<PerfilViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<MateriasPage>();
        builder.Services.AddTransient<PerfilPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
