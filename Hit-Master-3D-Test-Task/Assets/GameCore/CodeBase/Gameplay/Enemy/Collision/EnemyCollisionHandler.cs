using GameCore.CodeBase.Gameplay.Bullet.Object;
using GameCore.CodeBase.Gameplay.Enemy.Object;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Collision
{
    public class EnemyCollisionHandler : MonoBehaviour, IInteractableWith<BulletObject>
    {
        [SerializeField] private EnemyObject _enemyObject;

        public void Interact(BulletObject bullet) =>
            _enemyObject.TakeDamage(bullet.Data.DamageValue);

        public void Active() => gameObject.SetActive(true);

        public void Inactive() => gameObject.SetActive(false);
    }
}