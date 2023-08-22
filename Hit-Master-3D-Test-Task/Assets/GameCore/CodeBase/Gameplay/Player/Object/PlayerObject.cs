using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Movement;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        private PlayerMovement _movement;

        public LocationData CurrentLocation { get; private set; }

        public bool IsMoving => _movement.IsMoving;

        public void Constructor(LocationData firstLocation, PlayerMovement movement)
        {
            CurrentLocation = firstLocation;
            _movement = movement;
        }

        public void Initialize()
        {
            var targetTransform = CurrentLocation.TransitionPoints[0].transform;

            _movement.SetPosition(targetTransform.position);
            _movement.SetRotation(targetTransform.rotation);
        }

        public void Move(LocationData location)
        {
            StartCoroutine(_movement.MoveCoroutine(location));
            CurrentLocation = location;
        }
    }
}