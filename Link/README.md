# Link (cliente MAUI)

Proyecto principal integrador del cliente .NET MAUI de **Link**. En esta iteracion solo monta:

- Shell de navegacion con login + 3 tabs (`Inicio`, `Materias`, `Perfil`).
- Login mock (cualquier usuario y contrasena no vacios pasa).
- DI registrado para servicios (`IAuthService`, `INavigationService`) y todos los ViewModels y Views.
- Logging del ciclo de vida (`OnStart`/`OnSleep`/`OnResume`) en `App.xaml.cs` — conecta con la teoria de U1.
- Paleta MD3 institucional definida en `Resources/Styles/Colors.xaml`.

## Estructura

```
Link/
├── App.xaml(.cs)             # Logging del lifecycle
├── AppShell.xaml(.cs)        # Login + TabBar (Inicio / Materias / Perfil)
├── MauiProgram.cs            # DI: services + VMs + Views
├── Models/                   # POCOs placeholder (Usuario, Materia)
├── ViewModels/               # BaseVM + LoginVM + tabs VMs
├── Views/                    # LoginPage + HomePage + MateriasPage + PerfilPage
├── Services/                 # IAuthService + Mock, INavigationService + Shell impl
├── Resources/Styles/         # Colors.xaml (paleta institucional) + Styles.xaml
├── Resources/Fonts/Images/   # Fuentes e imagenes
└── Platforms/Android,Windows # Heads de plataforma
```

## Como correr

```bash
# Windows (desde la raiz del repo)
dotnet build Link/Link.csproj -f net10.0-windows10.0.19041.0
dotnet run --project Link/Link.csproj -f net10.0-windows10.0.19041.0

# Android (requiere emulador o dispositivo conectado)
dotnet build Link/Link.csproj -f net10.0-android
```

## Decisiones tecnicas locales

- **MVVM**: `CommunityToolkit.Mvvm 8.4.0` con `[ObservableProperty]` y `[RelayCommand]` (field syntax). El warning MVVMTK0045 (partial property AOT) se suprime via `<NoWarn>` porque el binding aqui es por reflexion, no AOT.
- **Material Design 3**: estilos manuales sobre la paleta institucional. No se uso `Material.Components.Maui` para evitar dependencias externas inestables; los componentes MD3 estrictos viven en `U3/Demo_MaterialUI/`.
- **Login**: navegacion absoluta `//login` y `//inicio` para reemplazar la pila al autenticar.

## TODOs (U4-U5)

- Reemplazar `MockAuthService` por `HttpAuthService` que consuma `/api/auth` de `Link.Api`.
- Persistencia local con SQLite (U4) y sincronizacion con backend.
- Camara/QR/GPS para registrar asistencia (U5).
- Tests unitarios para los ViewModels (xUnit).
