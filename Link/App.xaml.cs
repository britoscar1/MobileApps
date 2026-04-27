using System.Diagnostics;

namespace Link;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    // Logging del ciclo de vida — conecta con el contenido teorico de U1.
    // En MAUI estos handlers abstraen el Activity lifecycle de Android y el WinUI lifecycle de Windows.
    protected override void OnStart()
    {
        base.OnStart();
        Log("OnStart");
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
}
