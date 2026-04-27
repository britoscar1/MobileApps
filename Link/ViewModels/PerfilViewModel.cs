using CommunityToolkit.Mvvm.Input;
using Link.Services;

namespace Link.ViewModels;

public sealed partial class PerfilViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly INavigationService _navigation;

    public PerfilViewModel(IAuthService authService, INavigationService navigation)
    {
        _authService = authService;
        _navigation = navigation;
        Title = "Perfil";
    }

    public string NombreCompleto => _authService.UsuarioActual?.NombreCompleto ?? "Sin sesion";
    public string CorreoInstitucional => _authService.UsuarioActual?.CorreoInstitucional ?? string.Empty;

    [RelayCommand]
    private async Task CerrarSesionAsync()
    {
        _authService.Logout();
        await _navigation.GoToAsync("//login");
    }
}
