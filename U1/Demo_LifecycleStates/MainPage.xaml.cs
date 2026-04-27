namespace Demo_LifecycleStates;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LogList.ItemsSource = LifecycleLog.Entries;
        LifecycleLog.Append("Page", "ctor");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LifecycleLog.Append("Page", "OnAppearing");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        LifecycleLog.Append("Page", "OnDisappearing");
    }
}
