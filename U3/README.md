# Unidad 3 — Interfaz de usuario

Estado: **completa**.

## Demos

| Demo | Actividad | Descripcion |
| --- | --- | --- |
| [`Demo_Layouts/`](Demo_Layouts/) | U3.2 | TabBar con tres paginas: Grid, Stack, Scroll. |
| [`Demo_MaterialUI/`](Demo_MaterialUI/) | U3.3 | Rediseno MD3 de `Demo_FullNavigation`: TopAppBar, Cards, Buttons MD3, TextFields, tipografia. |

## Equivalencia Android <-> MAUI

| Android (Tasks.md original) | MAUI |
| --- | --- |
| `ConstraintLayout` | `Grid` con `RowDefinitions` / `ColumnDefinitions` |
| `LinearLayout` vertical | `VerticalStackLayout` |
| `LinearLayout` horizontal | `HorizontalStackLayout` |
| `ScrollView` | `ScrollView` |
| `RelativeLayout` | `Grid` con `*` y `Auto` (RelativeLayout esta deprecado) |
| `FrameLayout` | `Grid` sin definir filas/columnas |
| `RecyclerView` | `CollectionView` |

Esta tabla esta tambien en [`Demo_Layouts/README.md`](Demo_Layouts/README.md) con mas contexto.

## Material Design 3

`Demo_MaterialUI` aplica MD3 con **estilos manuales** sobre la paleta institucional, sin librerias externas. La justificacion vive en su README.
