using Link.Models;

namespace Link.Services;

// Implementacion mock: cualquier usuario y contrasena no vacios son aceptados.
// La validacion real se reemplazara cuando Link.Api exponga /api/auth.
public sealed class MockAuthService : IAuthService
{
    public Usuario? UsuarioActual { get; private set; }

    public Task<bool> LoginAsync(string usuario, string contrasena, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            return Task.FromResult(false);
        }

        UsuarioActual = new Usuario
        {
            Id = Guid.NewGuid().ToString("N"),
            NombreCompleto = usuario,
            CorreoInstitucional = $"{usuario}@uabc.edu.mx",
            Perfil = PerfilUsuario.Estudiante
        };
        return Task.FromResult(true);
    }

    public void Logout() => UsuarioActual = null;
}
