using GameCore.CodeBase.Infrastructure.Level.States;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level.Starter
{
    public class GameplayStarter : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        public void Constructor(IStateMachine stateMachine) => _stateMachine = stateMachine;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _stateMachine.SwitchTo<LevelGameplayState>();
        }
    }
}