# Demo_LocalDatabase — Actividad 4.2

## Objetivo

Demostrar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) con SQLite en .NET MAUI usando el paquete `sqlite-net-pcl`, equivalente a Room en Android nativo.

## Actividad

Actividad 4.2 — Persistencia local con SQLite.

## Por que sqlite-net-pcl

| Criterio | sqlite-net-pcl | Room (Android) | EF Core |
|----------|---------------|----------------|---------|
| Plataformas | Android, iOS, Windows, Mac | Solo Android | Multiplataforma |
| Complejidad | Baja (atributos + async) | Media (annotations + DAOs generados) | Alta (migrations, DbContext) |
| Dependencias nativas | `SQLitePCLRaw.bundle_green` | Incluido en AndroidX | Pesado para mobile |
| Madurez en MAUI | Alta (usado desde Xamarin) | N/A | Experimental en mobile |

**Decision:** `sqlite-net-pcl` es la opcion mas estable y liviana para MAUI. No requiere generacion de codigo ni migraciones complejas.

## Codigo clave

### Conexion a la base de datos

```csharp
var dbPath = Path.Combine(FileSystem.AppDataDirectory, "notas.db3");
_db = new SQLiteAsyncConnection(dbPath);
_db.CreateTableAsync<NotaEstudiante>().Wait();
```

### Modelo con atributos SQLite

```csharp
public sealed class NotaEstudiante
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Titulo { get; set; } = string.Empty;

    public string Contenido { get; set; } = string.Empty;

    [NotNull]
    public DateTime FechaCreacion { get; set; }

    [NotNull]
    public string Materia { get; set; } = string.Empty;
}
```

### CRUD basico

```csharp
// Insertar
await _db.InsertAsync(nota);

// Leer todas
await _db.Table<NotaEstudiante>().ToListAsync();

// Actualizar
await _db.UpdateAsync(nota);

// Eliminar
await _db.DeleteAsync(nota);
```

## Verificar la base de datos

- **Android:** La base se crea en `/data/data/mx.uabc.fcitec.link.u4.localdatabase/files/notas.db3`. Puedes extraerla con `adb pull` o usar Device File Explorer en Android Studio.
- **Windows:** Se crea en `%LOCALAPPDATA%\mx.uabc.fcitec.link.u4.localdatabase\notas.db3`. Puedes abrirla con DB Browser for SQLite.

## Como correr

```bash
cd U4/Demo_LocalDatabase
dotnet restore
dotnet build -f net10.0-android
dotnet build -t:Run -f net10.0-android
```

## Screenshots

Ver carpeta [Screenshots/](Screenshots/).
