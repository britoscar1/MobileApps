using Demo_PersistentData.ViewModels;

namespace Demo_PersistentData.Views;

public partial class SesionesPage : ContentPage
{
    public SesionesPage(SesionesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is SesionesViewModel vm)
            vm.CargarSesionesCommand.Execute(null);
    }
}
