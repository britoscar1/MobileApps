using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Link.Models;
using Link.Services;

namespace Link.ViewModels;

public partial class EscanerViewModel : BaseViewModel
{
    private readonly IAsistenciaRepository _repository;

    [ObservableProperty]
    private string _estado = "Apunta la camara hacia un codigo QR.";

    [ObservableProperty]
    private bool _registroExitoso;

    [ObservableProperty]
    private bool _escaneando = true;

    public EscanerViewModel(IAsistenciaRepository repository)
    {
        _repository = repository;
        Title = "Escaner QR";
    }

    [RelayCommand]
    private async Task ProcesarQr(string? contenido)
    {
        if (string.IsNullOrWhiteSpace(contenido)) return;

        Escaneando = false;

        var duplicado = await _repository.ExisteDuplicadoRecienteAsync(contenido, TimeSpan.FromMinutes(5));
        if (duplicado)
        {
            Estado = "Asistencia ya registrada para esta sesion.";
            RegistroExitoso = false;
            await Shell.Current.DisplayAlertAsync("Aviso", "Asistencia ya registrada para esta sesion.", "OK");
            Escaneando = true;
            return;
        }

        var asistencia = new Asistencia
        {
            NombreMateria = contenido.Trim(),
            FechaHora = DateTime.Now,
            QrContenido = contenido
        };

        await _repository.InsertarAsync(asistencia);
        Estado = "Asistencia registrada";
        RegistroExitoso = true;

        await Task.Delay(2000);
        Escaneando = true;
        RegistroExitoso = false;
        Estado = "Apunta la camara hacia un codigo QR.";
    }
}
