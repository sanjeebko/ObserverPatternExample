using ObserverPatternExample;

Console.WriteLine("Observer Pattern Example!");

LocationTracker locationTrackerProvider = new();

LocationReporter reporter1 = new("Reporter 1");
LocationReporter reporter2 = new("Reporter 2");

reporter1.Subscribe(locationTrackerProvider);
reporter2.Subscribe(locationTrackerProvider);

locationTrackerProvider.TrackLocation(new Location() { Name = "Location 1", Latitude = 200, Longitude = 100 });
locationTrackerProvider.TrackLocation(null);
reporter1.Unsubscribe();
locationTrackerProvider.TrackLocation(new Location("Location 2", 600, 900));

locationTrackerProvider.TransmissionEnd();