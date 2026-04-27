namespace Link.Api.Dtos;

// DTO de entrada para registrar una asistencia desde el cliente.
public sealed class CrearAsistenciaDto
{
    public string MateriaCodigo { get; set; } = string.Empty;
    public string EstudianteMatricula { get; set; } = string.Empty;
}

// DTO de salida para listar asistencias.
public sealed class AsistenciaResponseDto
{
    public Guid Id { get; set; }
    public string MateriaCodigo { get; set; } = string.Empty;
    public string EstudianteMatricula { get; set; } = string.Empty;
    public DateTimeOffset Timestamp { get; set; }
}
