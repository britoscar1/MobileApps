namespace Demo_MaterialUI.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIngresarClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//inicio");
    }
}
