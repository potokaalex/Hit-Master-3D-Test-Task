using GameCore.CodeBase.Gameplay.Enemy.Ragdoll;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyObjectData : MonoBehaviour
    {
        public EnemyCollisionHandler CollisionHandler;
        public EnemyUI Ui;
        public EnemyRagdoll Ragdoll;
        public float MaxHealth;
    }
}