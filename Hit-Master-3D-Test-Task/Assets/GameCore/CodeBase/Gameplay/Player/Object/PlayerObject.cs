using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Movement;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        private PlayerMovement _movement;
        private PlayerWeapon _weapon;

        public LocationObject CurrentLocation { get; private set; }

        public bool IsMoving => _movement.IsMoving;

        public void Constructor(LocationObject firstLocation, PlayerMovement movement, PlayerWeapon weapon)
        {
            CurrentLocation = firstLocation;
            _movement = movement;
            _weapon = weapon;
        }

        public void Initialize()
        {
            var targetTransform = CurrentLocation.TransitionPoints[0].transform;

            _movement.SetPosition(targetTransform.position);
            _movement.SetRotation(targetTransform.rotation);
        }

        public void ChangeLocation(LocationObject location)
        {
            CurrentLocation = location;
            CurrentLocation.Active();

            StartCoroutine(_movement.MoveCoroutine(location));
        }

        public void Shoot(Vector3 targetPosition) => _weapon.Shoot(targetPosition);
    }
}