using GameCore.CodeBase.Gameplay.Bullet;
using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player
{
    public class PlayerWeapon
    {
        private readonly BulletPool _bulletPool;
        private readonly Transform _weaponTransform;
        private readonly float _bulletSpeed;
        private readonly float _bulletLifeTime;

        public PlayerWeapon(BulletPool bulletPool, Transform weaponTransform, float bulletSpeed,
            float bulletLifeTime)
        {
            _bulletPool = bulletPool;
            _weaponTransform = weaponTransform;
            _bulletSpeed = bulletSpeed;
            _bulletLifeTime = bulletLifeTime;
        }

        public void Shoot(Vector3 targetPosition)
        {
            var bullet = _bulletPool.Get();
            var direction = (targetPosition - _weaponTransform.position).normalized;

            bullet.Initialize(_weaponTransform.position, _bulletLifeTime);
            bullet.AddForce(direction, _bulletSpeed);
        }
    }
}