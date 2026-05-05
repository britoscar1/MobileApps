# Demo_SensorResearch — Actividad 5.1

## Investigacion: GPS/Geolocalizacion aplicado al proyecto Link

### 1. Funcionamiento del sensor GPS

El sistema de posicionamiento global (GPS) determina la ubicacion del dispositivo mediante la triangulacion de senales de multiples satelites en orbita. Un receptor GPS necesita comunicarse con al menos 4 satelites para calcular una posicion tridimensional (latitud, longitud, altitud).

En dispositivos moviles modernos, la geolocalizacion no depende exclusivamente del GPS satelital. Se utiliza una combinacion de fuentes:

- **GPS satelital:** Mayor precision (3-5 metros en condiciones optimas), pero mayor consumo de bateria y tiempo de fijacion inicial (cold start de 30+ segundos).
- **WiFi positioning:** Utiliza bases de datos de puntos de acceso WiFi conocidos para estimar la ubicacion. Precision de 15-40 metros en zonas urbanas. Muy rapido.
- **Red celular (Cell ID):** Triangulacion basada en torres celulares. Precision de 100-300 metros. Util como fallback.
- **A-GPS (Assisted GPS):** Combina GPS satelital con datos de red para reducir el tiempo de fijacion a 1-3 segundos.

El sistema operativo Android abstrae todas estas fuentes en un "Fused Location Provider" que automaticamente selecciona la mejor combinacion segun la precision solicitada y el estado de bateria.

### 2. Casos de uso en el proyecto Link

La geolocalizacion se aplica al proyecto Link para **validar que el estudiante esta fisicamente presente en el campus** al momento de registrar su asistencia mediante QR. Esto previene fraudes como:

- Compartir el codigo QR por mensajeria para que alguien registre asistencia sin estar presente.
- Capturar el QR en una sesion y reutilizarlo desde otra ubicacion.

**Implementacion propuesta:**
1. Al escanear el QR, la app obtiene las coordenadas del estudiante.
2. Se compara la distancia entre las coordenadas del estudiante y las coordenadas conocidas del campus/aula (ej: FCITEC UABC, Lat: 32.5027, Lng: -117.0037).
3. Si la distancia es menor a un radio de tolerancia (ej: 200 metros), la asistencia se registra exitosamente.
4. Si excede el radio, se muestra un aviso pero no se bloquea el registro (politica flexible — el docente decide).

### 3. Permisos requeridos en Android

Para acceder al GPS en Android se necesitan los siguientes permisos en `AndroidManifest.xml`:

```xml
<!-- Ubicacion precisa (GPS satelital) -->
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />

<!-- Ubicacion aproximada (WiFi/Cell) -->
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
```

En **API 29+ (Android 10)**, si la app necesita ubicacion en segundo plano:
```xml
<uses-permission android:name="android.permission.ACCESS_BACKGROUND_LOCATION" />
```

Para el proyecto Link no se requiere `ACCESS_BACKGROUND_LOCATION` porque la ubicacion se solicita solo al momento de escanear el QR (la app esta en primer plano).

Ademas, desde **API 23+ (Android 6.0)**, los permisos de ubicacion deben solicitarse en tiempo de ejecucion usando el sistema de permisos de runtime.

### 4. API de MAUI: Geolocation

.NET MAUI provee `Microsoft.Maui.Devices.Sensors.Geolocation` como abstraccion multiplataforma:

```csharp
try
{
    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
    var location = await Geolocation.Default.GetLocationAsync(request);

    if (location != null)
    {
        double lat = location.Latitude;
        double lng = location.Longitude;
        double? accuracy = location.Accuracy; // metros
    }
}
catch (FeatureNotSupportedException)
{
    // El dispositivo no tiene hardware GPS
}
catch (FeatureNotEnabledException)
{
    // GPS deshabilitado en configuracion del dispositivo
}
catch (PermissionException)
{
    // El usuario denego el permiso de ubicacion
}
```

**Parametros clave de `GeolocationRequest`:**

| Parametro | Descripcion |
|-----------|-------------|
| `DesiredAccuracy` | `Best`, `High`, `Medium`, `Low`, `Lowest` — controla precision vs bateria |
| `Timeout` | Tiempo maximo de espera antes de fallar |

**Niveles de precision:**
- `Best` / `High`: Usa GPS satelital. Precision de 1-10m. Alto consumo.
- `Medium`: Combina WiFi + Cell. Precision de 30-100m. Consumo moderado.
- `Low` / `Lowest`: Solo Cell ID. Precision de 300-3000m. Bajo consumo.

Para Link, `Medium` es suficiente — solo necesitamos validar presencia en campus, no la posicion exacta dentro del aula.

### 5. Limitaciones y simulacion en emulador

**Limitaciones del emulador:**
- El emulador de Android Studio no tiene hardware GPS real.
- Provee un panel de "Location" en Extended Controls para simular coordenadas.
- Se pueden cargar archivos GPX/KML para simular rutas en movimiento.

**Como simular ubicacion:**
1. Iniciar el emulador desde Android Studio.
2. Hacer clic en el icono "..." (tres puntos) para abrir Extended Controls.
3. Seleccionar la pestana **Location**.
4. Ingresar coordenadas: Latitude 32.5027, Longitude -117.0037 (FCITEC UABC).
5. Hacer clic en **Set Location**.
6. La proxima llamada a `GetLocationAsync` retornara esas coordenadas.

**Nota:** En dispositivos fisicos, la primera fijacion GPS puede tardar 15-30 segundos si no hay cache de satelites reciente.

### 6. Comparativa: GPS nativo Android vs Geolocation.Default de MAUI

| Aspecto | GPS nativo Android | MAUI Geolocation |
|---------|-------------------|------------------|
| API | `FusedLocationProviderClient` (Google Play Services) | `Geolocation.Default.GetLocationAsync()` |
| Configuracion | Manual: crear request, callback, lifecycle | Una linea de codigo async/await |
| Precision | Configurable via `Priority` | Configurable via `GeolocationAccuracy` |
| Background | Soportado nativamente | Requiere configuracion adicional por plataforma |
| Geofencing | `GeofencingClient` nativo | No incluido en MAUI (usar plugin o nativo) |
| Plataformas | Solo Android | Android, iOS, Windows, Mac |

**Que abstrae MAUI:**
- El boilerplate de `FusedLocationProviderClient`.
- El manejo de lifecycle (resume/pause del listener).
- Las diferencias entre plataformas.
- La solicitud de permisos (parcialmente — aun requiere declarar en Manifest).

**Que sacrifica MAUI:**
- Geofencing nativo (requiere codigo de plataforma o plugin).
- Location updates continuos con alta eficiencia (en MAUI se obtienen lecturas puntuales).
- Acceso a detalles como velocidad, bearing, proveedor especifico.

Para el proyecto Link, la API de MAUI cubre perfectamente el caso de uso: obtener una lectura puntual al momento del escaneo QR con precision media.
