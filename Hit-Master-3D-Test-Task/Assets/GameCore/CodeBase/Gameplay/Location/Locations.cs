using System.Collections.Generic;

namespace GameCore.CodeBase.Gameplay.Location
{
    public class Locations
    {
        private readonly Dictionary<int, LocationObject> _locations = new();

        public void Initialize(LocationObject[] locations)
        {
            foreach (var location in locations)
                _locations[location.Index] = location;
        }

        public bool IsLocationExist(int locationIndex) => _locations.ContainsKey(locationIndex);

        public LocationObject GetLocation(int locationIndex) => _locations[locationIndex];

        public LocationObject GetFirstLocation() => GetLocation(0);

        public LocationObject GetLastLocation() => _locations[_locations.Count - 1];
    }
}