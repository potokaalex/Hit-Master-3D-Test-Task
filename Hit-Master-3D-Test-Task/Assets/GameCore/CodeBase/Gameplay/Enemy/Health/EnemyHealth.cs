using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Health
{
    public class EnemyHealth
    {
        private readonly float _maxValue;
        private float _health;

        public EnemyHealth(float maxValue)
        {
            _maxValue = maxValue;
            _health = maxValue;
        }

        public void Change(float value) => _health = Mathf.Clamp(_health + value, 0, _maxValue);
        
        public float Get() => _health;
    }
}