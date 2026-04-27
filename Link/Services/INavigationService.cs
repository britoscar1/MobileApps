namespace Link.Services;

// Abstraccion fina sobre Shell para facilitar testing y desacoplar VMs de la UI.
public interface INavigationService
{
    Task GoToAsync(string route);
    Task GoToAsync(string route, IDictionary<string, object> parameters);
    Task GoBackAsync();
}

public sealed class ShellNavigationService : INavigationService
{
    public Task GoToAsync(string route) => Shell.Current.GoToAsync(route);

    public Task GoToAsync(string route, IDictionary<string, object> parameters)
        => Shell.Current.GoToAsync(route, parameters);

    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
