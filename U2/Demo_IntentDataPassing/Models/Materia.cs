namespace Demo_IntentDataPassing.Models;

public sealed record Materia(string Id, string Nombre, string Docente, string Aula, string Horario);

public static class MateriasMock
{
    // Lista local. En el proyecto integrador este dato vendra del backend.
    public static IReadOnlyList<Materia> Lista { get; } = new List<Materia>
    {
        new("MOV-001", "Aplicaciones Moviles", "M.C. R. Hernandez", "FCITEC-301", "Lun-Mier 09:00"),
        new("ALG-002", "Algoritmos Avanzados", "Dr. P. Lopez", "FCITEC-204", "Mar-Jue 10:00"),
        new("BD-003",  "Bases de Datos II",     "M.C. A. Castro",  "FCITEC-110", "Mar-Jue 13:00"),
        new("RED-004", "Redes de Computadoras", "Dr. J. Romero",   "FCITEC-105", "Lun-Mier 11:00"),
        new("IA-005",  "Inteligencia Artificial","Dra. S. Mora",   "FCITEC-220", "Vie 09:00")
    };
}
