using Demo_FinalProject.Models;

namespace Demo_FinalProject.Services;

public interface IMateriaService
{
    Task<List<Materia>> ObtenerTodasAsync();
    Task<Materia?> ObtenerPorIdAsync(int id);
    Task InsertarAsync(Materia materia);
    Task<int> ContarAsync();
}
