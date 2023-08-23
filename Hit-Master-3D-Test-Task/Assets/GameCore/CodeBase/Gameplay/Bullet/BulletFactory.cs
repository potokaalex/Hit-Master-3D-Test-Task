namespace GameCore.CodeBase.Gameplay.Player
{
    public class BulletFactory
    {
        private BulletObject _prefab;

        public void Initialize(BulletObject prefab) => _prefab = prefab;

        public BulletObject Create() => UnityEngine.Object.Instantiate(_prefab);
    }
}