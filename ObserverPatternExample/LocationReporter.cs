namespace ObserverPatternExample;

internal class LocationReporter : IObserver<ILocation>
{
    private IDisposable? unsubscriber;
    public string Name { get; set; }

    public LocationReporter(string name)
    {
        Name = name;
    }

    public void Subscribe(IObservable<ILocation> provider)
    {
        if (provider is not null)
        {
            unsubscriber = provider.Subscribe(this);
        }
    }

    public void OnCompleted()
    {
        Console.WriteLine($"{Name} - process is complete");
        Unsubscribe();
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"{Name} - {error.Message}");
    }

    public void OnNext(ILocation value)
    {
        Console.WriteLine($" {Name} - Received Location: {value}");
    }

    public void Unsubscribe()
    {
        if (unsubscriber is not null)
        {
            unsubscriber.Dispose();
        }
    }
}