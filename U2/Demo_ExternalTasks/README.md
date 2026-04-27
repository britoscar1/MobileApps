# Demo_ExternalTasks (U2.3)

## Objetivo

Demostrar la invocacion de tareas externas desde una app MAUI (equivalente cross-platform a `Intent.ACTION_VIEW`, `ACTION_SENDTO`, etc. de Android).

## Actividad

Responde a **U2.3 — Tareas externas** del Tasks.md de la materia.

## Criterios de evaluacion

- Tres botones funcionales: navegador, correo, mapas.
- Manejo de excepciones (try/catch) y feedback al usuario via `Label` de status.
- Permisos / queries declarados en `AndroidManifest.xml`.

## APIs usadas (todas en `Microsoft.Maui.ApplicationModel`)

| Boton | API | Equivalente Android |
| --- | --- | --- |
| Abrir navegador | `Launcher.Default.OpenAsync("https://...")` | `Intent(ACTION_VIEW, Uri)` con esquema `http`/`https` |
| Enviar correo | `Email.Default.ComposeAsync(EmailMessage)` | `Intent(ACTION_SENDTO, "mailto:...")` |
| Abrir Maps | `Map.Default.OpenAsync(lat, lon, MapLaunchOptions)` | `Intent(ACTION_VIEW, "geo:lat,lon?q=...")` |

## Permisos / queries declarados

`Platforms/Android/AndroidManifest.xml` incluye un bloque `<queries>` (requerido a partir de Android 11) que declara los esquemas de Intent que la app necesita resolver:

```xml
<queries>
    <intent>
        <action android:name="android.intent.action.VIEW" />
        <data android:scheme="https" />
    </intent>
    <intent>
        <action android:name="android.intent.action.SENDTO" />
        <data android:scheme="mailto" />
    </intent>
    <intent>
        <action android:name="android.intent.action.VIEW" />
        <data android:scheme="geo" />
    </intent>
</queries>
```

Sin estas declaraciones el sistema responderia con `ActivityNotFoundException` para `mailto:` y `geo:`.

## Codigo clave

```csharp
// MainPage.xaml.cs

await Launcher.Default.OpenAsync("https://uabc.mx");

await Email.Default.ComposeAsync(new EmailMessage
{
    Subject = "Demo Link U2.3",
    Body    = "Mensaje de prueba ...",
    To      = new List<string> { "ejemplo@uabc.edu.mx" }
});

await Map.Default.OpenAsync(32.5149, -116.9419,
    new MapLaunchOptions { Name = "FCITEC Valle de las Palmas" });
```

Cada llamada esta envuelta en `try/catch` capturando `FeatureNotSupportedException` y excepciones genericas; el `StatusLabel` muestra el resultado.

## Como correr

```bash
# Windows
dotnet run --project Demo_ExternalTasks.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build Demo_ExternalTasks.csproj -f net10.0-android
```

> En Windows el cliente de correo y el mapa abren la app por defecto (Outlook, Bing Maps). En Android requieren un cliente instalado y configurado.

## Screenshots

Coloca capturas en `Screenshots/`:

- `01_botones.png` — pantalla principal con los tres botones.
- `02_navegador.png` — navegador abierto en uabc.mx.
- `03_correo.png` — cliente de correo con el mensaje precargado.
- `04_maps.png` — mapa centrado en FCITEC.
