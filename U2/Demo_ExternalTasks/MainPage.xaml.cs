namespace Demo_ExternalTasks;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAbrirNavegadorClicked(object? sender, EventArgs e)
    {
        try
        {
            await Launcher.Default.OpenAsync("https://uabc.mx");
            SetStatus("Navegador abierto: https://uabc.mx");
        }
        catch (Exception ex)
        {
            SetStatus($"Error al abrir navegador: {ex.Message}", esError: true);
        }
    }

    private async void OnEnviarCorreoClicked(object? sender, EventArgs e)
    {
        try
        {
            if (!Email.Default.IsComposeSupported)
            {
                SetStatus("El dispositivo no tiene cliente de correo configurado.", esError: true);
                return;
            }

            var mensaje = new EmailMessage
            {
                Subject = "Demo Link U2.3",
                Body = "Mensaje de prueba enviado desde la demo de tareas externas.",
                To = new List<string> { "ejemplo@uabc.edu.mx" }
            };
            await Email.Default.ComposeAsync(mensaje);
            SetStatus("Cliente de correo abierto.");
        }
        catch (FeatureNotSupportedException)
        {
            SetStatus("Email no soportado en esta plataforma.", esError: true);
        }
        catch (Exception ex)
        {
            SetStatus($"Error al enviar correo: {ex.Message}", esError: true);
        }
    }

    private async void OnAbrirMapsClicked(object? sender, EventArgs e)
    {
        try
        {
            // FCITEC Valle de las Palmas, Tijuana
            var opciones = new MapLaunchOptions { Name = "FCITEC Valle de las Palmas" };
            await Map.Default.OpenAsync(32.5149, -116.9419, opciones);
            SetStatus("Mapas abierto en FCITEC Valle de las Palmas.");
        }
        catch (FeatureNotSupportedException)
        {
            SetStatus("Mapas no soportado en esta plataforma.", esError: true);
        }
        catch (Exception ex)
        {
            SetStatus($"Error al abrir mapas: {ex.Message}", esError: true);
        }
    }

    private void SetStatus(string mensaje, bool esError = false)
    {
        StatusLabel.Text = mensaje;
        StatusLabel.TextColor = esError
            ? Colors.Red
            : (Color)Application.Current!.Resources["OnSurface"];
    }
}
