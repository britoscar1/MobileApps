# Unidad 1 — Ciclo de vida

Estado: **completa**.

Demos:

| Demo | Actividad | Descripcion |
| --- | --- | --- |
| [`Demo_LifecycleStates/`](Demo_LifecycleStates/) | U1.1 | App MAUI minima que registra en pantalla los eventos de ciclo de vida (`OnStart`, `OnSleep`, `OnResume`, `OnAppearing`, `OnDisappearing`). |

## Ciclo de vida en MAUI vs Android nativo

En **Android nativo** cada `Activity` expone su propio ciclo (`onCreate`, `onStart`, `onResume`, `onPause`, `onStop`, `onDestroy`). En **WinUI 3** el equivalente vive en `App.OnLaunched` y eventos como `Suspending`/`Resuming`.

.NET MAUI **abstrae ambos** en un modelo unificado a nivel de la clase `Application`:

| MAUI | Android nativo (Activity) | WinUI 3 (App) |
| --- | --- | --- |
| `Application.OnStart` | `onStart` (despues del primer `onCreate`) | `OnLaunched` |
| `Application.OnSleep` | `onPause` / `onStop` | `Suspending` |
| `Application.OnResume` | `onResume` | `Resuming` |
| `Page.OnAppearing` | `Fragment.onResume` (aprox.) | `Loaded` |
| `Page.OnDisappearing` | `Fragment.onPause` (aprox.) | `Unloaded` |

La demo registra cada evento en una `ObservableCollection<LifecycleEntry>` ([LifecycleLog.cs](Demo_LifecycleStates/LifecycleLog.cs)) que la UI consume con un `CollectionView`. Como la coleccion se modifica desde callbacks que pueden venir de hilos no-UI, el helper salta a `MainThread` cuando hace falta.

## Como correr

```bash
# Windows
dotnet run --project U1/Demo_LifecycleStates/Demo_LifecycleStates.csproj -f net10.0-windows10.0.19041.0

# Android (con emulador o dispositivo)
dotnet build U1/Demo_LifecycleStates/Demo_LifecycleStates.csproj -f net10.0-android
```

Para verificar `OnSleep`/`OnResume` en Windows: minimiza y restaura la ventana. En Android: pulsa Home y vuelve a la app.
