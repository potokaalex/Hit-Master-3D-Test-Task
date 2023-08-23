using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelStartupState : IState
    {
        private readonly Locations _locations;
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly LevelFactory _levelFactory;
        private readonly IStateMachine _stateMachine;
        private readonly IDataProvider _dataProvider;
        private GameplayCheck _gameplayCheck;

        public LevelStartupState(IDataProvider dataProvider, Locations locations,
            PlayerObjectFactory playerObjectFactory, LevelFactory levelFactory, IStateMachine stateMachine)
        {
            _locations = locations;
            _playerObjectFactory = playerObjectFactory;
            _levelFactory = levelFactory;
            _stateMachine = stateMachine;
            _dataProvider = dataProvider;
        }

        public void Enter()
        {
            var sceneData = _dataProvider.Get<LevelSceneData>();

            _locations.Initialize(sceneData.LocationsData);
            _levelFactory.CreateGameplayCheck();
            _levelFactory.GetGameplayCheck().AddListener(_stateMachine.SwitchTo<LevelGameplayState>);
            SetupPlayer(sceneData.PlayerPrefab);
        }

        public void Exit()
        {
            _levelFactory.GetGameplayCheck().RemoveListener(_stateMachine.SwitchTo<LevelGameplayState>);
            _levelFactory.RemoveGameplayCheck();
        }

        private void SetupPlayer(PlayerObjectData prefab)
        {
            _playerObjectFactory.CreatePlayerObject(prefab);
            _playerObjectFactory.Get().Initialize();
        }
    }
}