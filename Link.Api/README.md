# Link.Api

Esqueleto del backend de **Link** (ASP.NET Core 10 Web API). Esta iteracion solo expone endpoints stub: la integracion real con el cliente MAUI llegara en **U4-U5**.

## Estado actual

- `GET /health` — healthcheck que devuelve `{ status: "ok", timestamp: ... }`.
- `GET /api/asistencias` — devuelve lista vacia (mock).
- `POST /api/asistencias` — recibe `CrearAsistenciaDto`, valida campos minimos y responde `201 Created` con un eco del DTO + `Id` y `Timestamp` generados.

Carpetas:

```
Link.Api/
├── Controllers/   # HealthController, AsistenciasController
├── Models/        # POCOs (Asistencia)
├── Dtos/          # CrearAsistenciaDto, AsistenciaResponseDto
└── Services/      # Interfaces base (IAsistenciaService)
```

## Como correr

```bash
dotnet run --project Link.Api/Link.Api.csproj
```

Por defecto la API queda escuchando en `http://localhost:5183` (ver `Properties/launchSettings.json`). Swagger UI disponible en `http://localhost:5183/swagger`.

## Pruebas rapidas

Hay un archivo `Link.Api.http` con tres requests listos para ejecutar desde Visual Studio o VS Code (extension REST Client).

## Pendientes (U4-U5)

- Implementacion real de `IAsistenciaService` con persistencia (SQLite local + sincronizacion con SQL Server).
- Autenticacion JWT diferenciada por perfil (Estudiante / Docente / Administrador).
- Endpoints de generacion y validacion de QR.
- Integracion real con la app MAUI (`HttpClient` tipado en `Link/Services`).
