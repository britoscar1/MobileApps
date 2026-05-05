using Link.ViewModels;

namespace Link.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnEscanerClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("escaner");
    }
}
