using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_PersistentData.Models;
using Demo_PersistentData.Services;

namespace Demo_PersistentData.ViewModels;

public partial class SesionesViewModel : ObservableObject
{
    private readonly ISesionService _sesionService;

    [ObservableProperty]
    private ObservableCollection<SesionClase> _sesiones = [];

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private bool _sinSesiones;

    public SesionesViewModel(ISesionService sesionService)
    {
        _sesionService = sesionService;
    }

    [RelayCommand]
    private async Task CargarSesiones()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var lista = await _sesionService.ObtenerTodasAsync();
            Sesiones = new ObservableCollection<SesionClase>(lista);
            SinSesiones = Sesiones.Count == 0;
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task IrANueva()
    {
        await Shell.Current.GoToAsync("nueva");
    }

    [RelayCommand]
    private async Task VerDetalle(SesionClase sesion)
    {
        await Shell.Current.GoToAsync($"detalle?id={sesion.Id}");
    }
}
