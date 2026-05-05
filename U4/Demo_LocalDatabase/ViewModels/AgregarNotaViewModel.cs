using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_LocalDatabase.Models;
using Demo_LocalDatabase.Services;

namespace Demo_LocalDatabase.ViewModels;

public partial class AgregarNotaViewModel : ObservableObject
{
    private readonly INotaService _notaService;

    [ObservableProperty]
    private string _titulo = string.Empty;

    [ObservableProperty]
    private string _materia = string.Empty;

    [ObservableProperty]
    private string _contenido = string.Empty;

    [ObservableProperty]
    private string _error = string.Empty;

    public AgregarNotaViewModel(INotaService notaService)
    {
        _notaService = notaService;
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
            Titulo = Titulo.Trim(),
            Materia = Materia.Trim(),
            Contenido = Contenido.Trim(),
            FechaCreacion = DateTime.Now
        };

        await _notaService.InsertarAsync(nota);
        await Shell.Current.GoToAsync("..");
    }
}
