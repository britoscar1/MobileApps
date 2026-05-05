using Link.Models;

namespace Link.Services;

public interface IAsistenciaRepository
{
    Task<List<Asistencia>> ObtenerTodasAsync();
    Task InsertarAsync(Asistencia asistencia);
    Task<bool> ExisteDuplicadoRecienteAsync(string qrContenido, TimeSpan ventana);
}
