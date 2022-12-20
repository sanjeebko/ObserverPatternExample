namespace ObserverPatternExample;

public interface ILocation
{
    string Name { get; set; }
    long Longitude { get; set; }
    long Latitude { get; set; }
}
