using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level.Starter
{
    public class VictoryStarter : MonoBehaviour
    {
        private PlayerObjectFactory _playerObjectFactory;
        private Locations _locations;
        private IStateMachine _stateMachine;

        public void Construct(PlayerObjectFactory playerObjectFactory, Locations locations, IStateMachine stateMachine)
        {
            _playerObjectFactory = playerObjectFactory;
            _locations = locations;
            _stateMachine = stateMachine;
        }

        private void Update()
        {
            var currentLocation = _playerObjectFactory.Get().CurrentLocation;
            var lastLocation = _locations.GetLastLocation();

            if (currentLocation != lastLocation)
                return;

            if (lastLocation.Enemies.Count <= 0)
                _stateMachine.SwitchTo<LevelLoadingState>();
        }
    }
}