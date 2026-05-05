using Demo_LocalDatabase.Models;
using SQLite;

namespace Demo_LocalDatabase.Services;

public sealed class SqliteNotaService : INotaService
{
    private readonly SQLiteAsyncConnection _db;

    public SqliteNotaService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "notas.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<NotaEstudiante>().Wait();
    }

    public Task<List<NotaEstudiante>> ObtenerTodasAsync()
        => _db.Table<NotaEstudiante>().OrderByDescending(n => n.FechaCreacion).ToListAsync();

    public Task<NotaEstudiante?> ObtenerPorIdAsync(int id)
        => _db.Table<NotaEstudiante>().FirstOrDefaultAsync(n => n.Id == id)!;

    public Task InsertarAsync(NotaEstudiante nota)
        => _db.InsertAsync(nota);

    public Task ActualizarAsync(NotaEstudiante nota)
        => _db.UpdateAsync(nota);

    public async Task EliminarAsync(int id)
    {
        var nota = await _db.Table<NotaEstudiante>().FirstOrDefaultAsync(n => n.Id == id);
        if (nota is not null)
            await _db.DeleteAsync(nota);
    }
}
