
using NaughtyAttributes;
using UnityEngine;

namespace PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private float _playerScale = 1;

        [Button("Show Death")]
        public void ShowDeath()
        {
            _animator.SetTrigger(PlayerAnimationKeys.Death);
        }

        [Button("Show Exit")]
        public void ShowExit()
        {
            _animator.SetTrigger(PlayerAnimationKeys.Exit);
        }

        [Button("Reset")]
        public void Reset()
        {
            _animator.SetTrigger(PlayerAnimationKeys.Reset);
        }

        private void Update()
        {
            _animator.SetBool(PlayerAnimationKeys.IsWalk, _movement.IsMove);
            _animator.SetBool(PlayerAnimationKeys.IsGround, _movement.IsGround);
            _animator.SetFloat(PlayerAnimationKeys.Vertical, _movement.YVelocity);
            UpdateLookForward(_movement.MoveDirection);
        }

        private void UpdateLookForward(float direction)
        {
            if (direction > 0)
                transform.localScale = new Vector3(_playerScale, _playerScale, _playerScale);
            else if (direction < 0)
                transform.localScale = new Vector3(-_playerScale, _playerScale, _playerScale);
        }
    }
}