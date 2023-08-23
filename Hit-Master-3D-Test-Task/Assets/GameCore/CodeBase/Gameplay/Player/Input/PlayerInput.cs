using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerObject _playerObject;
        private PlayerObjectData _objectData;
        private Locations _locations;

        public void Constructor(PlayerObject playerObject, PlayerObjectData objectData, Locations locations)
        {
            _playerObject = playerObject;
            _objectData = objectData;
            _locations = locations;
        }

        private void Update()
        {
            Move();
            Shoot();
        }

        private void Move()
        {
            if (_playerObject.IsMoving)
                return;

            if (_playerObject.CurrentLocation.Enemies.Count > 0)
                return;

            var nextLocationIndex = _playerObject.CurrentLocation.Index + 1;

            if (_locations.IsLocationExist(nextLocationIndex))
                _playerObject.StartMove(_locations.GetLocation(nextLocationIndex));
        }

        private void Shoot()
        {
            if (_playerObject.IsMoving)
                return;

            if (!UnityEngine.Input.GetMouseButtonDown(0))
                return;

            var ray = _objectData.Camera.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
                _playerObject.Shoot(hit.point);
        }
    }
}