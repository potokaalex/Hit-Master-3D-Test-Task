using GameCore.CodeBase.Gameplay.Location;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly Locations _locations;
        private PlayerObject _player;

        public PlayerObjectFactory(Locations locations) => _locations = locations;

        public void CreatePlayerObject(PlayerObject prefab)
        {
            _player = UnityEngine.Object.Instantiate(prefab);
            _player.MoveTo(_locations.GetFirstLocation());
        }

        public PlayerObject Get() => _player;
    }
}