using Demo_LocalDatabase.ViewModels;

namespace Demo_LocalDatabase.Views;

public partial class EditarNotaPage : ContentPage
{
    public EditarNotaPage(EditarNotaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
