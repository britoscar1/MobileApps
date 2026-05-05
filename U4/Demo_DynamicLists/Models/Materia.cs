namespace Demo_DynamicLists.Models;

public sealed class Materia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Docente { get; set; } = string.Empty;
    public int Creditos { get; set; }
    public string HorarioTexto { get; set; } = string.Empty;
}
