using Demo_PersistentData.Models;

namespace Demo_PersistentData.Services;

public interface ISesionService
{
    Task<List<SesionClase>> ObtenerTodasAsync();
    Task<SesionClase?> ObtenerPorIdAsync(int id);
    Task InsertarAsync(SesionClase sesion);
    Task ActualizarAsync(SesionClase sesion);
    Task EliminarAsync(int id);
}
