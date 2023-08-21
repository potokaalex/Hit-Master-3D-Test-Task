using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelGameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly PlayerInputFactory _playerInputFactory;
        private readonly LevelFactory _levelFactory;
        private readonly IStateMachine _stateMachine;

        private LevelGameplayState(IDataProvider dataProvider, PlayerInputFactory playerInputFactory,
            LevelFactory levelFactory, IStateMachine stateMachine)
        {
            _dataProvider = dataProvider;
            _playerInputFactory = playerInputFactory;
            _levelFactory = levelFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var sceneData = _dataProvider.Get<LevelSceneData>();

            _playerInputFactory.CreatePlayerInput(sceneData.PlayerInputPrefab);
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