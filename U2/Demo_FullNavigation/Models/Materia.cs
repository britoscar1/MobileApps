namespace Demo_FullNavigation.Models;

public sealed record Materia(string Codigo, string Nombre, string Docente, string CorreoDocente, string Aula);

public static class MateriasMock
{
    public static IReadOnlyList<Materia> Lista { get; } = new List<Materia>
    {
        new("MOV-001", "Aplicaciones Moviles",   "M.C. R. Hernandez", "rhernandez@uabc.edu.mx", "FCITEC-301"),
        new("ALG-002", "Algoritmos Avanzados",   "Dr. P. Lopez",      "plopez@uabc.edu.mx",     "FCITEC-204"),
        new("BD-003",  "Bases de Datos II",      "M.C. A. Castro",    "acastro@uabc.edu.mx",    "FCITEC-110"),
    };
}
