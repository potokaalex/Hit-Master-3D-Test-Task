using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Ragdoll
{
    public class EnemyRagdoll : MonoBehaviour
    {
        [SerializeField] private Collider _bodyCollider;
        [SerializeField] private Animator _animator;
        private Rigidbody[] _rigidbodies;

        public void Initialize()
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            Inactive();
        }

        public void Active()
        {
            foreach (var r in _rigidbodies)
                r.isKinematic = false;
            
            _bodyCollider.enabled = false;
            _animator.enabled = false;
        }

        private void Inactive()
        {
            foreach (var r in _rigidbodies)
                r.isKinematic = true;
        }
    }
}