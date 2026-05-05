using Demo_FinalProject.ViewModels;

namespace Demo_FinalProject.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage(InicioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is InicioViewModel vm)
            vm.CargarDatosCommand.Execute(null);
    }
}
