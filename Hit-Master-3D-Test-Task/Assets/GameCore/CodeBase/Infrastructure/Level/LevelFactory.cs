using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Infrastructure.Level.Starter;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelFactory
    {
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly Locations _locations;
        private readonly IStateMachine _stateMachine;

        private GameplayStarter _gameplayStarter;
        private VictoryStarter _victoryStarter;

        public LevelFactory(PlayerObjectFactory playerObjectFactory, Locations locations, IStateMachine stateMachine)
        {
            _playerObjectFactory = playerObjectFactory;
            _locations = locations;
            _stateMachine = stateMachine;
        }

        public void CreateGameplayStarter()
        {
            var gameObject = new GameObject(nameof(GameplayStarter));
            _gameplayStarter = gameObject.AddComponent<GameplayStarter>();
            _gameplayStarter.Constructor(_stateMachine);
        }

        public void RemoveGameplayCheck() => Object.Destroy(_gameplayStarter);

        public void CreateVictoryStarter()
        {
            var gameObject = new GameObject(nameof(VictoryStarter));
            _victoryStarter = gameObject.AddComponent<VictoryStarter>();
            _victoryStarter.Construct(_playerObjectFactory, _locations, _stateMachine);
        }

        public void RemoveVictoryCheck() => Object.Destroy(_victoryStarter);
    }
}