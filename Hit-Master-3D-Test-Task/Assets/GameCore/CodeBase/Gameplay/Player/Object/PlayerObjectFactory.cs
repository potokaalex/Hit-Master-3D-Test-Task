using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Movement;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly Locations _locations;
        private readonly BulletPool _bulletPool;
        private PlayerObject _player;

        public PlayerObjectFactory(Locations locations, BulletPool bulletPool)
        {
            _locations = locations;
            _bulletPool = bulletPool;
        }

        public void CreatePlayerObject(PlayerObjectData prefab)
        {
            var data = UnityEngine.Object.Instantiate(prefab);

            _player = data.gameObject.AddComponent<PlayerObject>();
            _player.Constructor(CreatePlayerMovement(data, _player), CreatePlayerWeapon(data));
        }

        public PlayerObject Get() => _player;

        private PlayerMovement CreatePlayerMovement(PlayerObjectData objectData, PlayerObject playerObject)
        {
            var firstLocation = _locations.GetFirstLocation();
            var movement = new PlayerMovement();

            movement.Constructor(objectData.NavMeshAgent, playerObject, firstLocation, new(objectData.Animator));

            return movement;
        }

        private PlayerWeapon CreatePlayerWeapon(PlayerObjectData objectData) =>
            new(_bulletPool, objectData.WeaponTransform, objectData.BulletSpeed, objectData.BulletDamage,
                objectData.bulletLifeTime);
    }
}