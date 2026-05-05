using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Demo_SensorImpl.ViewModels;

public partial class CameraViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource? _fotoCapturada;

    [ObservableProperty]
    private string _estado = "Presiona un boton para capturar o seleccionar una foto.";

    [RelayCommand]
    private async Task TomarFoto()
    {
        try
        {
            var foto = await MediaPicker.Default.CapturePhotoAsync();
            await MostrarFoto(foto);
        }
        catch (PermissionException)
        {
            Estado = "Permiso de camara denegado. Habilita el permiso en configuracion.";
        }
        catch (FeatureNotSupportedException)
        {
            Estado = "La camara no esta disponible en este dispositivo.";
        }
    }

    [RelayCommand]
    private async Task SeleccionarFoto()
    {
        try
        {
            var foto = await MediaPicker.Default.PickPhotoAsync();
            await MostrarFoto(foto);
        }
        catch (PermissionException)
        {
            Estado = "Permiso de acceso a galeria denegado.";
        }
    }

    private async Task MostrarFoto(FileResult? foto)
    {
        if (foto is null)
        {
            Estado = "No se selecciono ninguna foto.";
            return;
        }

        var stream = await foto.OpenReadAsync();
        FotoCapturada = ImageSource.FromStream(() => stream);
        Estado = $"Foto cargada: {foto.FileName}";
    }
}
