# Unidad 2 — Multiples tareas (Intents y navegacion)

Estado: **completa**.

## Demos

| Demo | Actividad | Tipo | Descripcion |
| --- | --- | --- | --- |
| [`Demo_NavigationFlow/`](Demo_NavigationFlow/) | U2.1 | Documentacion | Diagrama Mermaid + tabla de transiciones del flujo completo de Link. |
| [`Demo_IntentDataPassing/`](Demo_IntentDataPassing/) | U2.2 | App MAUI | Login -> Home con saludo, lista -> detalle de materia. Paso de datos via Shell query parameters. |
| [`Demo_ExternalTasks/`](Demo_ExternalTasks/) | U2.3 | App MAUI | Tres botones: navegador (`Launcher`), correo (`Email`), maps (`Map`). |
| [`Demo_FullNavigation/`](Demo_FullNavigation/) | U2.4 | App MAUI | Mini integrador: login -> tabs -> detalle de materia con boton "Contactar docente". |

## Equivalencia Android Intents -> MAUI

El Tasks.md original esta redactado para Android nativo, donde el paso de datos entre pantallas y la invocacion de tareas externas usa `Intent`. En MAUI los conceptos se mapean asi:

| Caso (Android) | Equivalente en MAUI |
| --- | --- |
| `startActivity(new Intent(this, OtraActivity.class))` con extras | `Shell.Current.GoToAsync("ruta?clave=valor")` y `[QueryProperty]` en la pagina destino |
| `startActivity(new Intent(this, OtraActivity.class))` sin extras | `Shell.Current.GoToAsync("ruta")` |
| `Intent(Intent.ACTION_VIEW, Uri.parse("https://..."))` | `Launcher.Default.OpenAsync("https://...")` |
| `Intent(Intent.ACTION_SENDTO, Uri.parse("mailto:..."))` | `Email.Default.ComposeAsync(new EmailMessage(...))` |
| `Intent(Intent.ACTION_VIEW, Uri.parse("geo:..."))` | `Map.Default.OpenAsync(lat, lon, new MapLaunchOptions(...))` |

Todos estos viven en `Microsoft.Maui.ApplicationModel` y son cross-platform — la misma llamada se traduce al `Intent` correspondiente en Android y al protocolo de Windows en WinUI.

## Permisos requeridos en Android

`Demo_ExternalTasks` requiere agregar **queries** en `Platforms/Android/AndroidManifest.xml` para que el sistema permita resolver los Intents de mailto, geo y http. Ver el README de esa demo para el snippet exacto.
