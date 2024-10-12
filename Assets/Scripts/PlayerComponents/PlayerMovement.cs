using ColliderBased;
using UnityEngine;

namespace PlayerComponents
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _minJumpDistance;
        [SerializeField] private float _maxJumpDistance;
        [SerializeField] private float _maxJumpHoldTime = 0.1f;
        [Header("Components")] 
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ColliderCheck _groundCheck;
        
        private bool _isJumping;
        private float _direction;
        private float _jumpButtonHoldTime;

        public void SetDirectionX(float value) => _direction = value;

        public void StartJump()
        {
            if (_groundCheck.IsTouching)
                Jump();
        }

        public void StopJump() => _isJumping = false;

        private void Update()
        {
            Move();
            //Jump();
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_direction * _moveSpeed, _rigidbody2D.velocity.y);
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }
}