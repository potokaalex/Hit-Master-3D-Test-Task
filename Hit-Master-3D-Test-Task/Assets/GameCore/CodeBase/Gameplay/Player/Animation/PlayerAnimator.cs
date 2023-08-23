using UnityEngine;

namespace GameCore.CodeBase.Gameplay.Player.Animation
{
    public class PlayerAnimator
    {
        private static readonly int _idleStateHash = Animator.StringToHash("Idle");
        private static readonly int _runStateHash = Animator.StringToHash("Run");

        private readonly Animator _animator;

        public PlayerAnimator(Animator animator)
            => _animator = animator;

        public void PlayIdle()
            => _animator.SetTrigger(_idleStateHash);

        public void PlayRun()
            => _animator.SetTrigger(_runStateHash);
    }
}