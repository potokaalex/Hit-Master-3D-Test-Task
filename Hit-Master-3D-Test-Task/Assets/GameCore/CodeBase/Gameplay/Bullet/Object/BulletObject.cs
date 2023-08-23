using System.Collections;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Bullet.Object
{
    public class BulletObject
    {
        private readonly BulletObjectData _data;
        private readonly BulletPool _pool;

        public BulletObject(BulletObjectData data, BulletPool pool)
        {
            _data = data;
            _pool = pool;
        }

        public BulletObjectData Data => _data;

        public void Initialize(Vector3 position, float lifeTime)
        {
            _data.transform.position = position;
            _data.gameObject.SetActive(true);
            _data.StartCoroutine(RemoveCoroutine(lifeTime));
        }

        public void Dispose()
        {
            ClearRigidbody();
            _data.gameObject.SetActive(false);
            _pool.Return(this);
        }

        public void AddForce(Vector3 direction, float speed) => _data.Rigidbody.AddForce(direction * speed);

        private IEnumerator RemoveCoroutine(float timeToRemove)
        {
            var remainingTime = timeToRemove;

            while (remainingTime > 0)
            {
                remainingTime -= Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            Dispose();
        }

        private void ClearRigidbody()
        {
            _data.Rigidbody.velocity = Vector3.zero;
            _data.Rigidbody.angularVelocity = Vector3.zero;
        }
    }
}