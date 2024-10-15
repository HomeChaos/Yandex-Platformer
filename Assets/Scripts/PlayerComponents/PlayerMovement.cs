using ColliderBased;
using UnityEngine;

namespace PlayerComponents
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _moveSpeed;
        [Space]
        [SerializeField] private float _minJumpForce = 5f;  // Сила прыжка при коротком нажатии
        [SerializeField] private float _addJumpForce = 0.15f; // Добавочная сила прыжка при долгом удержании
        [SerializeField] private float _jumpTimeMax = 0.2f; // Время, в течение которого можно удерживать прыжок
        [Header("Components")] 
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ColliderCheck _groundCheck;
        
        private bool _isJumping;
        private float _direction;
        private float _jumpButtonHoldTime;

        public bool IsMove => _direction != 0;

        public void SetDirectionX(float value)
        {
            _direction = value;
        }

        public void StartJump()
        {
            if (_groundCheck.IsTouching && _isJumping == false)
            {
                _isJumping = true;
                _jumpButtonHoldTime = Time.time;
                _rigidbody2D.AddForce(new Vector2(0f, _minJumpForce), ForceMode2D.Impulse);
            }
        }

        public void StopJump()
        {
            _isJumping = false;
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_direction * _moveSpeed, _rigidbody2D.velocity.y);
        }

        private void Jump()
        {
            if (_isJumping)
            {
                if (Time.time - _jumpButtonHoldTime < _jumpTimeMax)
                {
                    _rigidbody2D.AddForce(new Vector2(0f, _addJumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    _isJumping = false;
                }
            }
        }
    }
}