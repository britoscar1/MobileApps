using Link.Views;

namespace Link;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("escaner", typeof(EscanerPage));
    }
}
