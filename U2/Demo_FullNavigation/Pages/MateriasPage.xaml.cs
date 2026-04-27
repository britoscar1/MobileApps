using Demo_FullNavigation.Models;

namespace Demo_FullNavigation.Pages;

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
        await Shell.Current.GoToAsync($"detalleMateria?codigo={seleccionada.Codigo}");
        MateriasList.SelectedItem = null;
    }
}
