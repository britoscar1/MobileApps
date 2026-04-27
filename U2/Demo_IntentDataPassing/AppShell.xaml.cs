using Demo_IntentDataPassing.Pages;

namespace Demo_IntentDataPassing;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registramos rutas relativas para Shell.GoToAsync.
        // Nota: las paginas sin ShellContent en XAML se registran aqui.
        Routing.RegisterRoute("home", typeof(HomePage));
        Routing.RegisterRoute("materias", typeof(MateriasPage));
        Routing.RegisterRoute("detalle", typeof(DetalleMateriaPage));
    }
}
