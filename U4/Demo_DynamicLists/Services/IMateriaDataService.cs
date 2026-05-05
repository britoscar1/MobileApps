using Demo_DynamicLists.Models;

namespace Demo_DynamicLists.Services;

public interface IMateriaDataService
{
    Task<List<Materia>> ObtenerMateriasAsync();
}
