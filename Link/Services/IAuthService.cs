using Link.Models;

namespace Link.Services;

// Contrato minimo de autenticacion. La implementacion real se conectara con Link.Api en U4-U5.
public interface IAuthService
{
    Usuario? UsuarioActual { get; }
    Task<bool> LoginAsync(string usuario, string contrasena, CancellationToken ct = default);
    void Logout();
}
