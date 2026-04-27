using Link.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Link.Api.Controllers;

// Controller stub. Devuelve datos hardcodeados; la persistencia llegara en U4-U5.
[ApiController]
[Route("api/[controller]")]
public class AsistenciasController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AsistenciaResponseDto>> Listar()
    {
        // Mock: lista vacia. Cuando U4 introduzca persistencia, esto consultara la BD.
        var data = Array.Empty<AsistenciaResponseDto>();
        return Ok(data);
    }

    [HttpPost]
    public ActionResult<AsistenciaResponseDto> Crear([FromBody] CrearAsistenciaDto dto)
    {
        if (dto is null || string.IsNullOrWhiteSpace(dto.MateriaCodigo) || string.IsNullOrWhiteSpace(dto.EstudianteMatricula))
        {
            return BadRequest(new { error = "MateriaCodigo y EstudianteMatricula son obligatorios." });
        }

        // Echo del DTO con un Id generado y timestamp del servidor.
        var response = new AsistenciaResponseDto
        {
            Id = Guid.NewGuid(),
            MateriaCodigo = dto.MateriaCodigo,
            EstudianteMatricula = dto.EstudianteMatricula,
            Timestamp = DateTimeOffset.UtcNow
        };
        return CreatedAtAction(nameof(Listar), new { id = response.Id }, response);
    }
}
