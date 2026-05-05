using Demo_FinalProject.ViewModels;

namespace Demo_FinalProject.Views;

public partial class PerfilPage : ContentPage
{
    public PerfilPage(PerfilViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is PerfilViewModel vm)
            vm.CargarPerfilCommand.Execute(null);
    }
}
