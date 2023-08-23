using GameCore.CodeBase.Gameplay.Bullet.Object;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Bullet
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private BulletObject _bulletObject;

        public void Constructor(BulletObject bulletObject) => _bulletObject = bulletObject;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IInteractableWith<BulletObject>>(out var interactable))
                interactable.Interact(_bulletObject);

            _bulletObject.Dispose();
        }
    }
}