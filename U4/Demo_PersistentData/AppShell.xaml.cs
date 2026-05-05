using Demo_PersistentData.Views;

namespace Demo_PersistentData;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("nueva", typeof(NuevaSesionPage));
        Routing.RegisterRoute("detalle", typeof(DetalleSesionPage));
    }
}
