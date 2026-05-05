using Demo_FinalProject.Models;
using SQLite;

namespace Demo_FinalProject.Services;

public sealed class SqliteAsistenciaService : IAsistenciaService
{
    private readonly SQLiteAsyncConnection _db;

    public SqliteAsistenciaService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "linkfinal.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Asistencia>().Wait();
    }

    public Task<List<Asistencia>> ObtenerTodasAsync()
        => _db.Table<Asistencia>().OrderByDescending(a => a.FechaHora).ToListAsync();

    public Task InsertarAsync(Asistencia asistencia)
        => _db.InsertAsync(asistencia);

    public Task<int> ContarAsync()
        => _db.Table<Asistencia>().CountAsync();

    public async Task<string?> ObtenerMateriaConMasAsistenciasAsync()
    {
        var todas = await _db.Table<Asistencia>().ToListAsync();
        return todas
            .GroupBy(a => a.NombreMateria)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key;
    }

    public async Task<bool> ExisteDuplicadoRecienteAsync(string qrContenido, TimeSpan ventana)
    {
        var limite = DateTime.Now - ventana;
        var duplicado = await _db.Table<Asistencia>()
            .Where(a => a.QrContenido == qrContenido && a.FechaHora > limite)
            .FirstOrDefaultAsync();
        return duplicado is not null;
    }

    public Task<Asistencia?> ObtenerUltimaAsync()
        => _db.Table<Asistencia>().OrderByDescending(a => a.FechaHora).FirstOrDefaultAsync()!;
}
