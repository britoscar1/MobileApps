using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_PersistentData.Models;
using Demo_PersistentData.Services;

namespace Demo_PersistentData.ViewModels;

[QueryProperty(nameof(SesionId), "id")]
public partial class DetalleSesionViewModel : ObservableObject
{
    private readonly ISesionService _sesionService;

    [ObservableProperty]
    private int _sesionId;

    [ObservableProperty]
    private string _nombreMateria = string.Empty;

    [ObservableProperty]
    private string _fechaTexto = string.Empty;

    [ObservableProperty]
    private string _asistenciaTexto = string.Empty;

    [ObservableProperty]
    private double _porcentaje;

    [ObservableProperty]
    private string _notas = string.Empty;

    public DetalleSesionViewModel(ISesionService sesionService)
    {
        _sesionService = sesionService;
    }

    partial void OnSesionIdChanged(int value)
    {
        Task.Run(async () => await CargarDetalle(value));
    }

    private async Task CargarDetalle(int id)
    {
        var sesion = await _sesionService.ObtenerPorIdAsync(id);
        if (sesion is null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            NombreMateria = sesion.NombreMateria;
            FechaTexto = sesion.Fecha.ToString("dddd, dd MMMM yyyy");
            AsistenciaTexto = $"{sesion.Asistentes} / {sesion.Total} asistentes";
            Porcentaje = sesion.PorcentajeAsistencia;
            Notas = sesion.Notas;
        });
    }

    [RelayCommand]
    private async Task Eliminar()
    {
        var confirmar = await Shell.Current.DisplayAlertAsync(
            "Confirmar", "Desea eliminar esta sesion?", "Eliminar", "Cancelar");

        if (!confirmar) return;

        await _sesionService.EliminarAsync(SesionId);
        await Shell.Current.GoToAsync("..");
    }
}
