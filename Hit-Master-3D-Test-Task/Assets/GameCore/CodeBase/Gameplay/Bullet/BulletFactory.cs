using GameCore.CodeBase.Gameplay.Bullet.Object;

namespace GameCore.CodeBase.Gameplay.Bullet
{
    public class BulletFactory
    {
        private BulletObjectData _prefab;
        private BulletPool _pool;

        public void Initialize(BulletObjectData prefab, BulletPool pool)
        {
            _prefab = prefab;
            _pool = pool;
        }

        public BulletObject Create()
        {
            var data = UnityEngine.Object.Instantiate(_prefab);
            var bulletObject = new BulletObject(data, _pool);

            CreateCollisionHandler(data, bulletObject);

            return bulletObject;
        }

        private void CreateCollisionHandler(BulletObjectData data, BulletObject bulletObject)
        {
            var handler = data.gameObject.AddComponent<BulletCollisionHandler>();
            handler.Constructor(bulletObject);
        }
    }
}