namespace Demo_FullNavigation.Pages;

[QueryProperty(nameof(Nombre), "nombre")]
public partial class HomePage : ContentPage
{
    private string _nombre = string.Empty;

    public string Nombre
    {
        get => _nombre;
        set
        {
            _nombre = value;
            SaludoLabel.Text = string.IsNullOrWhiteSpace(value) ? "Hola" : $"Hola, {value}";
        }
    }

    public HomePage()
    {
        InitializeComponent();
        SaludoLabel.Text = "Hola";
    }
}
