using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerComponents
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private MainInput _mainInput;
        
        private void Awake()
        {
            _mainInput = new MainInput();
            _mainInput.Enable();

            _mainInput.Player.Movement.performed += Move;
            _mainInput.Player.Movement.canceled += Move;

            _mainInput.Player.Jump.performed += JumpStart;
            _mainInput.Player.Jump.canceled += JumpEnd;
        }

        private void OnDestroy()
        {
            _mainInput.Player.Movement.performed -= Move;
            _mainInput.Player.Movement.canceled -= Move;

            _mainInput.Player.Jump.performed -= JumpStart;
            _mainInput.Player.Jump.canceled -= JumpEnd;
        }

        private void JumpStart(InputAction.CallbackContext context)
        {
            _playerMovement.StartJump();
        }
        
        private void JumpEnd(InputAction.CallbackContext context)
        {
            _playerMovement.StopJump();
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>().normalized;
            
            _playerMovement.SetDirectionX(direction.x);
        }
    }
}