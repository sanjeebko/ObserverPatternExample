namespace ObserverPatternExample;

public class LocationTracker : IObservable<ILocation>
{
    private readonly List<IObserver<ILocation>> _observers;

    public LocationTracker()
    {
        _observers = new();
    }

    public void TrackLocation(ILocation? location)
    {
        foreach (var observer in _observers)
        {
            if (location is not null)
            {
                observer.OnNext(location);
            }
            else
            {
                observer.OnError(new InvalidOperationException("Location is not valid!"));
            }
        }
    }

    public void TransmissionEnd()
    {
        var observersTobeRemoved = _observers.ToList();
        foreach (var observer in observersTobeRemoved)
        {
            observer.OnCompleted();
        }
        _observers.Clear();
    }

    public IDisposable Subscribe(IObserver<ILocation> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        return new Unsubscriber(_observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<ILocation>> _observers;
        private IObserver<ILocation> _observer;

        public Unsubscriber(List<IObserver<ILocation>> observers, IObserver<ILocation> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer is not null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}