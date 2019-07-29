using UnityEngine;

namespace MovementVector2D
{
    public class PlayerMovement : CharacterMovement
    {
        private Animator _animator;        
        private Vector2 _lastMovementDirection;
        private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerAnimationScriptableObject _playerAnimationClips;

        private void Start()
        {
            _animator = GetComponent<Animator>();            
            _lastMovementDirection = Vector2.down;
            _playerAnimation = new PlayerAnimation(_animator, _playerAnimationClips);
            base.BaseStart();
        }

        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput();            
            if (movementVector != Vector2.zero)
            {
                base.Move(movementVector);                
                _playerAnimation.PlayAnimation(AnimationType.Walk, movementVector);                
                _lastMovementDirection = movementVector;
            }
            else
            {
                _playerAnimation.PlayAnimation(AnimationType.Idle, _lastMovementDirection);                
            }
        }

        private Vector2 GetMovementDirectionFromKeyboardInput()
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                moveY = +1f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moveX = +1f;
            }

            return new Vector2(moveX, moveY).normalized;
        }
    }
}
