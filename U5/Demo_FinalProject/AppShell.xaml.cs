using Demo_FinalProject.Views;

namespace Demo_FinalProject;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("escaner", typeof(EscanerPage));
        Routing.RegisterRoute("detalle", typeof(DetallePage));
    }
}
