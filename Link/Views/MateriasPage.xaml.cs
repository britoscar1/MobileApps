using Link.ViewModels;

namespace Link.Views;

public partial class MateriasPage : ContentPage
{
    public MateriasPage(MateriasViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is MateriasViewModel vm)
            vm.CargarMateriasCommand.Execute(null);
    }
}
