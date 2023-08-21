using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private LevelSceneData _sceneData;
        private IDataProvider _dataProvider;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IDataProvider dataProvider, IStateMachine stateMachine)
        {
            _dataProvider = dataProvider;
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            SetData();
            _stateMachine.SwitchTo<LevelStartupState>();
        }

        private void SetData() => _dataProvider.Set(_sceneData);
    }
}