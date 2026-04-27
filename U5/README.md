# Unidad 5 — Sensores, camara, GPS y QR

Estado: **placeholder**.

Esta unidad cubrira (segun la PUA de Aplicaciones Moviles UABC FCITEC):

- Permisos en runtime (`Permissions` API de MAUI).
- Camara con `MediaPicker` y/o control nativo.
- Generacion y lectura de **codigos QR** (probablemente `ZXing.Net.Maui`).
- GPS / geolocalizacion (`Geolocation` API).
- Acelerometro / giroscopio (`Accelerometer`, `Gyroscope`).
- Caso de uso integrador: registro de asistencia escaneando el QR generado por el docente, validando GPS dentro del aula.

## Demos planeadas

| Demo | Actividad | Tipo |
| --- | --- | --- |
| `Demo_PermisosCamara/` | U5.1 | Solicitud de permisos en runtime + captura de foto via `MediaPicker`. |
| `Demo_QRReader/` | U5.2 | Lector de QR con `ZXing.Net.Maui`. |
| `Demo_QRGenerator/` | U5.3 | Generador de QR con metadatos firmados (vista del docente). |
| `Demo_GPSCheckin/` | U5.4 | `Geolocation.GetLocationAsync` + radio de aceptacion alrededor de FCITEC. |
| `Demo_AsistenciaQR/` | U5.5 | Integrador: scan QR + validacion GPS + envio a `Link.Api`. |

## TODOs

- Decidir libreria QR antes de comenzar (ZXing.Net.Maui vs CommunityToolkit camera + QR code lib).
- Definir el formato del payload del QR (token con expiracion firmado por el backend) en U4.
- Politica de privacidad para uso de camara y GPS antes de publicar a Play Store.
