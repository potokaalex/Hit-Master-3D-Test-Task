using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public class PlayerInputFactory
    {
        private readonly PlayerObjectFactory _objectFactory;
        private readonly Locations _locations;
        private PlayerInput _input;

        public PlayerInputFactory(PlayerObjectFactory objectFactory, Locations locations)
        {
            _objectFactory = objectFactory;
            _locations = locations;
        }

        public void CreatePlayerInput(PlayerInput prefab)
        {
            _input = UnityEngine.Object.Instantiate(prefab);
            _input.Constructor(_objectFactory.Get(), _locations);
        }
    }
}