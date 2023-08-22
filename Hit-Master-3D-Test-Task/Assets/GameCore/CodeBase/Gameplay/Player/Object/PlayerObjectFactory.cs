using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Movement;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly Locations _locations;
        private PlayerObject _player;

        public PlayerObjectFactory(Locations locations) => _locations = locations;

        public void CreatePlayerObject(PlayerData prefab)
        {
            var firstLocation = _locations.GetFirstLocation();
            var data = UnityEngine.Object.Instantiate(prefab);

            _player = data.gameObject.AddComponent<PlayerObject>();
            _player.Constructor(firstLocation, CreatePlayerMovement(data));
        }

        public PlayerObject Get() => _player;

        private PlayerMovement CreatePlayerMovement(PlayerData data)
        {
            var movement = new PlayerMovement();

            movement.Constructor(data.NavMeshAgent);

            return movement;
        }
    }
}