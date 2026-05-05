using SQLite;

namespace Demo_PersistentData.Models;

public sealed class SesionClase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string NombreMateria { get; set; } = string.Empty;

    [NotNull]
    public DateTime Fecha { get; set; } = DateTime.Now;

    public int Asistentes { get; set; }

    public int Total { get; set; }

    public string Notas { get; set; } = string.Empty;

    [Ignore]
    public double PorcentajeAsistencia =>
        Total > 0 ? (double)Asistentes / Total * 100 : 0;
}
