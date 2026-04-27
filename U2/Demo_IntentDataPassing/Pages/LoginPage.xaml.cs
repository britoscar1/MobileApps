namespace Demo_IntentDataPassing.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // Flujo 1: Login -> Home enviando "nombre" como query parameter.
    private async void OnContinuarClicked(object? sender, EventArgs e)
    {
        var nombre = NombreEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            await DisplayAlertAsync("Falta dato", "Escribe tu nombre antes de continuar.", "OK");
            return;
        }
        // Uri.EscapeDataString cubre espacios y caracteres especiales en la querystring.
        await Shell.Current.GoToAsync($"home?nombre={Uri.EscapeDataString(nombre)}");
    }

    // Flujo 2: directo a la lista de materias.
    private async void OnVerMateriasClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("materias");
    }
}
