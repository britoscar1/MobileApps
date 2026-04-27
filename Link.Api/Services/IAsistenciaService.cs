using Link.Api.Dtos;

namespace Link.Api.Services;

// Interfaz base. Implementacion real llegara con persistencia en U4.
public interface IAsistenciaService
{
    Task<IReadOnlyList<AsistenciaResponseDto>> ListarAsync(CancellationToken ct = default);
    Task<AsistenciaResponseDto> CrearAsync(CrearAsistenciaDto dto, CancellationToken ct = default);
}
