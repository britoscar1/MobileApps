using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Demo_SensorImpl.ViewModels;

public partial class GpsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _latitud = "--";

    [ObservableProperty]
    private string _longitud = "--";

    [ObservableProperty]
    private string _precision = "--";

    [ObservableProperty]
    private string _timestamp = "--";

    [ObservableProperty]
    private string _estado = "Presiona el boton para obtener tu ubicacion.";

    [ObservableProperty]
    private bool _isBusy;

    private Location? _ultimaUbicacion;

    [RelayCommand]
    private async Task ObtenerUbicacion()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            Estado = "Obteniendo ubicacion...";

            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var location = await Geolocation.Default.GetLocationAsync(request);

            if (location is not null)
            {
                _ultimaUbicacion = location;
                Latitud = location.Latitude.ToString("F6");
                Longitud = location.Longitude.ToString("F6");
                Precision = location.Accuracy.HasValue
                    ? $"{location.Accuracy.Value:F1} metros"
                    : "No disponible";
                Timestamp = location.Timestamp.LocalDateTime.ToString("HH:mm:ss dd/MM/yyyy");
                Estado = "Ubicacion obtenida correctamente.";
            }
            else
            {
                Estado = "No se pudo obtener la ubicacion.";
            }
        }
        catch (FeatureNotSupportedException)
        {
            Estado = "GPS no soportado en este dispositivo.";
        }
        catch (FeatureNotEnabledException)
        {
            Estado = "GPS deshabilitado. Activalo en configuracion.";
        }
        catch (PermissionException)
        {
            Estado = "Permiso de ubicacion denegado.";
        }
        catch (Exception ex)
        {
            Estado = $"Error: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AbrirEnMapa()
    {
        if (_ultimaUbicacion is null)
        {
            Estado = "Primero obtiene una ubicacion.";
            return;
        }

        try
        {
            await Map.Default.OpenAsync(_ultimaUbicacion.Latitude, _ultimaUbicacion.Longitude,
                new MapLaunchOptions { Name = "Mi ubicacion" });
        }
        catch (Exception ex)
        {
            Estado = $"No se pudo abrir el mapa: {ex.Message}";
        }
    }
}
