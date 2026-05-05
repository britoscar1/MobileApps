using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_PersistentData.Models;
using Demo_PersistentData.Services;

namespace Demo_PersistentData.ViewModels;

public partial class NuevaSesionViewModel : ObservableObject
{
    private readonly ISesionService _sesionService;

    [ObservableProperty]
    private string _nombreMateria = string.Empty;

    [ObservableProperty]
    private DateTime _fecha = DateTime.Today;

    [ObservableProperty]
    private int _asistentes = 1;

    [ObservableProperty]
    private int _total = 1;

    [ObservableProperty]
    private string _notas = string.Empty;

    [ObservableProperty]
    private string _error = string.Empty;

    public NuevaSesionViewModel(ISesionService sesionService)
    {
        _sesionService = sesionService;
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(NombreMateria))
        {
            Error = "El nombre de la materia es obligatorio";
            return;
        }
        if (Asistentes <= 0 || Total <= 0)
        {
            Error = "Asistentes y total deben ser mayores a 0";
            return;
        }
        if (Asistentes > Total)
        {
            Error = "Asistentes no puede ser mayor que el total";
            return;
        }

        var sesion = new SesionClase
        {
            NombreMateria = NombreMateria.Trim(),
            Fecha = Fecha,
            Asistentes = Asistentes,
            Total = Total,
            Notas = Notas.Trim()
        };

        await _sesionService.InsertarAsync(sesion);
        await Shell.Current.GoToAsync("..");
    }
}
