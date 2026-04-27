# Demo_Layouts (U3.2)

## Objetivo

Mostrar los layouts mas comunes de MAUI (`Grid`, `VerticalStackLayout`, `ScrollView`) y su equivalencia con los layouts nativos de Android.

## Actividad

Responde a **U3.2 — Layouts** del Tasks.md de la materia.

## Criterios de evaluacion

- Tres pantallas, cada una demostrando un layout distinto.
- Uso correcto de `RowDefinitions`/`ColumnDefinitions` en `Grid`.
- Uso de `VerticalStackLayout` con suficientes items para ver el comportamiento.
- `ScrollView` envolviendo contenido largo (texto + imagenes).

## Equivalencias Android <-> MAUI

| Android nativo | MAUI |
| --- | --- |
| `ConstraintLayout` (anclajes) | `Grid` con `RowDefinitions`/`ColumnDefinitions` y `Grid.Row`/`Grid.Column` |
| `LinearLayout` `vertical` | `VerticalStackLayout` |
| `LinearLayout` `horizontal` | `HorizontalStackLayout` |
| `ScrollView` | `ScrollView` |
| `RelativeLayout` (deprecado) | `Grid` con `*` y `Auto` |
| `FrameLayout` | `Grid` sin `RowDefinitions`/`ColumnDefinitions` (todo apila en celda 0,0) |

## Estructura

- [`Pages/GridPage.xaml`](Pages/GridPage.xaml) — formulario de perfil con dos columnas (etiqueta / campo) y un boton al fondo abarcando ambas columnas.
- [`Pages/StackPage.xaml`](Pages/StackPage.xaml) — feed vertical de 10+ tarjetas dentro de un `VerticalStackLayout`.
- [`Pages/ScrollPage.xaml`](Pages/ScrollPage.xaml) — `ScrollView` envolviendo Lorem Ipsum + imagenes.
- [`AppShell.xaml`](AppShell.xaml) — `Shell` con `TabBar` que expone las tres paginas.

## Como correr

```bash
# Windows
dotnet run --project Demo_Layouts.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build Demo_Layouts.csproj -f net10.0-android
```

## Screenshots

Coloca capturas en `Screenshots/`:

- `01_grid.png` — formulario de perfil.
- `02_stack.png` — feed vertical scroll.
- `03_scroll.png` — texto largo + imagenes.
