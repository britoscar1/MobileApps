using CommunityToolkit.Mvvm.ComponentModel;

namespace Link.ViewModels;

// Base comun: estados de carga y titulo. Hereda de ObservableObject del Toolkit.
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title = string.Empty;
}
