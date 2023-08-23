using System.Collections;
using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Animation;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private NavMeshAgent _agent;
        private PlayerObject _playerObject;
        private PlayerAnimator _animator;
        
        public bool IsMoving { get; private set; }

        public LocationObject CurrentLocation { get; private set; }

        public void Constructor(NavMeshAgent agent, PlayerObject playerObject, LocationObject firstLocation,
            PlayerAnimator animator)
        {
            _agent = agent;
            _playerObject = playerObject;
            _animator = animator;
            CurrentLocation = firstLocation;
            
            var initialTransform = firstLocation.TransitionPoints[0].transform;
            var agentTransform = _agent.transform;

            agentTransform.position = initialTransform.position;
            agentTransform.rotation = initialTransform.rotation;
        }

        public void StartMove(LocationObject location)
        {
            IsMoving = true;
            _animator.PlayRun();
            _playerObject.StartCoroutine(MoveCoroutine(location));
            CurrentLocation = location;
        }

        private void StopMove()
        {
            IsMoving = false;
            _animator.PlayIdle();
            CurrentLocation.Active();
        }

        private IEnumerator MoveCoroutine(LocationObject location)
        {
            var pointIndex = 0;

            while (pointIndex < location.TransitionPoints.Length)
            {
                var targetPosition = location.TransitionPoints[pointIndex].transform.position;

                _agent.SetDestination(targetPosition);

                while (true)
                {
                    if (IsStopCondition(targetPosition, _agent.transform))
                        break;

                    yield return new WaitForFixedUpdate();
                }

                pointIndex++;
            }

            StopMove();
        }

        private bool IsStopCondition(Vector3 targetPosition, Transform agentTransform)
        {
            var remainingOffset = targetPosition - agentTransform.position;
            var remainingDistance = new Vector2(remainingOffset.x, remainingOffset.z).magnitude;

            return remainingDistance < _agent.stoppingDistance;
        }
    }
}