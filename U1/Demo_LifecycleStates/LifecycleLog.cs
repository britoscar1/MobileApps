using System.Collections.ObjectModel;

namespace Demo_LifecycleStates;

// Log compartido entre App.xaml.cs y la pagina, expuesto como ObservableCollection
// para que la UI se actualice automaticamente.
public static class LifecycleLog
{
    public static ObservableCollection<LifecycleEntry> Entries { get; } = new();

    public static void Append(string source, string evento)
    {
        var entry = new LifecycleEntry(DateTime.Now, source, evento);
        // ObservableCollection requiere actualizacion en el hilo de UI.
        if (MainThread.IsMainThread)
        {
            Entries.Insert(0, entry);
        }
        else
        {
            MainThread.BeginInvokeOnMainThread(() => Entries.Insert(0, entry));
        }
    }
}

public sealed record LifecycleEntry(DateTime Timestamp, string Source, string Event)
{
    public string TimestampStr => Timestamp.ToString("HH:mm:ss.fff");
}
