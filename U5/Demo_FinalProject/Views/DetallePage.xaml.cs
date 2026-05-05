using Demo_FinalProject.ViewModels;

namespace Demo_FinalProject.Views;

public partial class DetallePage : ContentPage
{
    public DetallePage(DetalleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
