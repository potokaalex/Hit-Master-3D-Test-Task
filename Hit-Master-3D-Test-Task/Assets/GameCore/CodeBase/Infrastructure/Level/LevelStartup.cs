using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.Object;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private LevelSceneData _sceneData;
        private Locations _locations;
        private PlayerObjectFactory _playerObjectFactory;
        private PlayerInputFactory _playerInputFactory;

        [Inject]
        private void Constructor(Locations locations, PlayerObjectFactory playerObjectFactory,
            PlayerInputFactory playerInputFactory)
        {
            _locations = locations;
            _playerObjectFactory = playerObjectFactory;
            _playerInputFactory = playerInputFactory;
        }

        private void Start()
        {
            _locations.Initialize(_sceneData.LocationsData);
            _playerObjectFactory.CreatePlayerObject(_sceneData.PlayerObjectPrefab);
            _playerInputFactory.CreatePlayerInput(_sceneData.PlayerInputPrefab);
        }
    }
}