using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyObjectData : MonoBehaviour
    {
        public EnemyCollisionHandler CollisionHandler;
        public EnemyUI Ui;
        public float MaxHealth;
    }
}