using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelFactory
    {
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly Locations _locations;

        private GameplayCheck _gameplayCheck;
        private VictoryCheck _victoryCheck;

        public LevelFactory(PlayerObjectFactory playerObjectFactory, Locations locations)
        {
            _playerObjectFactory = playerObjectFactory;
            _locations = locations;
        }

        public void CreateGameplayCheck()
        {
            var gameObject = new GameObject(nameof(GameplayCheck));
            _gameplayCheck = gameObject.AddComponent<GameplayCheck>();
        }

        public void RemoveGameplayCheck() => Object.Destroy(_gameplayCheck);

        public GameplayCheck GetGameplayCheck() => _gameplayCheck;

        public void CreateVictoryCheck()
        {
            var gameObject = new GameObject(nameof(VictoryCheck));
            _victoryCheck = gameObject.AddComponent<VictoryCheck>();
            _victoryCheck.Construct(_playerObjectFactory, _locations);
        }

        public void RemoveVictoryCheck() => Object.Destroy(_victoryCheck);

        public VictoryCheck GetVictoryCheck() => _victoryCheck;
    }
}