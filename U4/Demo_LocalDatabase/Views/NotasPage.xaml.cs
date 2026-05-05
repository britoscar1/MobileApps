using Demo_LocalDatabase.ViewModels;

namespace Demo_LocalDatabase.Views;

public partial class NotasPage : ContentPage
{
    public NotasPage(NotasViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is NotasViewModel vm)
            vm.CargarNotasCommand.Execute(null);
    }
}
