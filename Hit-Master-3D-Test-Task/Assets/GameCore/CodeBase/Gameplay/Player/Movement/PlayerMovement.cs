using System.Collections;
using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Player.Animation;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private NavMeshAgent _agent;
        private PlayerAnimator _animator;

        public bool IsMoving { get; private set; }

        public void Constructor(NavMeshAgent agent,PlayerAnimator animator)
        {
            _agent = agent;
            _animator = animator;
        }

        public void SetPosition(Vector3 position) =>
            _agent.transform.position = position;

        public void SetRotation(Quaternion rotation) =>
            _agent.transform.rotation = rotation;
        
         public IEnumerator MoveCoroutine(LocationObject location)
        {
            var pointIndex = 0;

            IsMoving = true;
            _animator.PlayRun();
            while (pointIndex < location.TransitionPoints.Length)
            {
                var targetTransform = location.TransitionPoints[pointIndex].transform;
                var targetPosition = targetTransform.position;
                var agentTransform = _agent.transform;

                _agent.SetDestination(targetPosition);

                while (true)
                {
                    var remainingOffset = targetPosition - agentTransform.position;
                    var remainingDistance = new Vector2(remainingOffset.x, remainingOffset.z).magnitude;

                    if (remainingDistance < _agent.stoppingDistance)
                        break;

                    yield return new WaitForFixedUpdate();
                }

                pointIndex++;
            }
            
            _animator.PlayIdle();
            IsMoving = false;
        }
    }
}