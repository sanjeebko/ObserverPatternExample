// See https://aka.ms/new-console-template for more information
using ObserverPatternExample;

Console.WriteLine("Hello, World!");

LocationTracker locationTrackerProvider = new();

LocationReporter reporter1 = new("Reporter 1");
LocationReporter reporter2 = new("Reporter 2");

reporter1.Subscribe(locationTrackerProvider);
reporter2.Subscribe(locationTrackerProvider);

locationTrackerProvider.TrackLocation(new Location() { Name = "Nepal", Latitude = 200, Longitude = 100 });
locationTrackerProvider.TrackLocation(null);
reporter1.Unsubscribe();
locationTrackerProvider.TrackLocation(new Location() { Name = "United Kingdom", Latitude = 600, Longitude = 900 });

locationTrackerProvider.TransmissionEnd();
Console.ReadKey();