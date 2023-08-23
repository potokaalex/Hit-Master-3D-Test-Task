using GameCore.CodeBase.Gameplay.Player;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyCollisionHandler : MonoBehaviour, IInteractableWith<BulletObject>
    {
        [SerializeField] private EnemyObject _enemyObject;

        public void Interact(BulletObject bullet) =>
            _enemyObject.TakeDamage(bullet.GetDamageValue());

        public void Active() => gameObject.SetActive(true);

        public void Inactive() => gameObject.SetActive(false);
    }
}