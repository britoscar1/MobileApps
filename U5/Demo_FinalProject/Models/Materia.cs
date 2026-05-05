using SQLite;

namespace Demo_FinalProject.Models;

public sealed class Materia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Nombre { get; set; } = string.Empty;

    [NotNull]
    public string Docente { get; set; } = string.Empty;

    public string Horario { get; set; } = string.Empty;

    public string EmailDocente { get; set; } = string.Empty;

    public int Creditos { get; set; }
}
