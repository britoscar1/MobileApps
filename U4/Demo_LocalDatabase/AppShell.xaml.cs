using Demo_LocalDatabase.Views;

namespace Demo_LocalDatabase;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("agregar", typeof(AgregarNotaPage));
        Routing.RegisterRoute("editar", typeof(EditarNotaPage));
    }
}
