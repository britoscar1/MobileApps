# Demo_IntentDataPassing (U2.2)

## Objetivo

Demostrar el paso de datos entre paginas usando el equivalente MAUI a los `Intent` extras de Android: **Shell query parameters + `[QueryProperty]`**.

## Actividad

Responde a **U2.2 — Paso de datos entre pantallas** del Tasks.md de la materia.

## Criterios de evaluacion

- Dos flujos navegables claramente identificables.
- Uso correcto de `Shell.GoToAsync` con querystring.
- Recepcion del parametro con `[QueryProperty]` en la pagina destino.
- Manejo del caso "id no encontrado" sin crashear.

## Flujos implementados

### Flujo 1: Login -> Home (paso de string simple)

1. `LoginPage` pide un nombre.
2. Al pulsar **Continuar a Home**, navega a `home?nombre=<valor URL-encoded>`.
3. `HomePage` declara `[QueryProperty(nameof(Nombre), "nombre")]` y actualiza el saludo cuando Shell setea la propiedad.

### Flujo 2: Lista -> Detalle (paso de id)

1. `MateriasPage` muestra `MateriasMock.Lista` en un `CollectionView`.
2. Al seleccionar un item, navega a `detalle?id=<materiaId>`.
3. `DetalleMateriaPage` recibe el id con `[QueryProperty(nameof(MateriaId), "id")]`, busca la materia en `MateriasMock` y rellena los `Label`s.
4. Si el id no existe, muestra un mensaje de error en pantalla en lugar de crashear.

## Codigo clave

### Envio (LoginPage)

```csharp
// Pages/LoginPage.xaml.cs
await Shell.Current.GoToAsync($"home?nombre={Uri.EscapeDataString(nombre)}");
```

### Recepcion (HomePage)

```csharp
[QueryProperty(nameof(Nombre), "nombre")]
public partial class HomePage : ContentPage
{
    public string Nombre
    {
        get => _nombre;
        set { _nombre = value; SaludoLabel.Text = $"Hola, {value}"; }
    }
}
```

### Registro de rutas (AppShell)

```csharp
// AppShell.xaml.cs
Routing.RegisterRoute("home", typeof(HomePage));
Routing.RegisterRoute("materias", typeof(MateriasPage));
Routing.RegisterRoute("detalle", typeof(DetalleMateriaPage));
```

## Como correr

```bash
# Windows
dotnet run --project Demo_IntentDataPassing.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build Demo_IntentDataPassing.csproj -f net10.0-android
```

## Screenshots

Coloca capturas en `Screenshots/`:

- `01_login.png` — pagina inicial.
- `02_home_saludo.png` — saludo personalizado tras pasar el nombre.
- `03_materias_lista.png` — `CollectionView` de materias.
- `04_materia_detalle.png` — detalle con todos los datos.
