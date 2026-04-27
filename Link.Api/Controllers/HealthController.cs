using Microsoft.AspNetCore.Mvc;

namespace Link.Api.Controllers;

// Endpoint simple de salud para validar que la API responde.
[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new
    {
        status = "ok",
        timestamp = DateTimeOffset.UtcNow
    });
}
