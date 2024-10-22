using System;
using ColliderBased;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerComponents
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField, ReadOnly] private bool _canMove;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce = 5f;
        [Header("Components")] 
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ColliderCheck _groundCheck;
        
        private bool _isJumping;
        private float _direction;
        private float _jumpButtonHoldTime;

        public bool IsMove => _direction != 0;
        public float MoveDirection => _direction;
        public float YVelocity => _rigidbody2D.velocity.y;
        public bool IsGround => _groundCheck.IsTouching;

        private void Start()
        {
            _canMove = true;
        }

        public void SetDirectionX(float value)
        {
            _direction = value;
        }

        public void StartJump()
        {
            if (_groundCheck.IsTouching)
            {
                _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            }
        }

        public void Freeze()
        {
            _canMove = false;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        public void UnFreeze()
        {
            _canMove = true;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        public void StopJump()
        {
            _isJumping = false;
        }

        private void Update()
        {
            if (_canMove == false)
                return;
            
            Move();
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_direction * _moveSpeed, _rigidbody2D.velocity.y);
        }
    }
}