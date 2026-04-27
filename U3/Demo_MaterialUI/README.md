# Demo_MaterialUI (U3.3)

## Objetivo

Aplicar Material Design 3 de forma estricta sobre un mini-flujo (login + tabs Inicio/Materias) replicando el contenido de `Demo_FullNavigation` pero con **estilos MD3 manuales**.

## Actividad

Responde a **U3.3 — Material Design 3** del Tasks.md de la materia.

## Decision tecnica

> Se evaluo `Material.Components.Maui` y se opto por **estilos MD3 manuales** en `Resources/Styles/MaterialStyles.xaml` para evitar dependencias de paquetes inestables y para que los `VisualStateManager` queden a la vista del estudiante.

## Que se aplica

- **Top App Bar** custom con `Border` + `BoxView` para simular la elevacion 1dp.
- **Filled / Outlined / Text Button** con estados `Normal`, `PointerOver`, `Pressed`, `Disabled` definidos en `VisualStateManager`.
- **Card** estilo MD3 (`Border` con `RoundRectangle 12`, padding 16, stroke `Outline`).
- **TextField** con label flotante "estatico" (Label arriba) + `Border` con `Entry` interno.
- **Tipografia jerarquica** (`HeadlineLarge`, `TitleLarge`, `BodyMedium`, `LabelMedium`).

## Criterios de evaluacion

- Top app bar con elevacion correcta — `MD3TopAppBar` style + `BoxView` divisor.
- Botones Filled / Outlined / Text — todos los estilos en `MaterialStyles.xaml`.
- Cards con elevacion / padding correctos — `MD3Card` style.
- Inputs con label flotante — patron Label + Border + Entry.
- VisualStateManager con estados normal / hover / pressed / disabled — incluido en cada estilo de boton.
- Tipografia consistente con jerarquia clara — 4 niveles definidos.

## Estructura

```
Demo_MaterialUI/
├── App.xaml                        # Carga Colors + Styles + MaterialStyles
├── AppShell.xaml(.cs)              # Login + TabBar (Inicio + Materias)
├── Resources/Styles/
│   ├── Colors.xaml                 # Paleta institucional Link
│   ├── Styles.xaml                 # Default del template (no se uso para MD3)
│   └── MaterialStyles.xaml         # MD3: Buttons, Card, TextField, TopAppBar, Tipografia
└── Pages/
    ├── LoginPage.xaml(.cs)         # TextField MD3 + FilledButton + TextButton
    ├── HomePage.xaml(.cs)          # TopAppBar + Cards con FilledButton + OutlinedButton
    └── MateriasPage.xaml(.cs)      # TopAppBar + lista de Cards
```

## Como correr

```bash
# Windows
dotnet run --project Demo_MaterialUI.csproj -f net10.0-windows10.0.19041.0

# Android
dotnet build Demo_MaterialUI.csproj -f net10.0-android
```

## Screenshots

Coloca capturas en `Screenshots/`:

- `01_login.png` — TextFields con label flotante, FilledButton primario, TextButton de recuperacion.
- `02_home.png` — TopAppBar + dos Cards con jerarquia tipografica MD3.
- `03_materias.png` — TopAppBar + lista de Cards.
