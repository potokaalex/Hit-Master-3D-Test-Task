using GameCore.CodeBase.Gameplay.Enemy.Health;
using GameCore.CodeBase.Gameplay.Location;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Object
{
    public class EnemyObject : MonoBehaviour
    {
        [SerializeField] private EnemyObjectData _data;
        private LocationObject _location;
        private EnemyHealth _health;

        public EnemyObjectData Data => _data;

        public void Constructor(LocationObject location, EnemyHealth health)
        {
            _location = location;
            _health = health;
        }

        public void TakeDamage(float damageValue)
        {
            _health.Change(damageValue);
            _data.Ui.SetHealth(_health.Get());

            if (_health.Get() <= 0)
                Remove();
        }

        public void Active()
        {
            _data.Ui.Show();
            _data.CollisionHandler.Active();
        }

        public void Inactive()
        {
            _data.Ui.Hide();
            _data.CollisionHandler.Inactive();
        }

        private void Remove()
        {
            _data.Ragdoll.Active();
            _location.RemoveEnemy(this);
            Inactive();
        }
    }
}