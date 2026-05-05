using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Demo_FinalProject.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _usuario = string.Empty;

    [ObservableProperty]
    private string _contrasena = string.Empty;

    [ObservableProperty]
    private string _error = string.Empty;

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Contrasena))
        {
            Error = "Usuario y contrasena son obligatorios";
            return;
        }

        Preferences.Default.Set("usuario", Usuario.Trim());
        await Shell.Current.GoToAsync("//inicio");
    }
}
