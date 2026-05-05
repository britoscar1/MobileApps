# Unidad 4 — Listas y Bases de Datos

## Demos

| # | Demo | Actividad | Estado |
|---|------|-----------|--------|
| 4.1 | [Demo_DynamicLists](Demo_DynamicLists/) | Listas dinámicas con CollectionView | ✅ |
| 4.2 | [Demo_LocalDatabase](Demo_LocalDatabase/) | CRUD con SQLite local | ✅ |
| 4.3 | [Demo_PersistentData](Demo_PersistentData/) | Integración listas + persistencia | ✅ |

## Equivalencias Android nativo ↔ .NET MAUI

| Concepto Android | Equivalente MAUI | Notas |
|------------------|------------------|-------|
| `RecyclerView` + `Adapter` | `CollectionView` + `ItemTemplate` | Binding a `ObservableCollection<T>` con data templates en XAML |
| `Room` / `SQLiteOpenHelper` | `sqlite-net-pcl` (NuGet) | ORM ligero, async, multiplataforma. Sin generación de código como Room |
| `LiveData` + `ViewModel` | `ObservableProperty` + `CommunityToolkit.Mvvm` | Notificación automática a la UI via source generators |
| `DiffUtil` | Automático en `ObservableCollection<T>` | MAUI actualiza solo los items que cambian |
| `SwipeActionHelper` | `SwipeView` dentro del `ItemTemplate` | Nativo en MAUI, sin librerías externas |

## Setup común

```bash
# Restaurar paquetes NuGet (ejecutar dentro de cada carpeta de demo)
dotnet restore

# Compilar para Android
dotnet build -f net10.0-android

# Compilar para Windows
dotnet build -f net10.0-windows10.0.19041.0

# Ejecutar en emulador Android (requiere emulador corriendo)
dotnet build -t:Run -f net10.0-android
```

## Ruta de la base de datos SQLite

| Plataforma | Ruta |
|------------|------|
| Android | `/data/data/[app-id]/files/` → `FileSystem.AppDataDirectory` |
| Windows | `C:\Users\[user]\AppData\Local\Packages\[app-id]\LocalState\` → `FileSystem.AppDataDirectory` |

En ambos casos se usa `Path.Combine(FileSystem.AppDataDirectory, "database.db3")` para portabilidad.

## Dependencias NuGet (U4)

| Paquete | Versión | Uso |
|---------|---------|-----|
| `sqlite-net-pcl` | 1.9.172 | ORM SQLite multiplataforma |
| `SQLitePCLRaw.bundle_green` | 2.1.10 | Provider nativo de SQLite |
| `CommunityToolkit.Mvvm` | 8.4.0 | MVVM source generators |
