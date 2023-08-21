using System.Collections.Generic;

namespace GameCore.CodeBase.Gameplay.Location
{
    public class Locations
    {
        private readonly Dictionary<int, LocationData> _locations = new();

        public void Initialize(LocationData[] locations)
        {
            foreach (var location in locations)
                _locations[location.Index] = location;
        }

        public bool IsLocationExist(int locationIndex) => _locations.ContainsKey(locationIndex);

        public LocationData GetLocation(int locationIndex) => _locations[locationIndex];

        public LocationData GetFirstLocation() => GetLocation(0);
    }
}