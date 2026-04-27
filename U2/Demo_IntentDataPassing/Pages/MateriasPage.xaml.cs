using Demo_IntentDataPassing.Models;

namespace Demo_IntentDataPassing.Pages;

public partial class MateriasPage : ContentPage
{
    public MateriasPage()
    {
        InitializeComponent();
        MateriasList.ItemsSource = MateriasMock.Lista;
    }

    private async void OnMateriaSeleccionada(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Materia seleccionada) return;

        // Solo enviamos el Id; la pagina destino busca el resto en la "base local".
        await Shell.Current.GoToAsync($"detalle?id={seleccionada.Id}");

        // Limpiamos seleccion para que pueda re-seleccionarse al volver.
        MateriasList.SelectedItem = null;
    }
}
