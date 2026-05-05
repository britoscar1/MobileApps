using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_FinalProject.Services;

namespace Demo_FinalProject.ViewModels;

public partial class InicioViewModel : BaseViewModel
{
    private readonly IAsistenciaService _asistenciaService;

    [ObservableProperty]
    private string _nombreUsuario = string.Empty;

    [ObservableProperty]
    private int _totalAsistencias;

    [ObservableProperty]
    private string _materiaTop = "Sin datos";

    [ObservableProperty]
    private double _porcentajeGeneral;

    private const int SesionesEsperadas = 30;

    public InicioViewModel(IAsistenciaService asistenciaService)
    {
        _asistenciaService = asistenciaService;
    }

    [RelayCommand]
    private async Task CargarDatos()
    {
        NombreUsuario = Preferences.Default.Get("usuario", "Estudiante");
        TotalAsistencias = await _asistenciaService.ContarAsync();
        MateriaTop = await _asistenciaService.ObtenerMateriaConMasAsistenciasAsync() ?? "Sin datos";
        PorcentajeGeneral = Math.Min(1.0, (double)TotalAsistencias / SesionesEsperadas);
    }

    [RelayCommand]
    private async Task IrAEscaner()
    {
        await Shell.Current.GoToAsync("escaner");
    }
}
