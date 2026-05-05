using Demo_DynamicLists.Views;

namespace Demo_DynamicLists;

public partial class App : Application
{
    private readonly MateriasPage _materiasPage;

    public App(MateriasPage materiasPage)
    {
        InitializeComponent();
        _materiasPage = materiasPage;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(_materiasPage));
    }
}
