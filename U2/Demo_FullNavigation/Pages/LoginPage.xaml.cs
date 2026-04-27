namespace Demo_FullNavigation.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIngresarClicked(object? sender, EventArgs e)
    {
        var usuario = UsuarioEntry.Text?.Trim();
        var password = PasswordEntry.Text;
        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlertAsync("Datos incompletos", "Usuario y contrasena son obligatorios.", "OK");
            return;
        }
        // Pasamos el nombre al Home para personalizar el saludo (demuestra paso de datos U2.2).
        await Shell.Current.GoToAsync($"//inicio?nombre={Uri.EscapeDataString(usuario)}");
    }
}
