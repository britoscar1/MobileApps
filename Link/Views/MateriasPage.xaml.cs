using Link.ViewModels;

namespace Link.Views;

public partial class MateriasPage : ContentPage
{
    public MateriasPage(MateriasViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
