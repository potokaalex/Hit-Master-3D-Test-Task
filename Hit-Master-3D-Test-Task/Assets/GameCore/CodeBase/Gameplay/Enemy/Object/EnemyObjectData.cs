using GameCore.CodeBase.Gameplay.Enemy.Collision;
using GameCore.CodeBase.Gameplay.Enemy.Ragdoll;
using GameCore.CodeBase.Gameplay.Enemy.Ui;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Enemy.Object
{
    public class EnemyObjectData : MonoBehaviour
    {
        public EnemyCollisionHandler CollisionHandler;
        public EnemyUI Ui;
        public EnemyRagdoll Ragdoll;
        public float MaxHealth;
    }
}