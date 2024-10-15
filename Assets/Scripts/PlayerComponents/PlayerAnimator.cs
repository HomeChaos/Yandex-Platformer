using System;
using NaughtyAttributes;
using UnityEngine;

namespace PlayerComponents
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _movement;

        private Vector3 _lastPosition;

        private void Start()
        {
            _lastPosition = transform.position;
        }

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

        [SerializeField, ReadOnly] private float _vertical;
        
        private void Update()
        {
            var currentPosition = transform.position;
            _vertical = _lastPosition.y - currentPosition.y;
            
            _animator.SetBool(PlayerAnimationKeys.IsWalk, _movement.IsMove);
            _animator.SetFloat(PlayerAnimationKeys.Vertical, _vertical);

            _lastPosition = currentPosition;
        }
    }
}