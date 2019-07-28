using UnityEngine;

namespace MovementVector2D
{
    public class PlayerMovement : CharacterMovement
    {
        private Animator _animator;        

        private Vector2 _lastMovementDirection;

        private void Start()
        {
            _animator = GetComponent<Animator>();            
            _lastMovementDirection = Vector2.down;
            base.BaseStart();
        }

        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput();
            if(movementVector != Vector2.zero)
            {
                base.Move(movementVector);
                PlayWalkAnimation(movementVector);
                _lastMovementDirection = movementVector;
            }
            else
            {
                PlayIdleAnimation(_lastMovementDirection);
            }
        }

        private void PlayIdleAnimation(Vector2 animationDirection)
        {
            if(animationDirection == Vector2.up)
            {
                _animator.Play("Female_Idle_Up");
            }
            else if (animationDirection == Vector2.right)
            {
                _animator.Play("Female_Idle_Right");
            }
            else if (animationDirection == Vector2.down)
            {
                _animator.Play("Female_Idle_Down");
            }
            else if (animationDirection == Vector2.left)
            {
                _animator.Play("Female_Idle_Left");
            }
        }

        private void PlayWalkAnimation(Vector2 animationDirection)
        {
            if (animationDirection == Vector2.up)
            {
                _animator.Play("Female_Walk_Up");
            }
            else if (animationDirection == Vector2.right)
            {
                _animator.Play("Female_Walk_Right");
            }
            else if (animationDirection == Vector2.down)
            {
                _animator.Play("Female_Walk_Down");
            }
            else if (animationDirection == Vector2.left)
            {
                _animator.Play("Female_Walk_Left");
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
