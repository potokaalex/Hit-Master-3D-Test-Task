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
        private readonly IStateMachine _stateMachine;
        private readonly BulletFactory _bulletFactory;
        private readonly IDataProvider _dataProvider;

        private LevelGameplayState(PlayerInputFactory playerInputFactory,
            LevelFactory levelFactory, IStateMachine stateMachine, BulletFactory bulletFactory,
            IDataProvider dataProvider)
        {
            _playerInputFactory = playerInputFactory;
            _levelFactory = levelFactory;
            _stateMachine = stateMachine;
            _bulletFactory = bulletFactory;
            _dataProvider = dataProvider;
        }

        public void Enter()
        {
            var sceneData = _dataProvider.Get<LevelSceneData>();
            _playerInputFactory.CreatePlayerInput();
            _bulletFactory.Initialize(sceneData.BulletPrefab);
            _levelFactory.CreateVictoryCheck();
            _levelFactory.GetVictoryCheck().AddListener(_stateMachine.SwitchTo<LevelLoadingState>);
        }

        public void Exit()
        {
            _levelFactory.GetVictoryCheck().RemoveListener(_stateMachine.SwitchTo<LevelLoadingState>);
            _levelFactory.RemoveVictoryCheck();
        }
    }
}