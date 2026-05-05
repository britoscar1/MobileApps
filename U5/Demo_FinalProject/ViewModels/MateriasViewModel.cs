using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_FinalProject.Models;
using Demo_FinalProject.Services;

namespace Demo_FinalProject.ViewModels;

public partial class MateriasViewModel : BaseViewModel
{
    private readonly IMateriaService _materiaService;

    [ObservableProperty]
    private ObservableCollection<Materia> _materias = [];

    public MateriasViewModel(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [RelayCommand]
    private async Task CargarMaterias()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var lista = await _materiaService.ObtenerTodasAsync();
            Materias = new ObservableCollection<Materia>(lista);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task VerDetalle(Materia materia)
    {
        await Shell.Current.GoToAsync($"detalle?id={materia.Id}");
    }
}
