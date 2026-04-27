using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Link.Services;

namespace Link.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly INavigationService _navigation;

    [ObservableProperty]
    private string _usuario = string.Empty;

    [ObservableProperty]
    private string _contrasena = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TieneError))]
    private string _errorMensaje = string.Empty;

    public bool TieneError => !string.IsNullOrWhiteSpace(ErrorMensaje);

    public LoginViewModel(IAuthService authService, INavigationService navigation)
    {
        _authService = authService;
        _navigation = navigation;
        Title = "Iniciar sesion";
    }

    [RelayCommand]
    private async Task IngresarAsync()
    {
        if (IsBusy) return;
        ErrorMensaje = string.Empty;
        IsBusy = true;
        try
        {
            var ok = await _authService.LoginAsync(Usuario, Contrasena);
            if (!ok)
            {
                ErrorMensaje = "Usuario y contrasena no pueden estar vacios.";
                return;
            }

            // Navega al Shell principal (ruta absoluta para reemplazar la pila).
            await _navigation.GoToAsync("//inicio");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
