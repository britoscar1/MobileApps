using CommunityToolkit.Mvvm.ComponentModel;

namespace Demo_FinalProject.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _titulo = string.Empty;
}
