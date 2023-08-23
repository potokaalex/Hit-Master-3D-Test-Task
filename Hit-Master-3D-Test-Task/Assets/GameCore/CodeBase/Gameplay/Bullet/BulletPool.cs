using System.Collections.Generic;
using GameCore.CodeBase.Gameplay.Bullet.Object;

namespace GameCore.CodeBase.Gameplay.Bullet
{
    public class BulletPool
    {
        private readonly BulletFactory _factory;
        private readonly Stack<BulletObject> _bullets = new();

        public BulletPool(BulletFactory factory) => _factory = factory;

        public BulletObject Get() => _bullets.Count > 0 ? _bullets.Pop() : _factory.Create();

        public void Return(BulletObject bulletObject) => _bullets.Push(bulletObject);
    }
}