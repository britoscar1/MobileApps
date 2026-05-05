using Demo_SensorImpl.ViewModels;

namespace Demo_SensorImpl.Views;

public partial class GpsPage : ContentPage
{
    public GpsPage(GpsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
