# Demo_DynamicLists — Actividad 4.1

## Objetivo

Demostrar el uso de `CollectionView` en .NET MAUI como equivalente directo de `RecyclerView` en Android nativo, incluyendo listas dinámicas con pull-to-refresh y filtrado en tiempo real.

## Actividad

Actividad 4.1 — Listas dinámicas con datos en memoria.

## Equivalencia clave: RecyclerView → CollectionView

En Android nativo se usa `RecyclerView` con un `Adapter` que gestiona el reciclaje de vistas manualmente. En MAUI, `CollectionView` abstrae todo esto:

- **ItemsSource** se enlaza a un `ObservableCollection<T>` — la UI se actualiza automáticamente al agregar/remover items.
- **ItemTemplate** define el layout de cada celda en XAML con data binding.
- **RefreshView** envuelve el `CollectionView` para habilitar pull-to-refresh sin código extra.

## Código clave

### ItemTemplate con card estilizada

```xml
<CollectionView.ItemTemplate>
    <DataTemplate x:DataType="models:Materia">
        <Border StrokeShape="RoundRectangle 12" Stroke="{StaticResource Outline}"
                BackgroundColor="{StaticResource Surface}" Padding="16" Margin="0,6">
            <Grid RowDefinitions="Auto,Auto,Auto" ColumnDefinitions="*,Auto">
                <Label Text="{Binding Nombre}" FontSize="16" FontAttributes="Bold" />
                <Label Grid.Column="1" Text="{Binding Creditos, StringFormat='{0} cr.'}" />
                <Label Grid.Row="1" Text="{Binding Docente}" />
                <Label Grid.Row="2" Text="{Binding HorarioTexto}" />
            </Grid>
        </Border>
    </DataTemplate>
</CollectionView.ItemTemplate>
```

### Filtrado en tiempo real (ViewModel)

```csharp
partial void OnTextoBusquedaChanged(string value)
{
    AplicarFiltro();
}

private void AplicarFiltro()
{
    var filtradas = string.IsNullOrWhiteSpace(TextoBusqueda)
        ? _todasLasMaterias
        : _todasLasMaterias.Where(m =>
            m.Nombre.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase)).ToList();
    Materias = new ObservableCollection<Materia>(filtradas);
}
```

## Como correr

```bash
cd U4/Demo_DynamicLists
dotnet restore
dotnet build -f net10.0-android
dotnet build -t:Run -f net10.0-android
```

## Screenshots

Ver carpeta [Screenshots/](Screenshots/).
