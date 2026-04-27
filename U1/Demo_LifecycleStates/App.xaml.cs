namespace Demo_LifecycleStates;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        LifecycleLog.Append("App", "ctor");
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage());
    }

    protected override void OnStart()
    {
        base.OnStart();
        LifecycleLog.Append("App", "OnStart");
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        LifecycleLog.Append("App", "OnSleep");
    }

    protected override void OnResume()
    {
        base.OnResume();
        LifecycleLog.Append("App", "OnResume");
    }
}
