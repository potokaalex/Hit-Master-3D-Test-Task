using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Ui
{
    public class EnemyUI : MonoBehaviour
    {
        [SerializeField] private EnemyHealthUI _health;

        public void Initialize(float maxHealthValue) => _health.Initialize(maxHealthValue);

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        public void SetHealth(float value) => _health.Set(value);
    }
}