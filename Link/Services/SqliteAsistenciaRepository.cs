using Link.Models;
using SQLite;

namespace Link.Services;

public sealed class SqliteAsistenciaRepository : IAsistenciaRepository
{
    private readonly SQLiteAsyncConnection _db;

    public SqliteAsistenciaRepository()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "link.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Asistencia>().Wait();
        _db.CreateTableAsync<Materia>().Wait();
    }

    public Task<List<Asistencia>> ObtenerTodasAsync()
        => _db.Table<Asistencia>().OrderByDescending(a => a.FechaHora).ToListAsync();

    public Task InsertarAsync(Asistencia asistencia)
        => _db.InsertAsync(asistencia);

    public async Task<bool> ExisteDuplicadoRecienteAsync(string qrContenido, TimeSpan ventana)
    {
        var limite = DateTime.Now - ventana;
        var duplicado = await _db.Table<Asistencia>()
            .Where(a => a.QrContenido == qrContenido && a.FechaHora > limite)
            .FirstOrDefaultAsync();
        return duplicado is not null;
    }

    public Task<List<Materia>> ObtenerMateriasAsync()
        => _db.Table<Materia>().ToListAsync();

    public Task InsertarMateriaAsync(Materia materia)
        => _db.InsertAsync(materia);

    public Task<int> ContarMateriasAsync()
        => _db.Table<Materia>().CountAsync();
}
