using System.Diagnostics;
using Link.Models;
using Link.Services;

namespace Link;

public partial class App : Application
{
    private readonly SqliteAsistenciaRepository _repository;

    public App(SqliteAsistenciaRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override async void OnStart()
    {
        base.OnStart();
        Log("OnStart");
        await SeedDataAsync();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        Log("OnSleep");
    }

    protected override void OnResume()
    {
        base.OnResume();
        Log("OnResume");
    }

    private static void Log(string evento)
    {
        Debug.WriteLine($"[Link.Lifecycle] {DateTime.Now:HH:mm:ss.fff} {evento}");
    }

    private async Task SeedDataAsync()
    {
        var count = await _repository.ContarMateriasAsync();
        if (count > 0) return;

        var materias = new[]
        {
            new Materia { Codigo = "MOV-2026-1", Nombre = "Aplicaciones Moviles", Docente = "Dr. Carlos Ramirez" },
            new Materia { Codigo = "BDD-2026-1", Nombre = "Bases de Datos", Docente = "Dra. Laura Mendez" },
            new Materia { Codigo = "ISW-2026-1", Nombre = "Ingenieria de Software", Docente = "M.C. Roberto Flores" },
            new Materia { Codigo = "RED-2026-1", Nombre = "Redes de Computadoras", Docente = "Dr. Fernando Castillo" },
            new Materia { Codigo = "IAR-2026-1", Nombre = "Inteligencia Artificial", Docente = "Dra. Ana Torres" },
        };

        foreach (var m in materias)
            await _repository.InsertarMateriaAsync(m);
    }
}
