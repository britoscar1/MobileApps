using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_FinalProject.Models;
using Demo_FinalProject.Services;

namespace Demo_FinalProject.ViewModels;

public partial class EscanerViewModel : BaseViewModel
{
    private readonly IAsistenciaService _asistenciaService;

    [ObservableProperty]
    private string _estado = "Apunta la camara hacia un codigo QR.";

    [ObservableProperty]
    private bool _registroExitoso;

    [ObservableProperty]
    private bool _escaneando = true;

    public EscanerViewModel(IAsistenciaService asistenciaService)
    {
        _asistenciaService = asistenciaService;
    }

    [RelayCommand]
    private async Task ProcesarQr(string? contenido)
    {
        if (string.IsNullOrWhiteSpace(contenido))
        {
            Estado = "QR vacio o no valido.";
            return;
        }

        Escaneando = false;

        // Verificar duplicado en los ultimos 5 minutos
        var duplicado = await _asistenciaService.ExisteDuplicadoRecienteAsync(contenido, TimeSpan.FromMinutes(5));
        if (duplicado)
        {
            Estado = "Asistencia ya registrada para esta sesion.";
            RegistroExitoso = false;
            await Shell.Current.DisplayAlertAsync("Aviso", "Asistencia ya registrada para esta sesion.", "OK");
            Escaneando = true;
            return;
        }

        // Intentar obtener ubicacion GPS (no bloquear si falla)
        double? lat = null, lng = null;
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(5));
            var location = await Geolocation.Default.GetLocationAsync(request);
            if (location is not null)
            {
                lat = location.Latitude;
                lng = location.Longitude;
            }
        }
        catch
        {
            // GPS no disponible — continuar sin coordenadas
        }

        var asistencia = new Asistencia
        {
            NombreMateria = contenido.Trim(),
            FechaHora = DateTime.Now,
            Latitud = lat,
            Longitud = lng,
            QrContenido = contenido
        };

        await _asistenciaService.InsertarAsync(asistencia);
        Estado = "Asistencia registrada";
        RegistroExitoso = true;

        await Task.Delay(2000);
        Escaneando = true;
        RegistroExitoso = false;
        Estado = "Apunta la camara hacia un codigo QR.";
    }
}
