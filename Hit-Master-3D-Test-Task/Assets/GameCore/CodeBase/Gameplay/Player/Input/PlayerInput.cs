using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerObject _playerObject;
        private Locations _locations;

        public void Constructor(PlayerObject playerObject, Locations locations)
        {
            _playerObject = playerObject;
            _locations = locations;
        }

        private void Update()
        {
            if (_playerObject.IsMoving)
                return;

            if (_playerObject.CurrentLocation.EnemyCount > 0)
                return;

            var nextLocationIndex = _playerObject.CurrentLocation.Index + 1;

            if (_locations.IsLocationExist(nextLocationIndex))
                _playerObject.Move(_locations.GetLocation(nextLocationIndex));
        }
    }
}