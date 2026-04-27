using Demo_FullNavigation.Models;

namespace Demo_FullNavigation.Pages;

[QueryProperty(nameof(Codigo), "codigo")]
public partial class DetalleMateriaPage : ContentPage
{
    private string _codigo = string.Empty;
    private Materia? _materia;

    public string Codigo
    {
        get => _codigo;
        set
        {
            _codigo = value;
            CargarMateria(value);
        }
    }

    public DetalleMateriaPage()
    {
        InitializeComponent();
    }

    private void CargarMateria(string codigo)
    {
        _materia = MateriasMock.Lista.FirstOrDefault(m => m.Codigo == codigo);
        if (_materia is null)
        {
            NombreLabel.Text = "Materia no encontrada";
            StatusLabel.IsVisible = true;
            StatusLabel.Text = $"No existe materia con codigo '{codigo}'.";
            return;
        }

        NombreLabel.Text = _materia.Nombre;
        CodigoLabel.Text = _materia.Codigo;
        DocenteLabel.Text = $"Docente: {_materia.Docente}";
        AulaLabel.Text = $"Aula: {_materia.Aula}";
    }

    private async void OnContactarDocenteClicked(object? sender, EventArgs e)
    {
        if (_materia is null) return;

        try
        {
            if (!Email.Default.IsComposeSupported)
            {
                StatusLabel.IsVisible = true;
                StatusLabel.Text = "Este dispositivo no tiene cliente de correo configurado.";
                return;
            }

            var mensaje = new EmailMessage
            {
                Subject = $"[Link] {_materia.Codigo} {_materia.Nombre}",
                Body = $"Hola {_materia.Docente},\n\nEscribo desde la app Link respecto a la materia {_materia.Nombre} ({_materia.Codigo}).\n\nSaludos.",
                To = new List<string> { _materia.CorreoDocente }
            };
            await Email.Default.ComposeAsync(mensaje);
        }
        catch (Exception ex)
        {
            StatusLabel.IsVisible = true;
            StatusLabel.Text = $"Error al abrir el correo: {ex.Message}";
        }
    }
}
