using UnityEngine;
using UnityEngine.UI;

namespace GameCore.CodeBase.Gameplay.Enemy
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Initialize(float maxValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = maxValue;
        }

        public void Set(float value) => _slider.value = value;
    }
}