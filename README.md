# Link

Aplicacion movil multiplataforma (Android + Windows) para registro de asistencias mediante codigos QR. Proyecto academico de la materia **Aplicaciones Moviles** — UABC, FCITEC, Valle de las Palmas.

A futuro Link permitira a estudiantes registrar asistencia escaneando QR generados por docentes, con perfiles diferenciados (Estudiante / Docente / Administrador). En esta iteracion se construye **solo el cliente MAUI integrador y un esqueleto minimo del backend**, sin integracion real entre ambos todavia.

## Equipo

Brito Ortiz Oscar Artemio
Ruiz Rodriguez Jorge Alberto
Ramírez Dórame Abel

## Stack

- **.NET 10** (ver "Desviaciones" abajo) con **MAUI 10** y Shell.
- **C# 13**, nullable enabled, file-scoped namespaces.
- **MVVM** con `CommunityToolkit.Mvvm` 8.4 (`[ObservableProperty]`, `[RelayCommand]`).
- **Material Design 3** con estilos manuales sobre la paleta institucional (no se uso `Material.Components.Maui`).
- **ASP.NET Core 10 Web API** para el esqueleto del backend.
- Plataformas target: **Android** (`net10.0-android`) y **Windows** (`net10.0-windows10.0.19041.0`). Sin iOS / MacCatalyst.


## Estructura

```
/
|-- README.md                          este archivo
|-- .gitignore                         .NET / MAUI / VS
|-- .editorconfig                      C# style + file-scoped namespaces
|-- Link.sln                           contiene Link/ y Link.Api/
|
|-- Link/                              proyecto principal MAUI (integrador)
|-- Link.Api/                          esqueleto ASP.NET Core
|
|-- U1/Demo_LifecycleStates/           lifecycle log
|-- U2/Demo_NavigationFlow/            documentacion (no codigo)
|-- U2/Demo_IntentDataPassing/         shell query parameters
|-- U2/Demo_ExternalTasks/             Launcher / Email / Map
|-- U2/Demo_FullNavigation/            integrador U2
|-- U3/Demo_Layouts/                   Grid / Stack / Scroll
|-- U3/Demo_MaterialUI/                MD3 sobre Demo_FullNavigation
|-- U4/                                placeholder (listas + SQLite)
|-- U5/                                placeholder (camara / QR / GPS)
|
`-- docs/                              PUA y propuesta original (esperado)
```

## Estado por unidad

| Unidad | Tema | Estado |
| --- | --- | --- |
| U1 | Ciclo de vida | ✅ |
| U2 | Multiples tareas (Intents / navegacion) | ✅ |
| U3 | Interfaz de usuario | ✅ |
| U4 | Listas + persistencia SQLite | 🚧 |
| U5 | Sensores, camara, GPS, QR | 🚧 |

## Setup

```bash
# Workloads necesarios
dotnet workload install maui

# Restaurar y compilar todo
dotnet restore Link.sln
dotnet build  Link.sln
```

> Nota: cada demo de U1-U3 vive aislada con su propio `.csproj`. No estan en `Link.sln` para que cada unidad pueda evaluarse de forma independiente.

## Como correr cada cosa

### Backend (Link.Api)

```bash
dotnet run --project Link.Api/Link.Api.csproj
# Swagger UI en http://localhost:5183/swagger
```

### Cliente MAUI integrador (Link)

```bash
# Windows
dotnet run --project Link/Link.csproj -f net10.0-windows10.0.19041.0

# Android (con emulador o dispositivo)
dotnet build Link/Link.csproj -f net10.0-android
```

### Demos U1-U3

Cada demo se compila y corre con su propio `.csproj`. Patron general:

```bash
# Windows
dotnet run --project <ruta>/<DemoName>.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build <ruta>/<DemoName>.csproj -f net10.0-android
```

| Demo | Comando Windows |
| --- | --- |
| Demo_LifecycleStates | `dotnet run --project U1/Demo_LifecycleStates/Demo_LifecycleStates.csproj -f net10.0-windows10.0.19041.0` |
| Demo_IntentDataPassing | `dotnet run --project U2/Demo_IntentDataPassing/Demo_IntentDataPassing.csproj -f net10.0-windows10.0.19041.0` |
| Demo_ExternalTasks | `dotnet run --project U2/Demo_ExternalTasks/Demo_ExternalTasks.csproj -f net10.0-windows10.0.19041.0` |
| Demo_FullNavigation | `dotnet run --project U2/Demo_FullNavigation/Demo_FullNavigation.csproj -f net10.0-windows10.0.19041.0` |
| Demo_Layouts | `dotnet run --project U3/Demo_Layouts/Demo_Layouts.csproj -f net10.0-windows10.0.19041.0` |
| Demo_MaterialUI | `dotnet run --project U3/Demo_MaterialUI/Demo_MaterialUI.csproj -f net10.0-windows10.0.19041.0` |

Reemplazar `net10.0-windows10.0.19041.0` por `net10.0-android` para Android.




