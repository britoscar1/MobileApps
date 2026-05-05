using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_FinalProject.Services;

namespace Demo_FinalProject.ViewModels;

[QueryProperty(nameof(MateriaId), "id")]
public partial class DetalleViewModel : BaseViewModel
{
    private readonly IMateriaService _materiaService;

    [ObservableProperty]
    private int _materiaId;

    [ObservableProperty]
    private string _nombre = string.Empty;

    [ObservableProperty]
    private string _docente = string.Empty;

    [ObservableProperty]
    private string _horario = string.Empty;

    [ObservableProperty]
    private string _emailDocente = string.Empty;

    [ObservableProperty]
    private int _creditos;

    public DetalleViewModel(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    partial void OnMateriaIdChanged(int value)
    {
        Task.Run(async () => await CargarMateria(value));
    }

    private async Task CargarMateria(int id)
    {
        var materia = await _materiaService.ObtenerPorIdAsync(id);
        if (materia is null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Nombre = materia.Nombre;
            Docente = materia.Docente;
            Horario = materia.Horario;
            EmailDocente = materia.EmailDocente;
            Creditos = materia.Creditos;
        });
    }

    [RelayCommand]
    private async Task ContactarDocente()
    {
        if (string.IsNullOrWhiteSpace(EmailDocente)) return;

        try
        {
            var message = new EmailMessage
            {
                Subject = $"Consulta sobre {Nombre}",
                To = [EmailDocente]
            };
            await Email.ComposeAsync(message);
        }
        catch (FeatureNotSupportedException)
        {
            await Shell.Current.DisplayAlertAsync("Error", "El correo no esta disponible en este dispositivo.", "OK");
        }
    }
}
