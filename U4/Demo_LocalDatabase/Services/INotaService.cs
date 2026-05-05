using Demo_LocalDatabase.Models;

namespace Demo_LocalDatabase.Services;

public interface INotaService
{
    Task<List<NotaEstudiante>> ObtenerTodasAsync();
    Task<NotaEstudiante?> ObtenerPorIdAsync(int id);
    Task InsertarAsync(NotaEstudiante nota);
    Task ActualizarAsync(NotaEstudiante nota);
    Task EliminarAsync(int id);
}
