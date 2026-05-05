using Demo_FinalProject.Models;
using SQLite;

namespace Demo_FinalProject.Services;

public sealed class SqliteMateriaService : IMateriaService
{
    private readonly SQLiteAsyncConnection _db;

    public SqliteMateriaService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "linkfinal.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Materia>().Wait();
    }

    public Task<List<Materia>> ObtenerTodasAsync()
        => _db.Table<Materia>().ToListAsync();

    public Task<Materia?> ObtenerPorIdAsync(int id)
        => _db.Table<Materia>().FirstOrDefaultAsync(m => m.Id == id)!;

    public Task InsertarAsync(Materia materia)
        => _db.InsertAsync(materia);

    public Task<int> ContarAsync()
        => _db.Table<Materia>().CountAsync();
}
