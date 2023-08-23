using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using Unity.VisualScripting;

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

        public void CreatePlayerInput()
        {
            var objectData = _objectFactory.Get().GetComponent<PlayerObjectData>();

            _input = _objectFactory.Get().AddComponent<PlayerInput>();
            _input.Constructor(_objectFactory.Get(), objectData, _locations);
        }
    }
}