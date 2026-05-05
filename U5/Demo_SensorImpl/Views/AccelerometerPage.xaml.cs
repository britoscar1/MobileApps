using Demo_SensorImpl.ViewModels;

namespace Demo_SensorImpl.Views;

public partial class AccelerometerPage : ContentPage
{
    public AccelerometerPage(AccelerometerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
