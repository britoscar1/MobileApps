using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_FinalProject.Models;
using Demo_FinalProject.Services;

namespace Demo_FinalProject.ViewModels;

public partial class PerfilViewModel : BaseViewModel
{
    private readonly IAsistenciaService _asistenciaService;

    [ObservableProperty]
    private string _nombreUsuario = string.Empty;

    [ObservableProperty]
    private int _totalAsistencias;

    [ObservableProperty]
    private string _ultimaUbicacion = "Sin datos";

    [ObservableProperty]
    private ObservableCollection<LifecycleEvent> _logEventos = [];

    [ObservableProperty]
    private bool _logVisible;

    public PerfilViewModel(IAsistenciaService asistenciaService)
    {
        _asistenciaService = asistenciaService;
    }

    [RelayCommand]
    private async Task CargarPerfil()
    {
        NombreUsuario = Preferences.Default.Get("usuario", "Estudiante");
        TotalAsistencias = await _asistenciaService.ContarAsync();

        var ultima = await _asistenciaService.ObtenerUltimaAsync();
        if (ultima?.Latitud.HasValue == true)
            UltimaUbicacion = $"{ultima.Latitud:F4}, {ultima.Longitud:F4}";
        else
            UltimaUbicacion = "Sin datos de ubicacion";
    }

    [RelayCommand]
    private void ToggleLog()
    {
        LogVisible = !LogVisible;
        if (LogVisible)
            LogEventos = new ObservableCollection<LifecycleEvent>(App.LifecycleLog);
    }

    [RelayCommand]
    private async Task CerrarSesion()
    {
        Preferences.Default.Remove("usuario");
        await Shell.Current.GoToAsync("//login");
    }
}
