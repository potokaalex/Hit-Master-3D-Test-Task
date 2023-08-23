using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectData : MonoBehaviour
    {
        public Camera Camera;
        public NavMeshAgent NavMeshAgent;
        public Transform WeaponTransform;
        public Animator Animator;
        public float BulletSpeed;
        public float BulletDamage;
        public float bulletLifeTime;
    }
}