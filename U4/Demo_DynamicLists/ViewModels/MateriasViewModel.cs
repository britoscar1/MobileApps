using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo_DynamicLists.Models;
using Demo_DynamicLists.Services;

namespace Demo_DynamicLists.ViewModels;

public partial class MateriasViewModel : ObservableObject
{
    private readonly IMateriaDataService _dataService;
    private List<Materia> _todasLasMaterias = [];

    [ObservableProperty]
    private ObservableCollection<Materia> _materias = [];

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _textoBusqueda = string.Empty;

    public MateriasViewModel(IMateriaDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    private async Task CargarMaterias()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            _todasLasMaterias = await _dataService.ObtenerMateriasAsync();
            AplicarFiltro();
        }
        finally
        {
            IsBusy = false;
        }
    }

    partial void OnTextoBusquedaChanged(string value)
    {
        AplicarFiltro();
    }

    private void AplicarFiltro()
    {
        var filtradas = string.IsNullOrWhiteSpace(TextoBusqueda)
            ? _todasLasMaterias
            : _todasLasMaterias.Where(m =>
                m.Nombre.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase)).ToList();

        Materias = new ObservableCollection<Materia>(filtradas);
    }
}
