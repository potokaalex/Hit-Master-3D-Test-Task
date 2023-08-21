using GameCore.CodeBase.Gameplay.Location;
using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public LocationData CurrentLocation { get; private set; }

        public void MoveTo(LocationData location)
        {
            var position = location.PlayerPoint.position;

            _navMeshAgent.SetDestination(position);
            CurrentLocation = location;
        }
    }
}