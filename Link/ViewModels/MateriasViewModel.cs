using System.Collections.ObjectModel;
using Link.Models;

namespace Link.ViewModels;

public sealed partial class MateriasViewModel : BaseViewModel
{
    public MateriasViewModel()
    {
        Title = "Materias";
        // Mock placeholder. El listado real se traera desde Link.Api en U4-U5.
        Materias = new ObservableCollection<Materia>
        {
            new() { Codigo = "MOV-2026-1", Nombre = "Aplicaciones Moviles", Docente = "Por asignar" },
            new() { Codigo = "ALG-2026-1", Nombre = "Algoritmos Avanzados", Docente = "Por asignar" }
        };
    }

    public ObservableCollection<Materia> Materias { get; }
}
