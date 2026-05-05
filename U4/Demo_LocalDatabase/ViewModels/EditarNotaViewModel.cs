using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_LocalDatabase.Models;
using Demo_LocalDatabase.Services;

namespace Demo_LocalDatabase.ViewModels;

[QueryProperty(nameof(NotaId), "id")]
public partial class EditarNotaViewModel : ObservableObject
{
    private readonly INotaService _notaService;

    [ObservableProperty]
    private int _notaId;

    [ObservableProperty]
    private string _titulo = string.Empty;

    [ObservableProperty]
    private string _materia = string.Empty;

    [ObservableProperty]
    private string _contenido = string.Empty;

    [ObservableProperty]
    private string _error = string.Empty;

    public EditarNotaViewModel(INotaService notaService)
    {
        _notaService = notaService;
    }

    partial void OnNotaIdChanged(int value)
    {
        Task.Run(async () => await CargarNota(value));
    }

    private async Task CargarNota(int id)
    {
        var nota = await _notaService.ObtenerPorIdAsync(id);
        if (nota is null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Titulo = nota.Titulo;
            Materia = nota.Materia;
            Contenido = nota.Contenido;
        });
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(Titulo))
        {
            Error = "El titulo es obligatorio";
            return;
        }

        var nota = new NotaEstudiante
        {
            Id = NotaId,
            Titulo = Titulo.Trim(),
            Materia = Materia.Trim(),
            Contenido = Contenido.Trim(),
            FechaCreacion = DateTime.Now
        };

        await _notaService.ActualizarAsync(nota);
        await Shell.Current.GoToAsync("..");
    }
}
