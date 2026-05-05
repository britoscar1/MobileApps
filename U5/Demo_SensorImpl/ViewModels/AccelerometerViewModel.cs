using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Demo_SensorImpl.ViewModels;

public partial class AccelerometerViewModel : ObservableObject
{
    [ObservableProperty]
    private string _valorX = "0.00";

    [ObservableProperty]
    private string _valorY = "0.00";

    [ObservableProperty]
    private string _valorZ = "0.00";

    [ObservableProperty]
    private double _magnitud;

    [ObservableProperty]
    private bool _activo;

    [ObservableProperty]
    private string _estado = "Presiona el boton para activar el acelerometro.";

    [RelayCommand]
    private void ToggleAcelerometro()
    {
        if (Activo)
        {
            Accelerometer.Default.ReadingChanged -= OnReadingChanged;
            Accelerometer.Default.Stop();
            Activo = false;
            Estado = "Acelerometro desactivado.";
        }
        else
        {
            if (!Accelerometer.Default.IsSupported)
            {
                Estado = "Acelerometro no soportado en este dispositivo.";
                return;
            }

            Accelerometer.Default.ReadingChanged += OnReadingChanged;
            Accelerometer.Default.Start(SensorSpeed.UI);
            Activo = true;
            Estado = "Inclina o agita el dispositivo.";
        }
    }

    private void OnReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
        var data = e.Reading;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ValorX = data.Acceleration.X.ToString("F2");
            ValorY = data.Acceleration.Y.ToString("F2");
            ValorZ = data.Acceleration.Z.ToString("F2");
            Magnitud = Math.Sqrt(
                data.Acceleration.X * data.Acceleration.X +
                data.Acceleration.Y * data.Acceleration.Y +
                data.Acceleration.Z * data.Acceleration.Z) / 3.0;
        });
    }
}
