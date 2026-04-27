using Demo_FullNavigation.Pages;

namespace Demo_FullNavigation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Subruta dinamica para empujar el detalle desde Materias.
        Routing.RegisterRoute("detalleMateria", typeof(DetalleMateriaPage));
    }
}
