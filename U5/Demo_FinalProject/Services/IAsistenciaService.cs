using Demo_FinalProject.Models;

namespace Demo_FinalProject.Services;

public interface IAsistenciaService
{
    Task<List<Asistencia>> ObtenerTodasAsync();
    Task InsertarAsync(Asistencia asistencia);
    Task<int> ContarAsync();
    Task<string?> ObtenerMateriaConMasAsistenciasAsync();
    Task<bool> ExisteDuplicadoRecienteAsync(string qrContenido, TimeSpan ventana);
    Task<Asistencia?> ObtenerUltimaAsync();
}
