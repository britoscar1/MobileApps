# Unidad 4 — Listas y persistencia local

Estado: **placeholder**.

Esta unidad cubrira (segun la PUA de Aplicaciones Moviles UABC FCITEC):

- `CollectionView` y `ListView` avanzados con templates dinamicos.
- Persistencia local con **SQLite** (paquete `sqlite-net-pcl`).
- Patron Repository sobre la BD local.
- Sincronizacion con `Link.Api` via `HttpClient` tipado.
- Estados de UI: vacio, cargando, error, lista.

## Demos planeadas

| Demo | Actividad | Tipo |
| --- | --- | --- |
| `Demo_ListasAvanzadas/` | U4.1 | App MAUI standalone que demuestra `CollectionView` con grouping, swipe, pull-to-refresh y empty state. |
| `Demo_SqliteCRUD/` | U4.2 | App MAUI con CRUD completo de materias usando SQLite local. |
| `Demo_HttpSync/` | U4.3 | Cliente HTTP tipado contra `Link.Api` (sync local <-> remoto). |

## TODOs heredados desde U1-U3

- `MockAuthService` en `Link/Services/` se reemplazara por `HttpAuthService` aqui.
- `MateriasMock` desaparecera cuando exista repositorio SQLite.
- Tests unitarios para los repositorios y los HTTP services (xUnit).
