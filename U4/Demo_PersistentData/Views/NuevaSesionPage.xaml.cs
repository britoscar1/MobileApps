using Demo_PersistentData.ViewModels;

namespace Demo_PersistentData.Views;

public partial class NuevaSesionPage : ContentPage
{
    public NuevaSesionPage(NuevaSesionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
