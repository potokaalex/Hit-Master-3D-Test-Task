using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Enemy;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Location
{
    public class LocationObject : MonoBehaviour
    {
        public int Index;
        public List<EnemyObject> Enemies;
        public LocationTransitionPoint[] TransitionPoints;

        private void Start()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Constructor(this, new(enemy.Data.MaxHealth));
                enemy.Data.Ui.Initialize(enemy.Data.MaxHealth);
                enemy.Inactive();
            }
        }

        public void Active()
        {
            foreach (var enemy in Enemies)
                enemy.Active();
        }

        public void RemoveEnemy(EnemyObject enemy) => Enemies.Remove(enemy);
    }
}