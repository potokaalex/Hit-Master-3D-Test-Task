using System;
using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class VictoryCheck : MonoBehaviour
    {
        private PlayerObjectFactory _playerObjectFactory;
        private Locations _locations;
        private Action _actions;

        public void Construct(PlayerObjectFactory playerObjectFactory, Locations locations)
        {
            _playerObjectFactory = playerObjectFactory;
            _locations = locations;
        }

        private void Update()
        {
            var currentLocation = _playerObjectFactory.Get().CurrentLocation;
            var lastLocation = _locations.GetLastLocation();

            if (currentLocation != lastLocation)
                return;

            if (lastLocation.EnemyCount <= 0)
                _actions?.Invoke();
        }

        public void AddListener(Action action) => _actions += action;

        public void RemoveListener(Action action) => _actions -= action;
    }
}