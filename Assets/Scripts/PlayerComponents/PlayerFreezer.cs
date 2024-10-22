using UnityEngine;

namespace PlayerComponents
{
    public class PlayerFreezer : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAnimator _animator;

        public void FreezeDeath()
        {
            _movement.Freeze();
            _animator.ShowDeath();
        }

        public void FreezeExit()
        {
            _movement.Freeze();
            _animator.ShowExit();
        }

        public void UnFreeze()
        {
            _movement.UnFreeze();
            _animator.Reset();
        }
    }
}