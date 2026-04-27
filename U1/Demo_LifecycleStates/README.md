# Demo_LifecycleStates (U1.1)

## Objetivo

Demostrar de forma visual el ciclo de vida de una aplicacion MAUI: cuando se invoca cada callback en `App` y en `ContentPage`, y en que orden.

## Actividad

Responde a la actividad **U1.1 — Estados del ciclo de vida** del Tasks.md de la materia.

## Criterios de evaluacion (segun Tasks.md)

- Implementar y manejar los principales eventos del ciclo de vida.
- Mostrar al usuario los eventos en tiempo real (no solo log).
- Documentar la equivalencia con el ciclo de vida nativo de Android / WinUI.

## Como correr

```bash
# Windows
dotnet run --project Demo_LifecycleStates.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build Demo_LifecycleStates.csproj -f net10.0-android
```

## Codigo clave

- [`App.xaml.cs`](App.xaml.cs) — sobrescribe `OnStart`, `OnSleep`, `OnResume` y los pasa a `LifecycleLog.Append`.
- [`MainPage.xaml.cs`](MainPage.xaml.cs) — sobrescribe `OnAppearing` y `OnDisappearing`.
- [`LifecycleLog.cs`](LifecycleLog.cs) — `ObservableCollection<LifecycleEntry>` compartida; serializa updates al hilo de UI.
- [`MainPage.xaml`](MainPage.xaml) — `CollectionView` con `DataTemplate` tipado (`x:DataType`).

## Como provocar cada evento

| Evento | Como dispararlo en Windows | Como dispararlo en Android |
| --- | --- | --- |
| `OnStart` | Inicio de la app | Inicio de la app |
| `OnSleep` | Minimizar la ventana o cambiar de app | Boton Home / cambiar de app |
| `OnResume` | Restaurar la ventana | Volver a la app desde el switcher |
| `OnAppearing` | Mostrar la pagina (inicio) | Mostrar la pagina (inicio) |
| `OnDisappearing` | Cerrar la ventana | Cerrar la app o navegar fuera |

## Screenshots

Pendiente. Coloca capturas en `Screenshots/`:

- `01_inicio.png` — primer arranque (App.OnStart + Page.OnAppearing).
- `02_sleep_resume.png` — secuencia despues de minimizar y restaurar.
