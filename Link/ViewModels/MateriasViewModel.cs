using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Link.Models;
using Link.Services;

namespace Link.ViewModels;

public sealed partial class MateriasViewModel : BaseViewModel
{
    private readonly SqliteAsistenciaRepository _repository;

    [ObservableProperty]
    private ObservableCollection<Materia> _materias = [];

    public MateriasViewModel(SqliteAsistenciaRepository repository)
    {
        Title = "Materias";
        _repository = repository;
    }

    [RelayCommand]
    private async Task CargarMaterias()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var lista = await _repository.ObtenerMateriasAsync();
            Materias = new ObservableCollection<Materia>(lista);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
