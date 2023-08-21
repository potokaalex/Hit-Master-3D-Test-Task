using System;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class GameplayCheck : MonoBehaviour
    {
        private Action _actions;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _actions?.Invoke();
        }
        
        public void AddListener(Action action) => _actions += action;

        public void RemoveListener(Action action) => _actions -= action;
    }
}