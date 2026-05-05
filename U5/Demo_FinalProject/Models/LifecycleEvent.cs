namespace Demo_FinalProject.Models;

public sealed class LifecycleEvent
{
    public string Evento { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
