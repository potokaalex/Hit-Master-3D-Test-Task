using System.Collections.Generic;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class BulletPool
    {
        private readonly BulletFactory _factory;
        private readonly Stack<BulletObject> _bullets = new();

        public BulletPool(BulletFactory factory) => _factory = factory;

        public BulletObject Get()
        {
            if (_bullets.Count > 0) 
                return _bullets.Pop();
            
            var bullet = _factory.Create();
            bullet.Constructor(this);
            return bullet;
        }

        public void Return(BulletObject bulletObject) => _bullets.Push(bulletObject);
    }
}