namespace Link.Models;

// POCO placeholder: en U4-U5 se ampliara con perfil (Estudiante / Docente / Administrador).
public sealed class Usuario
{
    public string Id { get; init; } = string.Empty;
    public string NombreCompleto { get; init; } = string.Empty;
    public string CorreoInstitucional { get; init; } = string.Empty;
    public PerfilUsuario Perfil { get; init; } = PerfilUsuario.Estudiante;
}

public enum PerfilUsuario
{
    Estudiante,
    Docente,
    Administrador
}
