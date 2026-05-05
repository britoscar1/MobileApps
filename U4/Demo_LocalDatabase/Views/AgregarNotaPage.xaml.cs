using Demo_LocalDatabase.ViewModels;

namespace Demo_LocalDatabase.Views;

public partial class AgregarNotaPage : ContentPage
{
    public AgregarNotaPage(AgregarNotaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
