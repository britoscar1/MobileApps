using Demo_PersistentData.ViewModels;

namespace Demo_PersistentData.Views;

public partial class DetalleSesionPage : ContentPage
{
    public DetalleSesionPage(DetalleSesionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
