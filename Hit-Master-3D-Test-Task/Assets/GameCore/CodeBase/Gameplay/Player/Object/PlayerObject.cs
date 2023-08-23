using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Movement;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        private PlayerMovement _movement;
        private PlayerWeapon _weapon;

        public LocationObject CurrentLocation => _movement.CurrentLocation;

        public bool IsMoving => _movement.IsMoving;

        public void Constructor(PlayerMovement movement, PlayerWeapon weapon)
        {
            _movement = movement;
            _weapon = weapon;
        }

        public void StartMove(LocationObject location) => _movement.StartMove(location);

        public void Shoot(Vector3 targetPosition) => _weapon.Shoot(targetPosition);
    }
}