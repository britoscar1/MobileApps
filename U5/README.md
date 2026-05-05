# Unidad 5 — Funciones del Dispositivo

## Demos

| # | Demo | Actividad | Estado |
|---|------|-----------|--------|
| 5.1 | [Demo_SensorResearch](Demo_SensorResearch/) | Investigacion GPS/Geolocalizacion | ✅ |
| 5.2 | [Demo_SensorImpl](Demo_SensorImpl/) | Implementacion de sensores (Camara, GPS, Acelerometro) | ✅ |
| 5.3 | [Demo_FinalProject](Demo_FinalProject/) | Proyecto integrador final | ✅ |

## Sensores implementados

| Sensor | API MAUI | Permisos Android | Disponible en emulador |
|--------|----------|------------------|----------------------|
| Camara | `MediaPicker.Default.CapturePhotoAsync()` | `CAMERA`, `READ_MEDIA_IMAGES` | Si (camara virtual) |
| GPS | `Geolocation.Default.GetLocationAsync()` | `ACCESS_FINE_LOCATION`, `ACCESS_COARSE_LOCATION` | Si (ubicacion simulada) |
| Acelerometro | `Accelerometer.Default` | Ninguno | Parcial (panel de sensores virtuales) |
| Escaner QR | `ZXing.Net.MAUI` (`CameraBarcodeReaderView`) | `CAMERA` | Si (mostrar QR en pantalla frente a camara virtual) |

## Simular GPS en Android Studio Emulator

1. Abrir el emulador y hacer clic en "..." (Extended controls).
2. Ir a **Location**.
3. Ingresar latitud y longitud manualmente (ej: FCITEC UABC — Lat: 32.5027, Lng: -117.0037).
4. Hacer clic en **Set Location**.
5. La app recibira esas coordenadas al llamar `GetLocationAsync`.

Tambien se puede cargar un archivo GPX/KML para simular rutas.

## ZXing.Net.MAUI

- **Paquete:** `ZXing.Net.MAUI` (NuGet)
- **Version usada:** 0.4.0
- **Configuracion minima:**
  1. En `MauiProgram.cs`: `.UseBarcodeReader()`
  2. En `AndroidManifest.xml`: permiso `CAMERA`
  3. En XAML: `<zxing:CameraBarcodeReaderView />`
- **Limitaciones conocidas:**
  - En Windows la camara no siempre se inicializa correctamente (usar Android preferentemente).
  - El paquete no se actualiza con frecuencia — la version 0.4.0 es compatible con MAUI 9/10.
  - En emulador, se debe mostrar un QR fisico/impreso frente a la webcam virtual.

## Por que ZXing.Net.MAUI

- Es el port oficial del proyecto ZXing a .NET MAUI.
- Soporte nativo de decodificacion de multiples formatos (QR, EAN, Code128, etc.).
- Unico control `CameraBarcodeReaderView` que integra camara + decodificacion sin codigo adicional.
- Alternativas como `CommunityToolkit.Maui.Camera` no incluyen decodificacion QR nativa.
