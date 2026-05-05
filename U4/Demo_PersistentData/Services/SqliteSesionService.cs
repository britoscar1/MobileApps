using Demo_PersistentData.Models;
using SQLite;

namespace Demo_PersistentData.Services;

public sealed class SqliteSesionService : ISesionService
{
    private readonly SQLiteAsyncConnection _db;

    public SqliteSesionService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "sesiones.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<SesionClase>().Wait();
    }

    public Task<List<SesionClase>> ObtenerTodasAsync()
        => _db.Table<SesionClase>().OrderByDescending(s => s.Fecha).ToListAsync();

    public Task<SesionClase?> ObtenerPorIdAsync(int id)
        => _db.Table<SesionClase>().FirstOrDefaultAsync(s => s.Id == id)!;

    public Task InsertarAsync(SesionClase sesion)
        => _db.InsertAsync(sesion);

    public Task ActualizarAsync(SesionClase sesion)
        => _db.UpdateAsync(sesion);

    public async Task EliminarAsync(int id)
    {
        var sesion = await _db.Table<SesionClase>().FirstOrDefaultAsync(s => s.Id == id);
        if (sesion is not null)
            await _db.DeleteAsync(sesion);
    }
}
