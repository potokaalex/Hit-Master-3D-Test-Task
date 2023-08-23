using GameCore.CodeBase.Gameplay.Bullet;
using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelGameplayState : IState
    {
        private readonly PlayerInputFactory _playerInputFactory;
        private readonly LevelFactory _levelFactory;
        private readonly BulletFactory _bulletFactory;
        private readonly IDataProvider _dataProvider;
        private readonly BulletPool _bulletPool;

        private LevelGameplayState(PlayerInputFactory playerInputFactory,
            LevelFactory levelFactory, BulletFactory bulletFactory,
            IDataProvider dataProvider, BulletPool bulletPool)
        {
            _playerInputFactory = playerInputFactory;
            _levelFactory = levelFactory;
            _bulletFactory = bulletFactory;
            _dataProvider = dataProvider;
            _bulletPool = bulletPool;
        }

        public void Enter()
        {
            var sceneData = _dataProvider.Get<LevelSceneData>();
            
            _playerInputFactory.CreatePlayerInput();
            _bulletFactory.Initialize(sceneData.BulletPrefab, _bulletPool);
            _levelFactory.CreateVictoryStarter();
        }

        public void Exit() => _levelFactory.RemoveVictoryCheck();
    }
}