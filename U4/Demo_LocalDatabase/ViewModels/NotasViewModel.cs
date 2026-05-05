using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_LocalDatabase.Models;
using Demo_LocalDatabase.Services;

namespace Demo_LocalDatabase.ViewModels;

public partial class NotasViewModel : ObservableObject
{
    private readonly INotaService _notaService;

    [ObservableProperty]
    private ObservableCollection<NotaEstudiante> _notas = [];

    [ObservableProperty]
    private bool _isBusy;

    public NotasViewModel(INotaService notaService)
    {
        _notaService = notaService;
    }

    [RelayCommand]
    private async Task CargarNotas()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var lista = await _notaService.ObtenerTodasAsync();
            Notas = new ObservableCollection<NotaEstudiante>(lista);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task EliminarNota(NotaEstudiante nota)
    {
        await _notaService.EliminarAsync(nota.Id);
        Notas.Remove(nota);
    }

    [RelayCommand]
    private async Task IrAAgregar()
    {
        await Shell.Current.GoToAsync("agregar");
    }

    [RelayCommand]
    private async Task IrAEditar(NotaEstudiante nota)
    {
        await Shell.Current.GoToAsync($"editar?id={nota.Id}");
    }
}
