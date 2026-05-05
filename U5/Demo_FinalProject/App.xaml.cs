using Demo_FinalProject.Models;
using Demo_FinalProject.Services;

namespace Demo_FinalProject;

public partial class App : Application
{
    public static List<LifecycleEvent> LifecycleLog { get; } = [];

    private readonly IMateriaService _materiaService;

    public App(IMateriaService materiaService)
    {
        InitializeComponent();
        _materiaService = materiaService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override async void OnStart()
    {
        base.OnStart();
        RegistrarEvento("OnStart");
        await SeedDataAsync();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        RegistrarEvento("OnSleep");
    }

    protected override void OnResume()
    {
        base.OnResume();
        RegistrarEvento("OnResume");
    }

    private static void RegistrarEvento(string evento)
    {
        LifecycleLog.Add(new LifecycleEvent
        {
            Evento = evento,
            Timestamp = DateTime.Now
        });
    }

    private async Task SeedDataAsync()
    {
        var count = await _materiaService.ContarAsync();
        if (count > 0) return;

        var materias = new[]
        {
            new Materia { Nombre = "Aplicaciones Moviles", Docente = "Dr. Carlos Ramirez", Horario = "Lun-Mie 10:00-12:00", EmailDocente = "carlos.ramirez@uabc.edu.mx", Creditos = 6 },
            new Materia { Nombre = "Bases de Datos", Docente = "Dra. Laura Mendez", Horario = "Mar-Jue 08:00-10:00", EmailDocente = "laura.mendez@uabc.edu.mx", Creditos = 6 },
            new Materia { Nombre = "Ingenieria de Software", Docente = "M.C. Roberto Flores", Horario = "Lun-Mie 14:00-16:00", EmailDocente = "roberto.flores@uabc.edu.mx", Creditos = 8 },
            new Materia { Nombre = "Redes de Computadoras", Docente = "Dr. Fernando Castillo", Horario = "Mar-Jue 10:00-12:00", EmailDocente = "fernando.castillo@uabc.edu.mx", Creditos = 6 },
            new Materia { Nombre = "Inteligencia Artificial", Docente = "Dra. Ana Torres", Horario = "Lun-Mie 08:00-10:00", EmailDocente = "ana.torres@uabc.edu.mx", Creditos = 8 },
        };

        foreach (var m in materias)
            await _materiaService.InsertarAsync(m);
    }
}
