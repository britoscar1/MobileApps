namespace Demo_IntentDataPassing.Pages;

// QueryProperty mapea el query string ?nombre=... a la propiedad Nombre.
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
            // Cuando Shell setea la propiedad, actualizamos la UI.
            SaludoLabel.Text = $"Hola, {value}";
        }
    }

    public HomePage()
    {
        InitializeComponent();
        SaludoLabel.Text = "Hola";
    }

    private async void OnVerMateriasClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("materias");
    }
}
