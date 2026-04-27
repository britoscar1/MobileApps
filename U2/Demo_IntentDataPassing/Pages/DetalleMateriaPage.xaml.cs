using Demo_IntentDataPassing.Models;

namespace Demo_IntentDataPassing.Pages;

[QueryProperty(nameof(MateriaId), "id")]
public partial class DetalleMateriaPage : ContentPage
{
    private string _materiaId = string.Empty;

    public string MateriaId
    {
        get => _materiaId;
        set
        {
            _materiaId = value;
            CargarMateria(value);
        }
    }

    public DetalleMateriaPage()
    {
        InitializeComponent();
    }

    private void CargarMateria(string id)
    {
        var materia = MateriasMock.Lista.FirstOrDefault(m => m.Id == id);
        if (materia is null)
        {
            ErrorLabel.IsVisible = true;
            ErrorLabel.Text = $"No se encontro la materia con id '{id}'.";
            return;
        }

        NombreLabel.Text = materia.Nombre;
        IdLabel.Text = materia.Id;
        DocenteLabel.Text = materia.Docente;
        AulaLabel.Text = materia.Aula;
        HorarioLabel.Text = materia.Horario;
    }
}
