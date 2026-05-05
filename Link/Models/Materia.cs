using SQLite;

namespace Link.Models;

public sealed class Materia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Codigo { get; set; } = string.Empty;

    [NotNull]
    public string Nombre { get; set; } = string.Empty;

    [NotNull]
    public string Docente { get; set; } = string.Empty;
}
