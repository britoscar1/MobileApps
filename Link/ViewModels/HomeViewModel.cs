using Link.Services;

namespace Link.ViewModels;

public sealed partial class HomeViewModel : BaseViewModel
{
    public HomeViewModel(IAuthService authService)
    {
        Title = "Inicio";
        Saludo = authService.UsuarioActual is { } u
            ? $"Hola, {u.NombreCompleto}"
            : "Hola";
    }

    public string Saludo { get; }
}
