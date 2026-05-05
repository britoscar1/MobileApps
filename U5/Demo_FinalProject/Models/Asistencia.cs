using SQLite;

namespace Demo_FinalProject.Models;

public sealed class Asistencia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string NombreMateria { get; set; } = string.Empty;

    [NotNull]
    public DateTime FechaHora { get; set; } = DateTime.Now;

    public double? Latitud { get; set; }

    public double? Longitud { get; set; }

    public string QrContenido { get; set; } = string.Empty;
}
