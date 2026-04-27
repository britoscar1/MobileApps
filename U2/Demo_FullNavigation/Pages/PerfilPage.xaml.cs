namespace Demo_FullNavigation.Pages;

public partial class PerfilPage : ContentPage
{
    public PerfilPage()
    {
        InitializeComponent();
    }

    private async void OnCerrarSesionClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//login");
    }
}
