using System.Collections;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class BulletObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        private BulletPool _pool;
        private float _damageValue;

        public void Constructor(BulletPool pool) => _pool = pool;

        public void Initialize(Vector3 position, float damageValue, float lifeTime)
        {
            transform.position = position;
            _damageValue = damageValue;

            gameObject.SetActive(true);
            StartCoroutine(RemoveCoroutine(lifeTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IInteractableWith<BulletObject>>(out var interactable))
                interactable.Interact(this);

            StopAllCoroutines();
            ReturnToPool();
        }

        public float GetDamageValue() => _damageValue;

        public void AddForce(Vector3 direction, float speed) => _rigidbody.AddForce(direction * speed);

        private IEnumerator RemoveCoroutine(float timeToRemove)
        {
            var remainingTime = timeToRemove;

            while (remainingTime > 0)
            {
                remainingTime -= Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            ReturnToPool();
        }

        private void ReturnToPool()
        {
            gameObject.SetActive(false);
            ClearRigidbody();
            _pool.Return(this);
        }

        private void ClearRigidbody()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}