namespace ObserverPatternExample;

public struct Location : ILocation
{
    public string Name { get; set; }
    public long Longitude { get; set; }
    public long Latitude { get; set; }

    public Location(string name, long longitude, long latitude)
    {
        Name = name;
        Longitude = longitude;
        Latitude = latitude;
    }

    public override string ToString() => $"{Name}- ({Longitude},{Latitude})";
}