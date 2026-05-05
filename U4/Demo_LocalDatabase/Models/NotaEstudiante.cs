using SQLite;

namespace Demo_LocalDatabase.Models;

public sealed class NotaEstudiante
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Titulo { get; set; } = string.Empty;

    public string Contenido { get; set; } = string.Empty;

    [NotNull]
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    [NotNull]
    public string Materia { get; set; } = string.Empty;
}
