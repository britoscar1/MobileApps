# Demo_SensorImpl — Actividad 5.2

## Objetivo

Implementar los tres sensores principales del dispositivo (Camara, GPS, Acelerometro) en una sola app MAUI con navegacion por tabs.

## Actividad

Actividad 5.2 — Implementacion de sensores del dispositivo.

## Sensores

| Sensor | API MAUI | Permisos Android | Notas emulador |
|--------|----------|------------------|----------------|
| Camara | `MediaPicker.Default.CapturePhotoAsync()` | `CAMERA`, `READ_MEDIA_IMAGES` | Usa camara virtual del emulador |
| GPS | `Geolocation.Default.GetLocationAsync()` | `ACCESS_FINE_LOCATION`, `ACCESS_COARSE_LOCATION` | Simular en Extended Controls > Location |
| Acelerometro | `Accelerometer.Default` (evento `ReadingChanged`) | Ninguno | Panel de sensores virtuales en emulador |

## Como simular GPS en emulador

1. Abrir Extended Controls del emulador (boton "...").
2. Ir a pestana **Location**.
3. Ingresar: Latitude 32.5027, Longitude -117.0037.
4. Click **Set Location**.

## Como correr

```bash
cd U5/Demo_SensorImpl
dotnet restore
dotnet build -f net10.0-android
dotnet build -t:Run -f net10.0-android
```

## Screenshots

Ver carpeta [Screenshots/](Screenshots/).
