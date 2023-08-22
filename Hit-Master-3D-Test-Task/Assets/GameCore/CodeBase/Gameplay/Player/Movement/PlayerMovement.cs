using System.Collections;
using GameCore.CodeBase.Gameplay.Location;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private NavMeshAgent _agent;

        public bool IsMoving { get; private set; }

        public void Constructor(NavMeshAgent agent) => _agent = agent;

        public void SetPosition(Vector3 position) =>
            _agent.transform.position = position;

        public void SetRotation(Quaternion rotation) =>
            _agent.transform.rotation = rotation;
        
         public IEnumerator MoveCoroutine(LocationData location)
        {
            var pointIndex = 0;

            IsMoving = true;

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

            IsMoving = false;
        }
    }
}