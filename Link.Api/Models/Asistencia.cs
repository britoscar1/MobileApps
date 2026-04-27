namespace Link.Api.Models;

// POCO base que representa una asistencia registrada.
// En esta iteracion no tiene persistencia: U4 introducira repositorios.
public sealed class Asistencia
{
    public Guid Id { get; init; }
    public string MateriaCodigo { get; init; } = string.Empty;
    public string EstudianteMatricula { get; init; } = string.Empty;
    public DateTimeOffset Timestamp { get; init; }
}
